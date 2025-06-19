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
            ).ForMember(
                dest => dest.Availability,
                src => src.MapFrom(x =>
                    x.Workspaces.GroupBy(w => w.Capacity)
                        .Select(a => new WorkspaceTypeAvailability
                        {
                            WorkspaceCount = a.Count(),
                            Capacity = a.Key
                        }).ToArray())
            );
        }
    }
}
