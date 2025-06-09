using System;
using application.Models;
using application.Models.DTO;
using AutoMapper;

namespace application.AutoMapperProfiles
{
    public class WorkspaceTypeProfile : Profile
    {
        public WorkspaceTypeProfile()
        {
            CreateMap<WorkspaceType, WorkspaceTypeDto>().ForMember(
                dest => dest.Amenities, src => src.MapFrom(x => x.Amenities.Select(a => a.Name).ToArray())
            );
        }
    }
}
