using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace application.Models
{
    public class Workspace
    {
        public int Id { get; set; }
        [Required]
        [Range(1, int.MaxValue)]
        public int Capacity { get; set; }
        [Required]
        public int WorkspaceTypeId { get; set; }
        [ForeignKey("WorkspaceTypeId")]
        [ValidateNever]
        public WorkspaceType? WorkspaceType { get; set; } 
        public ICollection<Booking>? Bookings { get; set; }
    }
}
