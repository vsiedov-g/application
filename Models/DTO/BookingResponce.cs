using System;

namespace application.Models.DTO
{
    public class BookingResponce : BaseBookingDto
    {
        public required WorkspaceTypeDto WorkspaceType { get; set; }
        public required string CoworkingSpace { get; set; }
    }
}
