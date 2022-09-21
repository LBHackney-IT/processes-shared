using System;
using System.Collections.Generic;

namespace Hackney.Shared.Processes.Boundary.Request
{
    public class UpdateProcessRequestObject
    {
        public Dictionary<string, object> FormData { get; set; }
        public List<Guid> Documents { get; set; }
    }
}
