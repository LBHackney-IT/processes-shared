using System;
using Hackney.Shared.Processes.Domain;

namespace Hackney.Shared.Processes.Sns
{
    public class ProcessStartedAgainstEntityData
    {
        public Guid Id { get; set; }
        public ProcessName ProcessName { get; set; }
    }
}