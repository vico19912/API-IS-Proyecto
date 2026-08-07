using ApiProyecto.Models;
using ApiProyecto.Models.Dto;
using ApiProyecto.Repository.IRepository;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace ApiProyecto.Controllers;

[Route("api/[controller]")]
[ApiController]
public class FacturaController : ControllerBase
{
    private readonly IFacturaRepository _repo;
    private readonly IMapper _mapper;
    public FacturaController(IFacturaRepository repo, IMapper mapper) =>
        (_repo, _mapper) = (repo, mapper);

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public IActionResult GetAll() =>
        Ok(_repo.GetAll().Select(f => _mapper.Map<FacturaDto>(f)));

    [HttpGet("{id:int}", Name = "GetFacturaById")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public IActionResult GetById(int id)
    {
        var f = _repo.GetById(id);
        if (f == null) return NotFound($"Factura con ID {id} no encontrada.");
        return Ok(_mapper.Map<FacturaDto>(f));
    }

    [HttpGet("cita/{citaId:int}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public IActionResult GetByCita(int citaId) =>
        Ok(_repo.GetByCitaId(citaId).Select(f => _mapper.Map<FacturaDto>(f)));

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public IActionResult Create([FromBody] CreateFacturaDto dto)
    {
        if (!ModelState.IsValid) return BadRequest(ModelState);
        var factura = _mapper.Map<Factura>(dto);
        if (!_repo.Create(factura)) return StatusCode(500, "Error al crear la factura.");
        return CreatedAtRoute("GetFacturaById", new { id = factura.Id_Factura }, _mapper.Map<FacturaDto>(factura));
    }

    [HttpPut("{id:int}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public IActionResult Update(int id, [FromBody] CreateFacturaDto dto)
    {
        if (!ModelState.IsValid) return BadRequest(ModelState);
        var factura = _repo.GetById(id);
        if (factura == null) return NotFound($"Factura con ID {id} no encontrada.");
        _mapper.Map(dto, factura);
        if (!_repo.Update(factura)) return StatusCode(500, "Error al actualizar la factura.");
        return NoContent();
    }

    [HttpDelete("{id:int}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public IActionResult Delete(int id)
    {
        if (!_repo.Delete(id)) return NotFound($"Factura con ID {id} no encontrada.");
        return NoContent();
    }
}
