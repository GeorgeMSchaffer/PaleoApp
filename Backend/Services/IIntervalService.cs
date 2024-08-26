namespace Backend.Services;
using Shared.Models;
public interface IIntervalService
{
    public List<IntervalDTO> GetIntervals();
    public IntervalDTO findIntervalByID(int id);
    public void UpdateInterval(IntervalDTO intervalDTO);
    public List<IntervalDTO> getIntervalsByType(String type);

}