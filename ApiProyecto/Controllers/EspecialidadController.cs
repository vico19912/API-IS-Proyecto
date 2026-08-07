using ApiProyecto.Repository.IRepository;
using ApiProyecto.Models;
using ApiProyecto.Models.Dto;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MyApp.Namespace
{
    [Route("api/[controller]")]
    [ApiController]
    public class EspecialidadController : ControllerBase
    {
        private readonly IEspecialidadRepository _especialidadRepository;
        private readonly IMapper _mapper;

        public EspecialidadController(IEspecialidadRepository especialidadRepository, IMapper mapper)
        {
            _especialidadRepository = especialidadRepository;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult GetAllEspecialidades()
        {
            var lstEspecialidades = _especialidadRepository.GetAllEspecialidades();
            var lstEspecialidadesDto = new List<EspecialidadDto>();
            foreach (var especialidad in lstEspecialidades)
            {
                lstEspecialidadesDto.Add(_mapper.Map<EspecialidadDto>(especialidad));
            }
            return Ok(lstEspecialidadesDto);
        }
        [HttpGet("{id:int}", Name = "GetEspecialidadById")]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult GetEspecialidadById(int id)
        {
            var especialidad = _especialidadRepository.GetEspecialidadById(id);
            if (especialidad == null) return NotFound($"La especialidad con ID {id} no existe.");
            var especialidadDto = _mapper.Map<EspecialidadDto>(especialidad);
            return Ok(especialidadDto);
        }
        [HttpGet("{name}", Name = "GetEspecialidadByName")]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult GetEspecialidadByName(string name)
        {
            var especialidad = _especialidadRepository.GetEspecialidadByName(name);
            if (especialidad == null) return NotFound($"La especialidad con nombre {name} no existe.");
            var especialidadDto = _mapper.Map<EspecialidadDto>(especialidad);
            return Ok(especialidadDto);
        }
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult CreateEspecialidad([FromBody] CreateEspecialidadDto especialidadDto)
        {
            if (especialidadDto == null) return BadRequest(ModelState);
            if (_especialidadRepository.GetEspecialidadByName(especialidadDto.Descripcion) != null)
            {
                ModelState.AddModelError("", $"La especialidad con nombre {especialidadDto.Descripcion} ya existe.");
                return StatusCode(StatusCodes.Status400BadRequest, ModelState);
            }
            var especialidad = _mapper.Map<Especialidad>(especialidadDto);
            if (!_especialidadRepository.CreateEspecialidad(especialidad))
            {
                ModelState.AddModelError("", $"Algo salió mal al guardar la especialidad {especialidadDto.Descripcion}.");
                return StatusCode(StatusCodes.Status500InternalServerError, ModelState);
            }
            return CreatedAtRoute("GetEspecialidadById", new { id = especialidad.Id_Especialidad }, especialidad);
        }
        [HttpPut("{id:int}", Name = "UpdateEspecialidad")]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult UpdateEspecialidad(int id, [FromBody] CreateEspecialidadDto updateEspecialidadDto)
        {
            if (updateEspecialidadDto == null) return BadRequest(ModelState);
            var especialidad = _especialidadRepository.GetEspecialidadById(id);
            if (especialidad == null) return NotFound($"La especialidad con ID {id} no existe.");

            _mapper.Map(updateEspecialidadDto, especialidad);

            if (!_especialidadRepository.UpdateEspecialidad(especialidad))
            {
                ModelState.AddModelError("", $"Ocurrió un error al actualizar la especialidad con ID {id}.");
                return StatusCode(StatusCodes.Status500InternalServerError, ModelState);
            }
            return NoContent();
        }
        [HttpDelete("{id:int}", Name = "DeleteEspecialidad")]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult DeleteEspecialidad(int id)
        {
            var especialidad = _especialidadRepository.GetEspecialidadById(id);
            if (especialidad == null) return NotFound($"La especialidad con ID {id} no existe.");

            if (!_especialidadRepository.DeleteEspecialidad(id))
            {
                ModelState.AddModelError("", $"Ocurrió un error al eliminar la especialidad con ID {id}.");
                return StatusCode(StatusCodes.Status500InternalServerError, ModelState);
            }
            return NoContent();
        }
    }
}
