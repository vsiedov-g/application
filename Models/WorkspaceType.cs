using System;
using System.ComponentModel.DataAnnotations;

namespace application.Models
{
    public class WorkspaceType
    {
        public int Id { get; set; }
        [Required]
        public required string Name { get; set; }
        public required string Description { get; set; }
        public ICollection<Amenity>? Amenities { get; set; }
        public ICollection<Workspace>? Workspaces { get; set; }
        public string? ImageUrl { get; set; }
    }
}
