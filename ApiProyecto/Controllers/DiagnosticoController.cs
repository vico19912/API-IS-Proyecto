using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;

using ApiProyecto.Repository.IRepository;
using ApiProyecto.Models.Dto;
using ApiProyecto.Models;

namespace ApiProyecto.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DiagnosticoController : ControllerBase
    {
        private readonly IDiagnosticoRepository _diagnosticoRepository;
        private readonly IMapper _mapper;
        public DiagnosticoController(IDiagnosticoRepository diagnosticoRepository, IMapper mapper)
        {
            _diagnosticoRepository = diagnosticoRepository;
            _mapper = mapper;
        }

        [HttpGet("{dni}")]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult GetAllDiagnosticoByDNI(string dni)
        {
            var lstDiagnostico = _diagnosticoRepository.GetAllDiagnosticoByDNI(dni);
            if (lstDiagnostico == null || lstDiagnostico.Count == 0) return NotFound($"No se encontraron diagnosticos para el paciente con DNI {dni}.");
            var lstDiagnosticoDto = new List<DiagnosticoDto>();
            foreach (var diagnostico in lstDiagnostico)
            {
                lstDiagnosticoDto.Add(_mapper.Map<DiagnosticoDto>(diagnostico));
            }
            return Ok(lstDiagnosticoDto);
        }
        [HttpGet("id/{id}", Name = "GetDiagnosticoById")]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult GetDiagnosticoById(int id)
        {
            var diagnostico = _diagnosticoRepository.GetDiagnosticoById(id);
            if (diagnostico == null) return NotFound($"El diagnostico con ID {id} no existe.");
            var diagnosticoDto = _mapper.Map<DiagnosticoDto>(diagnostico);
            return Ok(diagnosticoDto);
        }
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult CreateDiagnostico([FromBody] CreateDiagnosticoDto createDiagnostico)
        {
            if (createDiagnostico == null)
            {
                return BadRequest(ModelState);
            }

            var diagnostico = _mapper.Map<Diagnostico>(createDiagnostico);
            if (!_diagnosticoRepository.CreateDiagnostico(diagnostico))
            {
                ModelState.AddModelError("CustomError", $"Algo salió mal al intentar guardar el diagnostico para la cita con ID '{createDiagnostico.Cita_Id}'.");
                return StatusCode(500, ModelState);
            }
            return CreatedAtRoute("GetDiagnosticoById", new { id = diagnostico.Id_Diagnostico }, diagnostico);
        }
        [HttpPut("{id}", Name = "UpdateDiagnostico")]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult UpdateDiagnostico(int id, [FromBody] CreateDiagnosticoDto updateDiagnostico)
        {
            if (updateDiagnostico == null) return BadRequest(ModelState);
            var diagnostico = _diagnosticoRepository.GetDiagnosticoById(id);
            if (diagnostico == null) return NotFound($"El diagnostico con ID {id} no existe.");
            _mapper.Map(updateDiagnostico, diagnostico);
            if (!_diagnosticoRepository.UpdateDiagnostico(diagnostico))
            {
                ModelState.AddModelError("CustomError", $"Algo salió mal al intentar actualizar el diagnostico con ID '{id}'.");
                return StatusCode(500, ModelState);
            }
            return NoContent();
        }
        [HttpDelete("{id}", Name = "DeleteDiagnostico")]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult DeleteDiagnostico(int id)
        {
            var diagnostico = _diagnosticoRepository.GetDiagnosticoById(id);
            if (diagnostico == null) return NotFound($"El diagnostico con ID {id} no existe.");
            if (!_diagnosticoRepository.DeleteDiagnostico(id))
            {
                ModelState.AddModelError("CustomError", $"Algo salió mal al intentar eliminar el diagnostico con ID '{id}'.");
                return StatusCode(500, ModelState);
            }
            return NoContent();
        }
    }
}
