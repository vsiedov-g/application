using System;
using System.ComponentModel.DataAnnotations;

namespace application.Models.DTO
{
    public class BookingRequest : BaseBookingDto
    {
        [Required]
        public int WorkspaceTypeId { get; set; }
        [Required]
        public int CoworkingSpaceId { get; set; }
    }
}
