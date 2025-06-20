using System;
using System.ComponentModel.DataAnnotations;

namespace application.Models.DTO
{
    public class BaseBookingDto
    {
        public int Id { get; set;}
        [Required]
        public required string UserName { get; set; }
        [Required]
        [EmailAddress]
        public required string UserEmail { get; set; }
        [Range(1, int.MaxValue)]
        public int Capacity { get; set; }
        [Required]
        public DateOnly StartDate { get; set; }
        [Required]
        public DateOnly EndDate { get; set; }
        [Required]
        public TimeOnly StartTime { get; set; }
        [Required]
        public TimeOnly EndTime { get; set; }
    }
}
