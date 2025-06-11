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

            CreateMap<Booking, BookingResponce>().ForMember(
                dest => dest.WorkspaceType, src => src.MapFrom(x => x.Workspace.WorkspaceType))
                .ForMember(
                dest => dest.Capacity, src => src.MapFrom(x => x.Workspace.Capacity));
        }
    }
}
