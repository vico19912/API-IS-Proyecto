using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;

using ApiProyecto.Repository.IRepository;
using ApiProyecto.Models.Dto;

namespace ApiProyecto.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RolController : ControllerBase
    {
        private readonly IRolRepository _rolRepository;
        private readonly IMapper _mapper;

        public RolController(IRolRepository rolRepository, IMapper mapper)
        {
            _rolRepository = rolRepository;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult GetAllRoles()
        {
            var lstRoles = _rolRepository.GetAllRoles();
            var lstRolesDto = new List<RolDto>();
            foreach (var rol in lstRoles)
            {
                lstRolesDto.Add(_mapper.Map<RolDto>(rol));
            }
            return Ok(lstRolesDto);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult CreateRol([FromBody] CreateRolDto createRol)
        {
            if (createRol == null)
            {
                return BadRequest(ModelState);
            }

            if(_rolRepository.GetRolByName(createRol.Descripcion) != null)
            {
                ModelState.AddModelError("CustomError",$"El rol con el nombre '{createRol.Descripcion}' ya existe.");
                return BadRequest(ModelState);
            }

            var rol = _mapper.Map<Rol>(createRol);
            if (!_rolRepository.CreateRol(rol))
            {
                ModelState.AddModelError("CustomError", $"Algo salió mal al intentar guardar el rol '{createRol.Descripcion}'.");
                return StatusCode(500, ModelState);
            }
            return CreatedAtRoute("GetRol", new { id = rol.Id_Rol }, rol);
        }
        [HttpDelete("{id:int}", Name = "DeleteRol")]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult DeleteRol(int id)
        {
            if( _rolRepository.GetRolById(id) == null)
            {
                return NotFound($"El rol con id '{id}' no existe.");
            } 
            var response = _rolRepository.DeleteRolById(id);
            if (!response)
            {
                ModelState.AddModelError("CustomError", $"Algo salió mal al intentar eliminar el rol con id '{id}'.");
                return StatusCode(500, ModelState);
            }
            return NoContent();
        }

        [HttpGet("{id:int}", Name = "GetRol")]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult GetRol(int id)
        {
            var rol = _rolRepository.GetRolById(id);
            if (rol == null)
            {
                return NotFound();
            }
            var rolDto = _mapper.Map<RolDto>(rol);
            return Ok(rolDto);
        }
    }
}
