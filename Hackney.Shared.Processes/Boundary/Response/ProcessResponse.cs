// using System;
// using System.Collections.Generic;
// using Hackney.Shared.Processes.Domain;
//
// namespace Hackney.Shared.Processes.Boundary.Response
// {
//     public class ProcessResponse
//     {
//         public Guid Id { get; set; }
//         public Guid TargetId { get; set; }
//         public TargetType TargetType { get; set; }
//         public List<RelatedEntity> RelatedEntities { get; set; }
//         public PatchAssignmentEntity PatchAssignmentEntity { get; set; }
//         public ProcessName ProcessName { get; set; }
//         public ProcessState CurrentState { get; set; }
//         public List<ProcessState> PreviousStates { get; set; }
//     }
// }