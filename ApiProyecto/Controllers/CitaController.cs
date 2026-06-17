using ApiProyecto.Repository.IRepository;
using ApiProyecto.Models;
using ApiProyecto.Models.Dto;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace ApiProyecto.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CitaController : ControllerBase
    {
        private readonly ICitaRepository _citaRepository;
        private readonly IMapper _mapper;
        public CitaController(ICitaRepository citaRepository, IMapper mapper)
        {
            _citaRepository = citaRepository;
            _mapper = mapper;
        }
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult GetAllCitas()
        {
            var lstCitas = _citaRepository.GetAllCitas();
            Console.WriteLine($"Total citas: {lstCitas.Count}");
            var lstCitasDto = new List<CitaDto>();
            foreach (var cita in lstCitas)
            {
                lstCitasDto.Add(_mapper.Map<CitaDto>(cita));
            }
            return Ok(lstCitasDto);
        }
        [HttpGet("{id}", Name = "GetCitaById")]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult GetCitaById(int id)
        {
            var cita = _citaRepository.GetCitaById(id);
            if (cita == null) return NotFound($"La cita con ID {id} no existe.");
            var citaDto = _mapper.Map<CitaDto>(cita);
            return Ok(citaDto);
        }
        [HttpGet("paciente/{pacienteId}", Name = "GetCitasByPacienteId")]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult GetCitasByPacienteId(int pacienteId)
        {
            var citas = _citaRepository.GetCitasByPacienteId(pacienteId);
            var citasDto = citas.Select(c => _mapper.Map<CitaDto>(c)).ToList();
            return Ok(citasDto);
        }
        [HttpGet("doctor/{doctorId}", Name = "GetCitasByDoctorId")]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult GetCitasByDoctorId(int doctorId)
        {
            var citas = _citaRepository.GetCitasByDoctorId(doctorId);
            if (citas == null || !citas.Any()) return NotFound($"No se encontraron citas para el doctor con ID {doctorId}.");
            var citasDto = citas.Select(c => _mapper.Map<CitaDto>(c)).ToList();
            return Ok(citasDto);
        }
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult CreateCita([FromBody] CreateCitaDto createCitaDto)
        {
            if (createCitaDto == null) return BadRequest(ModelState);
            var cita = _mapper.Map<Cita>(createCitaDto);
            if (!_citaRepository.CreateCita(cita))
            {
                ModelState.AddModelError("", $"Algo salió mal al guardar la cita con ID {cita.Id_Cita}.");
                return StatusCode(500, ModelState);
            }
            return CreatedAtRoute("GetCitaById", new { id = cita.Id_Cita }, cita);
        }
        [HttpPut("{id}", Name = "UpdateCita")]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult UpdateCita(int id, [FromBody] UpdateCitaDto updateCitaDto)
        {
            if (updateCitaDto == null) return BadRequest(ModelState);
            var cita = _citaRepository.GetCitaById(id);
            if (cita == null) return NotFound($"La cita con ID {id} no existe.");
            _mapper.Map(updateCitaDto, cita);
            if (!_citaRepository.UpdateCita(cita))
            {
                ModelState.AddModelError("", $"Algo salió mal al actualizar la cita con ID {cita.Id_Cita}.");
                return StatusCode(500, ModelState);
            }
            return NoContent();
        }
        [HttpDelete("{id}", Name = "DeleteCita")]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult DeleteCita(int id)
        {
            var cita = _citaRepository.GetCitaById(id);
            if (cita == null) return NotFound($"La cita con ID {id} no existe.");
            if (!_citaRepository.DeleteCita(id))
            {
                ModelState.AddModelError("", $"Algo salió mal al eliminar la cita con ID {id}.");
                return StatusCode(500, ModelState);
            }
            return NoContent();
        }
    }
}
