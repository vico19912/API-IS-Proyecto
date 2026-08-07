using ApiProyecto.Models;
using ApiProyecto.Models.Dto;
using ApiProyecto.Repository.IRepository;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace ApiProyecto.Controllers;

[Route("api/[controller]")]
[ApiController]
public class MedicamentoController : ControllerBase
{
    private readonly IMedicamentoRepository _repo;
    private readonly IMapper _mapper;
    public MedicamentoController(IMedicamentoRepository repo, IMapper mapper) =>
        (_repo, _mapper) = (repo, mapper);

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public IActionResult GetAll() =>
        Ok(_repo.GetAll().Select(m => _mapper.Map<MedicamentoDto>(m)));

    [HttpGet("{id:int}", Name = "GetMedicamentoById")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public IActionResult GetById(int id)
    {
        var med = _repo.GetById(id);
        if (med == null) return NotFound($"Medicamento con ID {id} no encontrado.");
        return Ok(_mapper.Map<MedicamentoDto>(med));
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public IActionResult Create([FromBody] CreateMedicamentoDto dto)
    {
        if (!ModelState.IsValid) return BadRequest(ModelState);
        var med = _mapper.Map<Medicamento>(dto);
        if (!_repo.Create(med)) return StatusCode(500, "Error al crear el medicamento.");
        return CreatedAtRoute("GetMedicamentoById", new { id = med.Id_Medicamento }, _mapper.Map<MedicamentoDto>(med));
    }

    [HttpPut("{id:int}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public IActionResult Update(int id, [FromBody] CreateMedicamentoDto dto)
    {
        if (!ModelState.IsValid) return BadRequest(ModelState);
        var med = _repo.GetById(id);
        if (med == null) return NotFound($"Medicamento con ID {id} no encontrado.");
        med.Descripcion = dto.Descripcion;
        med.Tipo_Medicamento_Id = dto.Tipo_Medicamento_Id;
        if (!_repo.Update(med)) return StatusCode(500, "Error al actualizar el medicamento.");
        return NoContent();
    }

    [HttpDelete("{id:int}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public IActionResult Delete(int id)
    {
        if (!_repo.Delete(id)) return NotFound($"Medicamento con ID {id} no encontrado.");
        return NoContent();
    }
}
