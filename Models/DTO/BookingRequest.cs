using System;
using System.ComponentModel.DataAnnotations;

namespace application.Models.DTO
{
    public class BookingRequest : BaseBookingDto
    {   
        public int WorkspaceTypeId { get; set; }
        public int Capacity { get; set; }
    }
}
