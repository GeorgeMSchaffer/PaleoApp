namespace Backend.Controllers;
using Microsoft.AspNetCore.Mvc;
using Shared.Models;
using Backend.Services;
using Shared.Data;
using Microsoft.EntityFrameworkCore;

[Route("api/v1/[controller]s")]
[ApiController]
public class TaxaController : ControllerBase
{
    private readonly TaxaService _service;

    public TaxaController(TaxaService service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        return Ok(await _service.GetAll());
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        return Ok(await _service.Get(id));
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] Taxa taxon)
    {
        return Ok(await _service.Create(taxon));
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, [FromBody] Taxa taxon)
    {
        if (id != taxon.TaxonNo)
        {
            return BadRequest();
        }

        await _service.Update(id, taxon);

        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        await _service.Delete(id);
        return NoContent();
    }
}