using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Common.ShareModels;
using Core.Models.Request.Business.ProviderContact;
using Core.Models.ViewModel.Business.ProviderContact;

namespace Core.ServiceContract.Business
{
    public interface IProviderContactSrv : IInjectableService
    {
        Task<ServiceResult> AddProviderContactAsync(AddProviderContactRequest request);
        Task<IEnumerable<GetProviderContactVm>> GetProviderContactAsync();
        Task<ServiceResult> DeleteProviderContactAsync(DeleteProviderContactRequest request);
    }
}
