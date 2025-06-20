using System;
using application.Models;
using application.Models.DTO;
using AutoMapper;

namespace application.AutoMapperProfiles
{
    public class BookingProfile : Profile
    {
        public BookingProfile()
        {
            CreateMap<BookingRequest, Booking>();

            CreateMap<Booking, BookingResponse>().ForMember(
                dest => dest.WorkspaceType, src => src.MapFrom(x => x.Workspace.WorkspaceType))
                .ForMember(
                dest => dest.Capacity, src => src.MapFrom(x => x.Workspace.Capacity))
                .ForMember(
                dest => dest.CoworkingId, src => src.MapFrom(x => x.Workspace.WorkspaceType.CoworkingSpace.Id))
                .ForMember(
                dest => dest.Coworking, src => src.MapFrom(x => x.Workspace.WorkspaceType.CoworkingSpace.Name));
        }
    }
}
