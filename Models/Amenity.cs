using System;
using System.ComponentModel.DataAnnotations;

namespace application.Models
{
    public class Amenity
    {
        public int Id { get; set; }
        [Required]
        public required string Name { get; set; }
        public ICollection<WorkspaceType>? WorkspaceTypes { get; set; }
    }
}
