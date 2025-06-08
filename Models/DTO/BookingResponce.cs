using System;

namespace application.Models.DTO
{
    public class BookingResponce : BaseBookingDto
    {
        public required string WorkspaceType { get; set; }
    }
}
