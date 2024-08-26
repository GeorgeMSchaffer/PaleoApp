using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Backend;
using Shared.Models;
using AutoMapper;
using Backend.Services;
using Shared.Utils;
namespace Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IntervalController : ControllerBase
    {
        private readonly AppDBContext _context;
        private readonly IntervalService _service;
        private readonly IMapper _mapper = MapperConfig.InitializeAutomapper();
        public IntervalController(AppDBContext context,IntervalService service)
        {
            _context = context;
            _service = service;
        }

        // GET: api/Interval
        [HttpGet]
        public async Task<ActionResult<IEnumerable<IntervalDTO>>> GetIntervals()
        {
            var intervals = await _context.Intervals.ToListAsync();
            var intervalDTOs = _mapper.Map<List<IntervalDTO>>(intervals);
            return intervalDTOs;
        }

        // GET: api/Interval/5
        [HttpGet("{id}")]
        public async Task<ActionResult<IntervalDTO>> GetInterval(int id)
        {
            var interval = await _context.Intervals.FindAsync(id);

            if (interval == null)
            {
                return NotFound();
            }
            var intervalDTO = _mapper.Map<IntervalDTO>(interval);

            return intervalDTO;
        }

        // PUT: api/Interval/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutInterval(int id, Interval interval)
        {
            if (id != interval.id)
            {
                return BadRequest();
            }

            _context.Entry(interval).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!IntervalExists(id))
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

        // POST: api/Interval
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<IntervalDTO>> PostInterval(Interval interval)
        {
            _context.Intervals.Add(interval);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetInterval", new { id = interval.id }, interval);
        }

        // DELETE: api/Interval/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteInterval(int id)
        {
            var interval = await _context.Intervals.FindAsync(id);
            if (interval == null)
            {
                return NotFound();
            }

            _context.Intervals.Remove(interval);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool IntervalExists(int id)
        {
            return _context.Intervals.Any(e => e.id == id);
        }
        [HttpGet("/eras/")]
        public async Task<IActionResult> getEras()
        {
            var items = _service.getIntervalsByType("era"); //_context.Intervals.Where(i => i.type == "era");
            return Ok(items);
            return NoContent();
        }
        [HttpGet("/eons/")]
        public async Task<IActionResult> getEons()
        {
            var items = _service.getIntervalsByType("eon");
            //var items = _context.Intervals.Where(i => i.type == "eon");
            return Ok(items);
        }
        [HttpGet("/ages/")]
        public async Task<IActionResult> getAges()
        {
            var items = _service.getIntervalsByType("age");
            //var items = _context.Intervals.Where(i => i.type == "ages");
            return Ok(items);
        }
        [HttpGet("/epochs/")]
        public async Task<IActionResult> getEpochs()
        {
            var items = _service.getIntervalsByType("epoch");
            //var items = _context.Intervals.Where(i => i.type == "epoch");
            return Ok(items);
        }
        [HttpGet("/periods/")]
        public async Task<IActionResult> getPeriods()
        {
            var items = _service.getIntervalsByType("period");
            return Ok(items);
        }
        // [HttpGet("/byAge/{yearsMYA}")]
        // public async Task<IActionResult> getIntervalByMYA(int yearsMYA)
        // {
        //     var items = _context.Intervals.Where(i => i. > yearsMYA && i.startAgeMYA < yearsMYA);
        //     return Ok(items);
        // }
    }
}
