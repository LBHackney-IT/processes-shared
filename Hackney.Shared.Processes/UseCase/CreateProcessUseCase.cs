// using Hackney.Core.JWT;
// using Hackney.Core.Logging;
// using System;
// using System.Threading.Tasks;
// using Hackney.Shared.Processes.Boundary.Request;
// using Hackney.Shared.Processes.Constants;
// using Hackney.Shared.Processes.Domain;
// using Hackney.Shared.Processes.Gateways;
// using Hackney.Shared.Processes.Services.Interfaces;
// using Hackney.Shared.Processes.UseCase.Interfaces;
//
// namespace Hackney.Shared.Processes.UseCase
// {
//     public class CreateProcessUseCase : ICreateProcessUseCase
//     {
//         private readonly IProcessesGateway _processGateway;
//         private readonly Func<ProcessName, IProcessService> _processServiceProvider;
//
//         public CreateProcessUseCase(IProcessesGateway processGateway, Func<ProcessName, IProcessService> processServiceProvider)
//
//         {
//             _processGateway = processGateway;
//             _processServiceProvider = processServiceProvider;
//         }
//
//         [LogCall]
//         public async Task<Process> Execute(CreateProcess request, ProcessName processName, Token token)
//         {
//             var process = Process.Create(request.TargetId, request.TargetType, request.RelatedEntities, processName, request.PatchAssignmentEntity);
//
//             var triggerObject = ProcessTrigger.Create(process.Id, SharedPermittedTriggers.StartApplication, request.FormData, request.Documents);
//
//             IProcessService service = _processServiceProvider(processName);
//             await service.Process(triggerObject, process, token).ConfigureAwait(false);
//
//             await _processGateway.SaveProcess(process).ConfigureAwait(false);
//
//             return process;
//         }
//     }
// }