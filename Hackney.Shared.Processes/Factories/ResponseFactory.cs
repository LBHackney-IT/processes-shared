using System.Collections.Generic;
using System.Linq;
using Hackney.Shared.Processes.Boundary.Response;
using Hackney.Shared.Processes.Domain;

namespace Hackney.Shared.Processes.Factories
{
    public static class ResponseFactory
    {
        public static ProcessResponse ToResponse(this Process domain)
        {
            if (domain == null) return null;
            return new ProcessResponse
            {
                Id = domain.Id,
                TargetId = domain.TargetId,
                TargetType = domain.TargetType,
                RelatedEntities = domain.RelatedEntities,
                ProcessName = domain.ProcessName,
                PatchAssignment = domain.PatchAssignment,
                CurrentState = domain.CurrentState,
                PreviousStates = domain.PreviousStates
            };
        }

        public static List<ProcessResponse> ToResponse(this IEnumerable<Process> domainList)
        {
            if (domainList is null) return new List<ProcessResponse>();

            return domainList.Select(domain => domain.ToResponse()).ToList();
        }
    }
}
