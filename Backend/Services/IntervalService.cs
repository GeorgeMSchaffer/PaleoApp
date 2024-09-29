using AutoMapper;

namespace Backend.Services;
using Shared.Models;
using Backend.Data;

public interface IIntervalService
{
    public List<Interval> GetIntervals();
    public Task<IntervalDTO> findIntervalByID(int id);
    public void UpdateInterval(IntervalDTO intervalDTO);
    public List<IntervalDTO> getIntervalsByType(String type);

}
public class IntervalService : IIntervalService{
    private AppDBContext _context;
    private IMapper _mapper;
    private ILogger<IntervalService> _logger;
    
    public IntervalService(AppDBContext context,ILogger<IntervalService> logger)
    {
        this._context = context;
        this._logger = logger;
    }
    
    public  List<Interval> GetIntervals()
    {
        var intervals =  _context.Intervals.ToList();
        if (intervals ==  null)
        {
            return new List<Interval>();
        }
        //var intervalDTOs = _mapper.Map<List<IntervalDTO>>(intervals);
        return intervals;
    }
    public async Task<IntervalDTO> findIntervalByID(int id)
    {
        var interval = _context.Intervals.Find(id);
        var intervalDTO = _mapper.Map<IntervalDTO>(interval);
        return intervalDTO;
    }
    public void AddInterval(IntervalDTO intervalDTO)
    {
        var interval = _mapper.Map<Interval>(intervalDTO);
        _context.Intervals.Add(interval);
        _context.SaveChanges();
    }
    public void UpdateInterval(IntervalDTO intervalDTO)
    {
        var interval = _mapper.Map<Interval>(intervalDTO);
        _context.Intervals.Update(interval);
        _context.SaveChanges();
    }
    public void DeleteInterval(int id)
    {
        var interval = _context.Intervals.Find(id);
        _context.Intervals.Remove(interval);
        _context.SaveChanges();
    }
    public List<IntervalDTO> getIntervalsByType(String type)
    {
        var intervals = _context.Intervals.Where(i => i.RecordType == type).ToList();
        var intervalDTOs = _mapper.Map<List<IntervalDTO>>(intervals);
        return intervalDTOs;
    }
    
}