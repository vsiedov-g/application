using System;
using System.ComponentModel.DataAnnotations;

namespace application.Models.DTO
{
    public class WorkspaceTypeDto
    {
        public int Id { get; set; }
        [Required]
        public required string Name { get; set; }
        public required string Description { get; set; }
        public string[]? Amenities { get; set; }
        public ICollection<WorkspaceDto>? Workspaces { get; set; }
        public string? ImageUrl { get; set; }
    }
}
