using System;

namespace application.Models.DTO
{
    public class BookingResponse : BaseBookingDto
    {
        public required WorkspaceTypeDto WorkspaceType { get; set; }
        public int CoworkingId { get; set; }
        public required string Coworking { get; set; }
    }
}
