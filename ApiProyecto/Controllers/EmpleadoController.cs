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
    public class EmpleadoController : ControllerBase
    {
        private readonly IEmpleadoRepository _empleadoRepository;
        private readonly IMapper _mapper;

        public EmpleadoController(IEmpleadoRepository empleadoRepository, IMapper mapper)
        {
            _empleadoRepository = empleadoRepository;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult GetAllEmpleados()
        {
            var lstEmpleados = _empleadoRepository.GetAllEmpleados();
            var lstEmpleadosDto = new List<EmpleadoDto>();
            foreach (var empleado in lstEmpleados)
            {
                lstEmpleadosDto.Add(_mapper.Map<EmpleadoDto>(empleado));
            }
            return Ok(lstEmpleadosDto);
        }

        [HttpGet("{id}", Name = "GetEmpleadoById")]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult GetEmpleadoById(int id)
        {
            var empleado = _empleadoRepository.GetEmpleadoById(id);
            if (empleado == null) return NotFound($"El empleado con ID {id} no existe.");
            var empleadoDto = _mapper.Map<EmpleadoDto>(empleado);
            return Ok(empleadoDto);
        }
        [HttpGet("hospital/{hospitalId}", Name = "GetEmpleadoByHospitalId")]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult GetEmpleadoByHospitalId(int hospitalId)
        {
            var empleados = _empleadoRepository.GetEmpleadoByHospitalId(hospitalId);
            var empleadosDto = new List<EmpleadoDto>();
            foreach (var empleado in empleados)
            {
                empleadosDto.Add(_mapper.Map<EmpleadoDto>(empleado));
            }
            return Ok(empleadosDto);
        }
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult CreateEmpleado([FromBody] CreateEmpleadoDto createEmpleadoDto)
        {
            if (createEmpleadoDto == null) return BadRequest(ModelState);
            var empleado = _mapper.Map<Empleado>(createEmpleadoDto);
            if (!_empleadoRepository.CreateEmpleado(empleado))
            {
                ModelState.AddModelError("CustomError", $"Ocurrió un error al crear el empleado.");
                return StatusCode(StatusCodes.Status500InternalServerError, ModelState);
            }
            var empleadoDto = _mapper.Map<EmpleadoDto>(empleado);
            return CreatedAtRoute("GetEmpleadoById", new { id = empleado.Id_Empleado }, empleadoDto);
        }
        [HttpPut("{id}", Name = "UpdateEmpleado")]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult UpdateEmpleado(int id, [FromBody] UpdateEmpleadoDto updateEmpleadoDto)
        {
            if (updateEmpleadoDto == null) return BadRequest(ModelState);

            var empleado = _empleadoRepository.GetEmpleadoById(id);
            if (empleado == null) return NotFound($"El empleado con ID {id} no existe.");

            _mapper.Map(updateEmpleadoDto, empleado);

            if (!_empleadoRepository.UpdateEmpleado(empleado))
            {
                ModelState.AddModelError("CustomError", $"Ocurrió un error al actualizar el empleado con ID {id}.");
                return StatusCode(StatusCodes.Status500InternalServerError, ModelState);
            }

            return NoContent();
        }
        [HttpDelete("{id}", Name = "DeleteEmpleado")]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult DeleteEmpleado(int id)
        {
            var empleado = _empleadoRepository.GetEmpleadoById(id);
            if (empleado == null) return NotFound($"El empleado con ID {id} no existe.");
            if (!_empleadoRepository.DeleteEmpleado(id))
            {
                ModelState.AddModelError("CustomError", $"Ocurrió un error al eliminar el empleado con ID {id}.");
                return StatusCode(StatusCodes.Status500InternalServerError, ModelState);
            }
            return NoContent();
        }
    }
}
