using System;
using System.ComponentModel.DataAnnotations;

namespace application.Models.DTO
{
    public class WorkspaceDto
    {
        public int Id { get; set; }
        [Required]
        [Range(1, int.MaxValue)]
        public int Capacity { get; set; }
    }
}
