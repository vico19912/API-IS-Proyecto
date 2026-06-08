using ApiProyecto.Repository.IRepository;
using ApiProyecto.Models;
using ApiProyecto.Models.Dto;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace MyApp.Namespace
{
    [Route("api/[controller]")]
    [ApiController]
    public class DoctorController : ControllerBase
    {
        private readonly IDoctorRepository _doctorRepository;
        private readonly IMapper _mapper;
        public DoctorController(IDoctorRepository doctorRepository, IMapper mapper)
        {
            _doctorRepository = doctorRepository;
            _mapper = mapper;
        }
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult GetAllDoctors()
        {
            var lstDoctors = _doctorRepository.GetAllDoctors();
            var lstDoctorsDto = new List<DoctorDto>();
            foreach (var doctor in lstDoctors)
            {
                lstDoctorsDto.Add(_mapper.Map<DoctorDto>(doctor));
            }
            return Ok(lstDoctorsDto);
        }
        [HttpGet("{id}", Name = "GetDoctorById")]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult GetDoctorById(int id)
        {
            var doctor = _doctorRepository.GetDoctorById(id);
            if (doctor == null) return NotFound($"El doctor con ID {id} no existe.");
            var doctorDto = _mapper.Map<DoctorDto>(doctor);
            return Ok(doctorDto);
        }
        [HttpGet("name/{name}", Name = "GetDoctorByName")]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult GetDoctorByName(string name)
        {
            var doctor = _doctorRepository.GetDoctorByName(name);
            if (doctor == null) return NotFound($"No se encontró registro para doctor con nombre: {name}.");
            var doctorDto = _mapper.Map<DoctorDto>(doctor);
            return Ok(doctorDto);
        }
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult CreateDoctor([FromBody] CreateDoctorDto createDoctorDto)
        {
            if (createDoctorDto == null) return BadRequest(ModelState);
            var doctor = _mapper.Map<Doctor>(createDoctorDto);
            if (!_doctorRepository.CreateDoctor(doctor))
            {
                ModelState.AddModelError("CustomError", $"Algo salió mal guardando el doctor {doctor.Persona.Nombre}");
                return StatusCode(StatusCodes.Status500InternalServerError, ModelState);
            }
            return CreatedAtRoute("GetDoctorById", new { id = doctor.Id_Doctor }, doctor);
        }
        [HttpPut("{id}", Name = "UpdateDoctor")]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult UpdateDoctor(int id, [FromBody] UpdateDoctorDto updateDoctorDto)
        {
            if (updateDoctorDto == null) return BadRequest(ModelState);
            var doctor = _doctorRepository.GetDoctorById(id);
            if (doctor == null) return NotFound($"El doctor con ID {id} no existe.");
            _mapper.Map(updateDoctorDto, doctor);
            if (!_doctorRepository.UpdateDoctor(doctor))
            {
                ModelState.AddModelError("CustomError", $"Algo salió mal actualizando el doctor {doctor.Persona.Nombre}");
                return StatusCode(StatusCodes.Status500InternalServerError, ModelState);
            }
            return NoContent();
        }
        [HttpDelete("{id}", Name = "DeleteDoctor")]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult DeleteDoctor(int id)
        {
            var doctor = _doctorRepository.GetDoctorById(id);
            if (doctor == null) return NotFound($"El doctor con ID {id} no existe.");
            if (!_doctorRepository.DeleteDoctor(id))
            {
                ModelState.AddModelError("CustomError", $"Algo salió mal eliminando el doctor con ID {id}");
                return StatusCode(StatusCodes.Status500InternalServerError, ModelState);
            }
            return NoContent();
        }
    }
}
