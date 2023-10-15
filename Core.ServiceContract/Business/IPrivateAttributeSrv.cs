using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Common.Base;
using Core.Common.ShareModels;
using Core.Models.Request.Business.PrivateAttribute;
using Core.Models.ViewModel.Business.PrivateAttribute;

namespace Core.ServiceContract.Business
{
    public interface IPrivateAttributeSrv : IInjectableService
    {

        Task<ServiceResult> AddPrivateAttributeAsync(AddPrivateAttributeRequest request);
        Task<BasePagingResult<GetPrivateAttributeVm>> GetPrivateAttributeAsync(GetPrivateAttributeRequest request);
        Task<ServiceResult> UpdatePrivateAttributeAsync(UpdatePrivateAttributeRequest request);
        Task<ServiceResult> UpdatePrivateAttributeStatusAsync(UpdatePrivateAttributeStatusRequest request);
        Task<IEnumerable<GetPrivateAttributeDropDownVm>> GetPrivateAttributeDropDownAsync();
    }
}
