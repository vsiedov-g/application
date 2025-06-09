using System;
using System.ComponentModel.DataAnnotations;

namespace application.Models.DTO
{
    public class WorkspaceDto
    {
        public int Id { get; set; }
        [Required]
        public required string Name { get; set; }
        [Range(1, int.MaxValue)]
        public int Capacity { get; set; }
    }
}
