// using System;
// using System.Threading.Tasks;
// using Hackney.Shared.Processes.Infrastructure;
// using Hackney.Shared.Tenure.Boundary.Requests;
// using Hackney.Shared.Tenure.Domain;
// using Hackney.Shared.Tenure.Infrastructure;
//
// namespace Hackney.Shared.Processes.Gateways
// {
//     public interface ITenureDbGateway
//     {
//         Task<TenureInformation> GetTenureById(Guid id);
//         Task<UpdateEntityResult<TenureInformationDb>> UpdateTenureById(Guid id, EditTenureDetailsRequestObject updateTenureRequest);
//         Task<TenureInformationDb> PostNewTenureAsync(CreateTenureRequestObject createTenureRequestObject);
//     }
// }
