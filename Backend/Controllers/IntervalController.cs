using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Shared.Models;
using Backend.Services;
using Shared.Data;
using Shared.POJO;
using Swagger
namespace Backend.Controllers
{
    [Route("api/v1/[controller]s")]
    [ApiController]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    [Produces("application/json")]
    public class IntervalController : ControllerBase
    {
        //private readonly ILogger _logger;
        private readonly AppDBContext _context;
        private readonly IntervalService _service;
        private readonly ILogger<IntervalController> _logger;
        //private readonly IMapper _mapper = MapperConfig.InitializeAutomapper();
        public IntervalController(AppDBContext context,IntervalService service,ILogger<IntervalController> logger)
        {
            _context = context;
            _service = service;
            _logger = logger;
           // _logger = logger;
        }

        [HttpGet("/api/v1/intervals/")]
        
        public async Task<ActionResult<List<IntervalDTO>>> GetIntervals([FromQuery] int skip = 0, [FromQuery] int limit = 10, [FromQuery] string? sortBy = "interval_no", [FromQuery] string? sortDir = "ASC")
        {
            Pagination pagination = new Pagination()
            {
                limit = limit,
                skip = skip,
                sortBy = sortBy,
                sortDir = sortDir
            };
            var intervalDTOs =  await _service.GetIntervals(pagination);
            if(intervalDTOs == null)
            {
                return NotFound();
            }
            return Ok(intervalDTOs);
        }
      

        [HttpGet("/occurrences/{intervalName}/")]
        
//      / <summary>
        /// Returns a list of fossil occurrences for a give interval name, ie. Carnian.
        /// </summary>
        /// <remarks>
        /// Here is a sample remarks placeholder.
        /// </remarks>
        /// <param name="intervalName">The name of a geologic interval, for example 'carnian' or 'permian' etc...</param>
        /// <param name="skip">The number of records to skip</param>
        /// <params name="limit">The number of records to return</params>
        /// <params name="sort">The field to sort by</params>
        /// <param name="sortDir"> The sort direction, either ASC or DESC, results will use ASC if no sortDir param is specified </param>  
        /// <returns>A list of fossil occurences</returns>
        /// <remarks>
        /// Sample Request
        /// GET /api/v1/interval/occurrences/carnian?skip=0&limit=10&sort=species&sortDir=ASC
        /// </remarks>
        ///<response code="200">Returns a list of fossil occurrences.</response>
        /// <response code="404">If the interval name is not found.</response>
        /// <response code="400">If the interval name is not provided.</response>
        /// <response code="500">If there is a server error/</response>
        public async Task<List<OccurrenceDTO>> getIntervalOccurrences([FromQuery] string intervalName="",[FromQuery] int skip = 0, [FromQuery] int limit = 10, [FromQuery] string sort = "interval_no", [FromQuery] string sortDir = "ASC")
        {
            if(intervalName == null || intervalName.Length == 0)
            {
                return new List<OccurrenceDTO>();
            }
            Pagination pagination = new Pagination()
            {
                limit = limit,
                skip = skip,
                sortBy = sort,
                sortDir = sortDir
            };
            var intervalDtos = await _service.getOccurrencesByIntervalName(intervalName,pagination);
            
            // if(intervalDTO.Count == 0)
            // {
            //     return NotFound();
            // }
            return intervalDtos;
        }
        // GET: api/Interval/5
        [HttpGet("{id}")]
        public async Task<ActionResult<IntervalDTO>> GetInterval(int id)
        {
            var intervalDTO = await _service.findIntervalByID(id);

            if (intervalDTO == null)
            {
                return NotFound();
            }
            return intervalDTO;
        }

        // PUT: api/Interval/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        async Task<IActionResult> PutInterval(int id, Interval interval)
        {
            if (id != interval.IntervalNo)
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

            return CreatedAtAction("GetInterval", new { id = interval.IntervalNo }, interval);
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
            return _context.Intervals.Any(e => e.IntervalNo == id);
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
