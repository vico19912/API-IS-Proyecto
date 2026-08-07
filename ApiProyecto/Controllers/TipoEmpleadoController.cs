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
    public class TipoEmpleadoController : ControllerBase
    {
        private readonly ITipoEmpleadoRepository _tipoEmpleadoRepository;
        private readonly IMapper _mapper;

        public TipoEmpleadoController(ITipoEmpleadoRepository tipoEmpleadoRepository, IMapper mapper)
        {
            _tipoEmpleadoRepository = tipoEmpleadoRepository;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult GetAllTipoEmpleados()
        {
            var lstTipoEmpleados = _tipoEmpleadoRepository.GetAllTipoEmpleados();
            var lstTipoEmpleadosDto = new List<TipoEmpleadoDto>();
            foreach (var tipoEmpleado in lstTipoEmpleados)
            {
                lstTipoEmpleadosDto.Add(_mapper.Map<TipoEmpleadoDto>(tipoEmpleado));
            }
            return Ok(lstTipoEmpleadosDto);
        }
        [HttpGet("{id:int}", Name = "GetTipoEmpleadoById")]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult GetTipoEmpleadoById(int id)
        {
            var tipoEmpleado = _tipoEmpleadoRepository.GetTipoEmpleadoById(id);
            if (tipoEmpleado == null)
            {
                return NotFound($"El tipo de empleado con ID {id} no existe.");
            }
            var tipoEmpleadoDto = _mapper.Map<TipoEmpleadoDto>(tipoEmpleado);
            return Ok(tipoEmpleadoDto);
        }
        [HttpGet("{name}", Name = "GetTipoEmpleadoByName")]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult GetTipoEmpleadoByName(string name)
        {
            var tipoEmpleado = _tipoEmpleadoRepository.GetTipoEmpleadoByDescripcion(name);
            if (tipoEmpleado == null)
            {
                return NotFound($"El tipo de empleado con nombre {name} no existe.");
            }
            var tipoEmpleadoDto = _mapper.Map<TipoEmpleadoDto>(tipoEmpleado);
            return Ok(tipoEmpleadoDto);
        }
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult CreateTipoEmpleado([FromBody] CreateTipoEmpleadoDto tipoEmpleadoDto)
        {
            if (tipoEmpleadoDto == null) return BadRequest(ModelState);
            if (_tipoEmpleadoRepository.GetTipoEmpleadoByDescripcion(tipoEmpleadoDto.Descripcion) != null)
            {
                ModelState.AddModelError("CustomError", $"El tipo de empleado con nombre {tipoEmpleadoDto.Descripcion} ya existe.");
                return StatusCode(StatusCodes.Status400BadRequest, ModelState);
            }
            var tipoEmpleado = _mapper.Map<TipoEmpleado>(tipoEmpleadoDto);
            if (!_tipoEmpleadoRepository.CreateTipoEmpleado(tipoEmpleado))
            {
                ModelState.AddModelError("CustomError", $"Algo salió mal al guardar el tipo de empleado {tipoEmpleadoDto.Descripcion}.");
                return StatusCode(StatusCodes.Status500InternalServerError, ModelState);
            }
            return CreatedAtRoute("GetTipoEmpleadoById", new { id = tipoEmpleado.Id_Tipo }, tipoEmpleado);
        }
        [HttpPut("{id:int}", Name = "UpdateTipoEmpleado")]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult UpdateTipoEmpleado(int id, [FromBody] CreateTipoEmpleadoDto updateTipoEmpleadoDto)
        {
            if (updateTipoEmpleadoDto == null) return BadRequest(ModelState);
            var tipoEmpleado = _tipoEmpleadoRepository.GetTipoEmpleadoById(id);
            if (tipoEmpleado == null) return NotFound($"El tipo de empleado con ID {id} no existe.");

            _mapper.Map(updateTipoEmpleadoDto, tipoEmpleado);

            if (!_tipoEmpleadoRepository.UpdateTipoEmpleado(tipoEmpleado))
            {
                ModelState.AddModelError("CustomError", $"Algo salió mal al actualizar el tipo de empleado {updateTipoEmpleadoDto.Descripcion}.");
                return StatusCode(StatusCodes.Status500InternalServerError, ModelState);
            }
            return NoContent();
        }
        [HttpDelete("{id:int}", Name = "DeleteTipoEmpleado")]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult DeleteTipoEmpleado(int id)
        {
            var tipoEmpleado = _tipoEmpleadoRepository.GetTipoEmpleadoById(id);
            if (tipoEmpleado == null) return NotFound($"El tipo de empleado con ID {id} no existe.");

            if (!_tipoEmpleadoRepository.DeleteTipoEmpleadoById(id))
            {
                ModelState.AddModelError("CustomError", $"Algo salió mal al eliminar el tipo de empleado con ID {id}.");
                return StatusCode(StatusCodes.Status500InternalServerError, ModelState);
            }
            return NoContent();
        }
    }
}
