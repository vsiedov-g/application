using System;

namespace application.Models
{
    public class Coworking
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public required string Address { get; set; }
        public ICollection<WorkspaceType>? WorkspaceTypes { get; set; }
        public string? ImageUrl { get; set; }
    }
}
