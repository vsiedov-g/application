using System;
using application.Models;
using application.Models.DTO;
using AutoMapper;

namespace application.AutoMapperProfiles
{
    public class CoworkingProfile : Profile
    {
        public CoworkingProfile()
        {
            CreateMap<Coworking, CoworkingDto>().ForMember(
                dest => dest.Availability, src => src.MapFrom(x => x.WorkspaceTypes));
                
            CreateMap<WorkspaceType, CoworkingAvailability>().ForMember(
                dest => dest.WorkspaceType, src => src.MapFrom(x => x.Name)
            ).ForMember(
                dest => dest.WorkspaceCount, src => src.MapFrom(x => x.Workspaces.Count())
            );
        }
    }
}
