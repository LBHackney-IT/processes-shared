using System;

namespace Hackney.Shared.Processes.Domain
{
    public class PatchAssignment
    {
        public Guid PatchId { get; set; }
        public string PatchName { get; set; }
        public Guid ResponsibleEntityId { get; set; }
        public string ResponsibleName { get; set; }
    }
}