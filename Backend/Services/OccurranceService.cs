using Backend.Data;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;

namespace Backend.Services;
using Shared.Models;
using AutoMapper;
using Backend.Services;

public interface IOccurrenceService
{
    Task<IEnumerable<Occurrence>> GetAll();
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
    //private ILogger logger;
    public OccurrenceService(AppDBContext context,ILogger<OccurrenceService> logger)
    {
        _context = context;
        this._logger = (ILogger<OccurrenceService>?)logger;
    }

    public async Task<IEnumerable<Occurrence>> GetAll()
    {
        var occurrences = await _context.Occurrences.ToListAsync();
        //logger.LogInformation("Returning Occurrence with ID " + occurrences. + " occurrences");
        //var occurrenceDTOs = _mapper.Map<List<OccurrenceDTO>>(occurrences);

        return occurrences;
    }

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

    public async Task<List<Occurrence>> GetOccurrencesByIntervalName(object intervalName)
    {
        var occurrences = await _context.Occurrences.ToListAsync();
        
        return occurrences; 
    }
}
