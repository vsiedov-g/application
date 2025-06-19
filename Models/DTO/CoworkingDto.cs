using System;

namespace application.Models.DTO
{
    public class CoworkingDto
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public required string Description { get; set; }
        public required string Address { get; set; }
        public ICollection<CoworkingAvailability>? Availability { get; set; }
        public string? ImageUrl { get; set; }
    }
}
