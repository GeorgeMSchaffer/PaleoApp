using AutoMapper;

namespace Backend.Services;
using Shared.Models;
using Backend;
public class IntervalService : IIntervalService{
    private AppDBContext context;
    private IMapper mapper;
    
    public IntervalService(AppDBContext context)
    {
        this.context = context;
    }
    
    public List<IntervalDTO> GetIntervals()
    {
        var intervals = context.Intervals.ToList();
        var intervalDTOs = mapper.Map<List<IntervalDTO>>(intervals);
        return intervalDTOs;
    }
    public IntervalDTO findIntervalByID(int id)
    {
        var interval = context.Intervals.Find(id);
        var intervalDTO = mapper.Map<IntervalDTO>(interval);
        return intervalDTO;
    }
    public void AddInterval(IntervalDTO intervalDTO)
    {
        var interval = mapper.Map<Interval>(intervalDTO);
        context.Intervals.Add(interval);
        context.SaveChanges();
    }
    public void UpdateInterval(IntervalDTO intervalDTO)
    {
        var interval = mapper.Map<Interval>(intervalDTO);
        context.Intervals.Update(interval);
        context.SaveChanges();
    }
    public void DeleteInterval(int id)
    {
        var interval = context.Intervals.Find(id);
        context.Intervals.Remove(interval);
        context.SaveChanges();
    }
    public List<IntervalDTO> getIntervalsByType(String type)
    {
        var intervals = context.Intervals.Where(i => i.type == type).ToList();
        var intervalDTOs = mapper.Map<List<IntervalDTO>>(intervals);
        return intervalDTOs;
    }
    
}