using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace application.Models
{
    public class WorkspaceType
    {
        public int Id { get; set; }
        [Required]
        public required string Name { get; set; }
        public required string Description { get; set; }
        public int CoworkingId { get; set; }
        [ForeignKey("CoworkingId")]
        [ValidateNever]
        public Coworking? CoworkingSpace { get; set; }
        public ICollection<Amenity>? Amenities { get; set; }
        public ICollection<Workspace>? Workspaces { get; set; }
        public string? ImageUrl { get; set; }
    }
}
