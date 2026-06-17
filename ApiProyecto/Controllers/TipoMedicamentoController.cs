using ApiProyecto.Models;
using ApiProyecto.Models.Dto;
using ApiProyecto.Repository.IRepository;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace ApiProyecto.Controllers;

[Route("api/[controller]")]
[ApiController]
public class TipoMedicamentoController : ControllerBase
{
    private readonly ITipoMedicamentoRepository _repo;
    private readonly IMapper _mapper;
    public TipoMedicamentoController(ITipoMedicamentoRepository repo, IMapper mapper) =>
        (_repo, _mapper) = (repo, mapper);

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public IActionResult GetAll() =>
        Ok(_repo.GetAll().Select(t => _mapper.Map<TipoMedicamentoDto>(t)));

    [HttpGet("{id:int}", Name = "GetTipoMedicamentoById")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public IActionResult GetById(int id)
    {
        var tipo = _repo.GetById(id);
        if (tipo == null) return NotFound($"Tipo de medicamento con ID {id} no encontrado.");
        return Ok(_mapper.Map<TipoMedicamentoDto>(tipo));
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public IActionResult Create([FromBody] CreateTipoMedicamentoDto dto)
    {
        if (!ModelState.IsValid) return BadRequest(ModelState);
        var tipo = _mapper.Map<TipoMedicamento>(dto);
        if (!_repo.Create(tipo)) return StatusCode(500, "Error al crear el tipo de medicamento.");
        return CreatedAtRoute("GetTipoMedicamentoById", new { id = tipo.Id_Tipo }, _mapper.Map<TipoMedicamentoDto>(tipo));
    }

    [HttpPut("{id:int}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public IActionResult Update(int id, [FromBody] CreateTipoMedicamentoDto dto)
    {
        if (!ModelState.IsValid) return BadRequest(ModelState);
        var tipo = _repo.GetById(id);
        if (tipo == null) return NotFound($"Tipo de medicamento con ID {id} no encontrado.");
        tipo.Descripcion = dto.Descripcion;
        if (!_repo.Update(tipo)) return StatusCode(500, "Error al actualizar.");
        return NoContent();
    }

    [HttpDelete("{id:int}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public IActionResult Delete(int id)
    {
        if (!_repo.Delete(id)) return NotFound($"Tipo de medicamento con ID {id} no encontrado.");
        return NoContent();
    }
}
