
using System;
using System.Collections.Generic;

namespace Hackney.Shared.Processes.Sns
{
    public class ProcessStateChangeData
    {
        public string State { get; set; }
        public Dictionary<string, object> StateData { get; set; }
        public DateTime StateStartedAt { get; set; }
    }
}