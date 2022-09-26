using Microsoft.AspNetCore.Mvc;
using Hackney.Shared.Processes.Domain;
using System;

namespace Hackney.Shared.Processes.Boundary.Request
{
    public class ProcessQuery
    {
        [FromRoute(Name = "processName")]
        public ProcessName ProcessName { get; set; }
        [FromRoute(Name = "id")]
        public Guid Id { get; set; }
    }
}
