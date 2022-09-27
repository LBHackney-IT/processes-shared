using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Hackney.Shared.Processes.Domain
{
    public class Process
    {
        public Guid Id { get; set; }
        public Guid TargetId { get; set; }
        public TargetType TargetType { get; set; }
        public List<RelatedEntity> RelatedEntities { get; set; }
        public ProcessName ProcessName { get; set; }
        public PatchAssignment PatchAssignment { get; set; }
        public ProcessState CurrentState { get; set; }
        public List<ProcessState> PreviousStates { get; set; }
        public int? VersionNumber { get; set; }

        public Process() { }

        public Process(Guid id, Guid targetId, TargetType targetType, List<RelatedEntity> relatedEntities, ProcessName processName, ProcessState currentState, List<ProcessState> previousStates, int? versionNumber, PatchAssignment patchAssignment)
        {
            Id = id;
            TargetId = targetId;
            TargetType = targetType;
            RelatedEntities = relatedEntities;
            ProcessName = processName;
            CurrentState = currentState;
            PreviousStates = previousStates;
            VersionNumber = versionNumber;
            PatchAssignment = patchAssignment;
        }

        public Task AddState(ProcessState updatedState)
        {
            if (CurrentState != null) PreviousStates.Add(CurrentState);
            CurrentState = updatedState;

            return Task.CompletedTask;
        }

        public static Process Create(Guid targetId, TargetType targetType, List<RelatedEntity> relatedEntities, ProcessName processName, PatchAssignment patchAssignment)
        {
            return new Process(Guid.NewGuid(), targetId, targetType, relatedEntities, processName, null, new List<ProcessState>(), null, patchAssignment);
        }

        public static Process Create(Guid targetId, TargetType targetType, List<RelatedEntity> relatedEntities, ProcessName processName)
        {
            return new Process(Guid.NewGuid(), targetId, targetType, relatedEntities, processName, null, new List<ProcessState>(), null, null);
        }
    }
}
