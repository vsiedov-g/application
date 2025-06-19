using System;

namespace application.Models.DTO
{
    public class CoworkingAvailability
    {
        public required string WorkspaceType { get; set; }
        public int WorkspaceCount { get; set; }
    }
}
