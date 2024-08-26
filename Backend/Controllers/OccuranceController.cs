using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Backend;
using Shared.Models;

namespace Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OccuranceController : ControllerBase
    {
        private readonly AppDBContext _context;

        public OccuranceController(AppDBContext context)
        {
            _context = context;
        }

        // GET: api/Occurance
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Occurance>>> GetOccurances()
        {
            return await _context.Occurances.ToListAsync();
        }

        // GET: api/Occurance/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Occurance>> GetOccurance(int id)
        {
            var occurance = await _context.Occurances.FindAsync(id);

            if (occurance == null)
            {
                return NotFound();
            }

            return occurance;
        }

        // PUT: api/Occurance/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutOccurance(int id, Occurance occurance)
        {
            if (id != occurance.id)
            {
                return BadRequest();
            }

            _context.Entry(occurance).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OccuranceExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Occurance
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Occurance>> PostOccurance(Occurance occurance)
        {
            _context.Occurances.Add(occurance);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetOccurance", new { id = occurance.id }, occurance);
        }

        // DELETE: api/Occurance/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOccurance(int id)
        {
            var occurance = await _context.Occurances.FindAsync(id);
            if (occurance == null)
            {
                return NotFound();
            }

            _context.Occurances.Remove(occurance);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool OccuranceExists(int id)
        {
            return _context.Occurances.Any(e => e.id == id);
        }
    }
}
