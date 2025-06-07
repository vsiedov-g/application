using System;
using System.ComponentModel.DataAnnotations;

namespace application.Models
{
    public class WorkspaceType
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public required string Name { get; set; }
        public ICollection<Amenity>? Amenities { get; set; }
        public ICollection<Workspace>? Workspaces{ get; set; }
    }
}
