// using Hackney.Core.JWT;
// using Hackney.Core.Sns;
// using System;
// using System.Collections.Generic;
// using Hackney.Shared.Processes.Domain;
// using Hackney.Shared.Processes.Infrastructure;
//
// namespace Hackney.Shared.Processes.Factories
// {
//     public interface ISnsFactory
//     {
//         EntityEventSns ProcessStarted(Process process, Token token);
//         EntityEventSns ProcessStartedAgainstEntity(Process process, Token token, string eventType);
//         EntityEventSns ProcessUpdated(Guid id, UpdateEntityResult<ProcessState> updateResult, Token token);
//         EntityEventSns ProcessStateUpdated(Stateless.StateMachine<string, string>.Transition transition, Dictionary<string, object> eventData, Token token, string eventType);
//     }
// }
