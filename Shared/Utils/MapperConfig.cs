namespace Shared.Utils;
using AutoMapper;
using Shared.Models;
public class MapperConfig
{
    public static Mapper InitializeAutomapper()
    {
        //Provide all the Mapping Configuration
        var config = new MapperConfiguration(cfg =>
        {
            //Configuring Employee and EmployeeDTO
            cfg.CreateMap<Interval, IntervalDTO>();
            cfg.CreateMap<Occurance, OccuranceDTO>();
            //Any Other Mapping Configuration ....
        });
        //Create an Instance of Mapper and return that Instance
        var mapper = new Mapper(config);
        return mapper;
    }
}