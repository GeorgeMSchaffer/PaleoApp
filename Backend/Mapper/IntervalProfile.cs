namespace Backend.Mapper;
using AutoMapper;
using Shared.Models;
public class IntervalProfile : Profile
{
    public IntervalProfile()
    {
        CreateMap<Interval, IntervalDTO>();
        CreateMap<IntervalDTO, Interval>();

    }
}