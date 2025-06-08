using System;
using application.Models;
using application.Models.DTO;

namespace application.Services.IService
{
    public interface IBookingService
    {
        public Task<Booking> CreateBookingAsync(BookingRequest req);
        public Task<Booking> UpdateBookingAsync(BookingRequest req);
        public Task<Workspace> FindAvailableWorkspace(BookingRequest req);
    }
}
