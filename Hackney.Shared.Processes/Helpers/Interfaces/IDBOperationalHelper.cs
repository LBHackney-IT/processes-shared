// using System;
// using System.Collections.Generic;
// using System.Threading.Tasks;
// using Hackney.Core.JWT;
// using Hackney.Shared.Processes.Domain;
//
// namespace Hackney.Shared.Processes.Helpers
// {
//     public interface IDbOperationsHelper
//     {
//         Task AddIncomingTenantToRelatedEntities(Dictionary<string, object> requestFormData, Process process);
//         Task<bool> CheckAutomatedEligibility(Guid tenureId, Guid proposedTenantId, Guid tenantId);
//         Task<(Guid, DateTime)> UpdateTenures(Process process, Token token, Dictionary<string, object> formData);
//         Task UpdatePerson(Process process, Token token);
//     }
// }