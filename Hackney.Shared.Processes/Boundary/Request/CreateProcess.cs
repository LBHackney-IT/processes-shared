using Hackney.Shared.Processes.Domain;
using System;
using System.Collections.Generic;

namespace Hackney.Shared.Processes.Boundary.Request
{
    public class CreateProcess
    {
        public Guid TargetId { get; set; }
        public TargetType TargetType { get; set; }
        public List<RelatedEntity> RelatedEntities { get; set; }
        public Dictionary<string, object> FormData { get; set; }
        public List<Guid> Documents { get; set; }
    }
}
