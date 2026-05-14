using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using AutoMapper;
using ApiProyecto.Repository.IRepository;
using ApiProyecto.Models.Dto;
using ApiProyecto.Models;

namespace MyApp.Namespace
{
    [Route("api/[controller]")]
    [ApiController]
    public class PermisoController : ControllerBase
    {
        private readonly IPermisoRepository _permisoRepository;
        private readonly IMapper _mapper;
        public PermisoController(IPermisoRepository permisoRepository, IMapper mapper)
        {
            _permisoRepository = permisoRepository;
            _mapper = mapper;
        }
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult GetAllPermisos()
        {
            var lstPermisos = _permisoRepository.GetAllPermisos();
            var lstPermisosDto = new List<PermisoDto>();
            foreach (var permiso in lstPermisos)
            {
                lstPermisosDto.Add(_mapper.Map<PermisoDto>(permiso));
            }
            return Ok(lstPermisosDto);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult CreatePermiso([FromBody] CreatePermisoDto createPermiso)
        {
            if (createPermiso == null)
            {
                return BadRequest(ModelState);
            }

            if(_permisoRepository.GetPermisoByName(createPermiso.Descripcion) != null)
            {
                ModelState.AddModelError("CustomError",$"El permiso con el nombre '{createPermiso.Descripcion}' ya existe.");
                return BadRequest(ModelState);
            }

            var permiso = _mapper.Map<Permiso>(createPermiso);
            if (!_permisoRepository.CreatePermiso(permiso))
            {
                ModelState.AddModelError("CustomError", $"Algo salió mal al intentar guardar el permiso '{createPermiso.Descripcion}'.");
                return StatusCode(500, ModelState);
            }

            return CreatedAtRoute("GetPermiso", new { id = permiso.Id_Permiso }, permiso);
        }
        [HttpGet("{id:int}", Name = "GetPermiso")]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult GetPermiso(int id)
        {
            var permiso = _permisoRepository.GetPermisoById(id);
            if (permiso == null)
            {
                return NotFound();
            }
            var permisoDto = _mapper.Map<PermisoDto>(permiso);
            return Ok(permisoDto);
        }
        [HttpGet("rol/{rolId:int}")]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult GetPermisoByRolId(int rolId)
        {
            var permisos = _permisoRepository.GetPermisoByRolId(rolId);
            if (permisos == null || permisos.Count == 0)
            {
                return NotFound();
            }
            var permisosDto = new List<PermisoDto>();
            foreach (var permiso in permisos)
            {
                permisosDto.Add(_mapper.Map<PermisoDto>(permiso));
            }
            return Ok(permisosDto);
        }
        [HttpDelete("{id:int}", Name = "DeletePermiso")]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult DeletePermiso(int id)
        {
            if( _permisoRepository.GetPermisoById(id) == null)
            {
                return NotFound($"El permiso con id '{id}' no existe.");
            }
            var response = _permisoRepository.DeletePermisoById(id);
            if (!response)
            {
                ModelState.AddModelError("CustomError", $"Algo salió mal al intentar eliminar el permiso con id '{id}'.");
                return StatusCode(500, ModelState);
            }
            return NoContent();
        }
        [HttpPatch("{id:int}", Name = "UpdatePermiso")]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult UpdatePermiso(int id, [FromBody] PermisoDto updatePermiso)
        {
            if (_permisoRepository.GetPermisoById(id) == null)
            {
                return NotFound($"El permiso con id '{id}' no existe.");
            }
            if (updatePermiso == null )
            {
                return BadRequest(ModelState);
            }

            var permiso = _mapper.Map<Permiso>(updatePermiso);
            if (!_permisoRepository.UpdatePermiso(permiso))
            {
                ModelState.AddModelError("CustomError", $"Algo salió mal al intentar actualizar el permiso con id '{id}'.");
                return StatusCode(500, ModelState);
            }
            return NoContent();
        }
    }
}
