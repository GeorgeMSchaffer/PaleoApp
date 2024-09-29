using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Backend;
using Backend.Services;
using Shared.Models;

namespace Backend.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class OccurrencesController : ControllerBase
    {
        private readonly OccurrenceService _occurrenceService;

        public OccurrencesController(OccurrenceService occurrenceService)
        {
            _occurrenceService = occurrenceService;
        }

        // GET: api/Occurrences
        [HttpGet]
        public async Task<ActionResult<IEnumerable<OccurrenceDTO>>> GetOccurrences()
        {
            return Ok(await _occurrenceService.GetAll());
        }

        // GET: api/Occurrences/5
        [HttpGet("{id}")]
        public async Task<ActionResult<OccurrenceDTO>> GetOccurrence(int id)
        {
            var occurrence = await _occurrenceService.Get(id);

            if (occurrence == null)
            {
                return NotFound();
            }

            return Ok(occurrence);
        }
        
        
        [HttpGet("interval/{intervalName}")]
        public async Task<ActionResult<List<Occurrence>>> GetOccurrencesByIntervalName(String intervalName) {
            if (intervalName == null || intervalName.Length == 0)
            {
                return BadRequest("Interval name is required");
            }
            
            var occurrences =  await _occurrenceService.GetOccurrencesByIntervalName(intervalName);
            return Ok(occurrences);
        }

        // PUT: api/Occurrences/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutOccurrence(int id, OccurrenceDTO occurrenceDTO)
        {
            if (id != occurrenceDTO.OccurrenceNo)
            {
                return BadRequest();
            }

            await _occurrenceService.Update(occurrenceDTO);

            return NoContent();
        }

        // POST: api/Occurrences
        [HttpPost]
        public async Task<ActionResult<OccurrenceDTO>> PostOccurrence(OccurrenceDTO occurrenceDTO)
        {
            var createdOccurrence = await _occurrenceService.Add(occurrenceDTO);

            return CreatedAtAction("GetOccurrence", new { id = createdOccurrence.OccurrenceNo }, createdOccurrence);
        }

        // DELETE: api/Occurrences/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOccurrence(int id)
        {
            var result = await _occurrenceService.Delete(id);

            if (!result)
                return NotFound();

            return NoContent();
        }
    }
}
