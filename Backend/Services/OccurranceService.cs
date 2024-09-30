using Backend.Data;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;

namespace Backend.Services;
using Shared.Models;
using AutoMapper;
using Backend.Services;

public interface IOccurrenceService
{
    List<OccurrenceDTO> GetAll();
    Task<OccurrenceDTO> Get(int id);
    Task<OccurrenceDTO> Add(OccurrenceDTO occurrence);
    Task<Occurrence?> Update(OccurrenceDTO occurrence);
    Task<bool> Delete(int id);
}

public class OccurrenceService : IOccurrenceService
{
    // Assuming there is a DbContext instance
    private readonly AppDBContext _context;
    private readonly ILogger<OccurrenceService> _logger;
    private readonly IMapper _mapper;
    private readonly MapperConfiguration config = new MapperConfiguration(cfg =>
    { 
        cfg.CreateMap<Occurrence, OccurrenceDTO>();
        cfg.CreateMap<OccurrenceDTO, Occurrence>();
    }); 

    //private ILogger logger;
    public OccurrenceService(AppDBContext context,ILogger<OccurrenceService> logger,IMapper _mapper)
    {
        this._context = context;
        this._logger = (ILogger<OccurrenceService>?)logger;
        this._mapper = _mapper;
    }

    public  List<OccurrenceDTO> GetAll()
    {
            var occurrences =  _context.Occurrences.ToList();
            _logger.LogInformation("Returning Occurrence  " + occurrences.Count + " occurrences");
        //logger.LogInformation("Returning Occurrence with ID " + occurrences. + " occurrences");
        var mapper = new Mapper(config);
        
        var occurrenceDTOs = mapper.Map<List<OccurrenceDTO>>(occurrences);
        _logger.LogInformation("Returning Occurrence  " + occurrenceDTOs.Count + " occurrence DTOs");
        var occurrenceJsonDTOs = mapper.Map<List<OccurrenceDTO>>(occurrences);
        return occurrenceJsonDTOs;
    }

    public object OccurrenceJsonDTO { get; set; }

    public async Task<OccurrenceDTO> Get(int id)
    {
        var occurrence = await _context.Occurrences.FindAsync(id);
        if (occurrence == null)
        {
            return null;
        }
        var occurrenceDTOs = _mapper.Map<OccurrenceDTO>(occurrence);

        return occurrenceDTOs;
    }

    public async Task<OccurrenceDTO> Add(OccurrenceDTO occurrenceDTO)
    {
        
        var occurrence = new Occurrence
        {
            // Map OccurrenceDTO properties to Occurrence 
        };

        _context.Occurrences.Add(occurrence);
        await _context.SaveChangesAsync();
        occurrence.OccurrenceNo = occurrence.OccurrenceNo;
        var occurrenceDTOtoReturn = _mapper.Map<OccurrenceDTO>(occurrence);

        return occurrenceDTOtoReturn;
    }

    public async Task<Occurrence?> Update(OccurrenceDTO occurrence)
    {
        Occurrence? occurrenceDto = await _context.Occurrences.FindAsync(occurrence.OccurrenceNo);
        

        // Map OccurrenceDTO properties to Occurrence 
        _context.Update(occurrenceDto);
        await _context.SaveChangesAsync();
        return occurrenceDto;
    }

    public async Task<bool> Delete(int id)
    {
        var occurrence = await _context.Occurrences.FindAsync(id);
        if (occurrence == null)
        {
            return false;
        }

        _context.Remove(occurrence);
        await _context.SaveChangesAsync();
        return true;
    }

    public async Task<List<OccurrenceDTO>> GetOccurrencesByIntervalName(object intervalName)
    {
        
        var interval = await _context.Intervals.Where(i=>i.IntervalName == intervalName).FirstOrDefaultAsync();
        if(interval == null)
        {
            return new List<OccurrenceDTO>();
        }

        //[TODO:] We could check if the interval being matched has chidlren intervals then if someone searches for Permian it would include any 
        var occurrences = await _context.Occurrences.Where(o => o.EarlyIntervalNo == interval.IntervalNo || o.LateIntervalNo == interval.IntervalNo).ToListAsync();
        _logger.LogInformation("Returning Occurrence  " + occurrences.Count + " occurrences");
        var occurrenceDTOtoReturn = _mapper.Map<List<OccurrenceDTO>>(occurrences);

        return occurrenceDTOtoReturn; 
    }
}
