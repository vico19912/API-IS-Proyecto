using ApiProyecto.Repository.IRepository;
using ApiProyecto.Models;
using ApiProyecto.Models.Dto;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiProyecto.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HospitalController : ControllerBase
    {
        private readonly IHospitalRepository _hospitalRepository;
        private readonly IMapper _mapper;

        public HospitalController(IHospitalRepository hospitalRepository, IMapper mapper)
        {
            _hospitalRepository = hospitalRepository;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult GetAllHospitals()
        {
            var lstHospitals = _hospitalRepository.GetAllHospitals();
            var lstHospitalsDto = new List<HospitalDto>();
            foreach (var hospital in lstHospitals)
            {
                lstHospitalsDto.Add(_mapper.Map<HospitalDto>(hospital));
            }
            return Ok(lstHospitalsDto);
        }
        [HttpGet("{id:int}", Name = "GetHospitalById")]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult GetHospitalById(int id)
        {
            var hospital = _hospitalRepository.GetHospitalById(id);
            if (hospital == null) return NotFound($"El hospital con ID {id} no existe.");
            var hospitalDto = _mapper.Map<HospitalDto>(hospital);
            return Ok(hospitalDto);
        }
        [HttpGet("{name}", Name = "GetHospitalByName")]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult GetHospitalByName(string name)
        {
            var hospital = _hospitalRepository.GetHospitalByName(name);
            if (hospital == null) return NotFound($"El hospital con nombre {name} no existe.");
            var hospitalDto = _mapper.Map<HospitalDto>(hospital);
            return Ok(hospitalDto);
        }
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult CreacteHospital([FromBody] CreateHospitalDto createHospitalDto)
        {
            if (createHospitalDto == null) return BadRequest(ModelState);
            if (_hospitalRepository.GetHospitalByName(createHospitalDto.Nombre) != null)
            {
                ModelState.AddModelError("CustomError", $"El hospital con nombre {createHospitalDto.Nombre} ya existe.");
                return BadRequest(ModelState);
            }
            var hospital = _mapper.Map<Hospital>(createHospitalDto);
            if (!_hospitalRepository.CreateHospital(hospital))
            {
                ModelState.AddModelError("CustomError", $"Ocurrió un error al crear el hospital {createHospitalDto.Nombre}.");
                return StatusCode(500, ModelState);
            }
            return CreatedAtRoute("GetHospitalById", new { id = hospital.Id_Hospital }, hospital);
        }
        [HttpPut("{id:int}", Name = "UpdateHospital")]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult UpdateHospital(int id, [FromBody] CreateHospitalDto updateHospitalDto)
        {
            if (updateHospitalDto == null) return BadRequest(ModelState);
            var hospital = _hospitalRepository.GetHospitalById(id);
            if (hospital == null) return NotFound($"El hospital con ID {id} no existe.");

            _mapper.Map(updateHospitalDto, hospital);

            if (!_hospitalRepository.UpdateHospital(hospital))
            {
                ModelState.AddModelError("CustomError", $"Ocurrió un error al actualizar el hospital con ID {id}.");
                return StatusCode(500, ModelState);
            }
            return NoContent();
        }
        [HttpDelete("{id:int}", Name = "DeleteHospital")]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult DeleteHospital(int id)
        {
            var hospital = _hospitalRepository.GetHospitalById(id);
            if (hospital == null) return NotFound($"El hospital con ID {id} no existe.");

            if (!_hospitalRepository.DeleteHospital(id))
            {
                ModelState.AddModelError("CustomError", $"Ocurrió un error al eliminar el hospital con ID {id}.");
                return StatusCode(500, ModelState);
            }
            return NoContent();
        }
    }
}
