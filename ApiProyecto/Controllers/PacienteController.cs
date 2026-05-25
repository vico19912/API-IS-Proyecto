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
    public class PacienteController : ControllerBase
    {
        private readonly IPacienteRepository _pacienteRepository;
        private readonly IMapper _mapper;

        public PacienteController(IPacienteRepository pacienteRepository, IMapper mapper)
        {
            _pacienteRepository = pacienteRepository;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult GetAllPacientes()
        {
            var lstPacientes = _pacienteRepository.GetAllPacientes();
            var lstPacientesDto = new List<PacienteDto>();
            foreach (var paciente in lstPacientes)
            {
                lstPacientesDto.Add(_mapper.Map<PacienteDto>(paciente));
            }
            return Ok(lstPacientesDto);
        }

        [HttpGet("{dni}", Name = "GetPacienteByDNI")]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult GetPacienteByDNI( string dni)
        {
            var paciente = _pacienteRepository.GetPacienteByDNI(dni);
            if (paciente == null) return NotFound($"El paciente con DNI {dni} no existe.");
            var pacienteDto = _mapper.Map<PacienteDto>(paciente);
            return Ok(pacienteDto);
        }
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult CreactePaciente([FromBody] CreatePacienteDto createPacienteDto)
        {
            if ( createPacienteDto == null) return BadRequest(ModelState);
            if ( _pacienteRepository.GetPacienteByDNI(createPacienteDto.DNI) != null)
            {
                ModelState.AddModelError("CustomError", $"El paciente con DNI {createPacienteDto.DNI} ya existe.");
                return BadRequest(ModelState);
            }
             var paciente = new Paciente
             {  
               Persona =  _mapper.Map<Persona>(createPacienteDto)
             };
             
             if ( !_pacienteRepository.CreatePaciente(paciente))
             {
                ModelState.AddModelError("CustomError", $"Ocurrió un error al crear el paciente con DNI {createPacienteDto.DNI}.");
                return StatusCode(500, ModelState);
             }
            return CreatedAtRoute("GetPacienteByDNI", new { dni = createPacienteDto.DNI }, createPacienteDto);
        }
        [HttpGet("{id:int}", Name = "GetPacienteById")]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult GetPacienteById( int id)
        {
            var paciente = _pacienteRepository.GetPacienteById(id);
            if (paciente == null) return NotFound($"El paciente con ID {id} no existe.");
            var pacienteDto = _mapper.Map<PacienteDto>(paciente);
            return Ok(pacienteDto);
        }
        [HttpPatch("{id:int}", Name = "UpdatePaciente")]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult UpdatePaciente( int id, [FromBody] CreatePacienteDto updatePacienteDto)
        {
            if (updatePacienteDto == null) return BadRequest(ModelState);
            var paciente = _pacienteRepository.GetPacienteById(id);
            if (paciente == null) return NotFound($"El paciente con ID {id} no existe.");

            _mapper.Map(updatePacienteDto, paciente.Persona);

            if (!_pacienteRepository.UpdatePaciente(paciente))
            {
                ModelState.AddModelError("CustomError", $"Ocurrió un error al actualizar el paciente con ID {id}.");
                return StatusCode(500, ModelState);
            }
            return NoContent();
        }
        [HttpDelete("{id:int}", Name = "DeletePaciente")]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult DeletePaciente( int id)
        {
            var paciente = _pacienteRepository.GetPacienteById(id);
            if (paciente == null) return NotFound($"El paciente con ID {id} no existe.");
            if (!_pacienteRepository.DeletePaciente(id))
            {
                ModelState.AddModelError("CustomError", $"Ocurrió un error al eliminar el paciente con ID {id}.");
                return StatusCode(500, ModelState);
            }
            return NoContent();
        }
    }
}
