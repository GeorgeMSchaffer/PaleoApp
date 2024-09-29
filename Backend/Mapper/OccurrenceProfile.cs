namespace Backend.Mapper;
using AutoMapper;
using Shared.Models;
public class OccurrenceProfile : Profile
{
    public OccurrenceProfile()
    {
        CreateMap<Occurrence, OccurrenceDTO>();
        CreateMap<OccurrenceDTO, Occurrence>();

    }
}