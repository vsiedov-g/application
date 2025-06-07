using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace application.Models
{
    public class Booking
    {
        public int Id { get; set; }
        [Required]
        public required string UserName { get; set; }
        [Required]
        public required string UserEmail { get; set; }
        [Required]
        public int WorkspaceId { get; set; }
        [ForeignKey("WorkspaceId")]
        [ValidateNever]
        public Workspace? Workspace { get; set; }
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
