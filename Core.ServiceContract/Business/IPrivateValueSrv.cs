using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Common.Base;
using Core.Common.ShareModels;
using Core.Models.Request.Business.PrivateValue;
using Core.Models.ViewModel.Business.PrivateValue;

namespace Core.ServiceContract.Business
{
    public interface IPrivateValueSrv : IInjectableService
    {

        Task<ServiceResult> AddPrivateValueAsync(AddPrivateValueRequest request);
        Task<BasePagingResult<GetPrivateValueVm>> GetPrivateValueAsync(GetPrivateValueRequest request);
        Task<ServiceResult> UpdatePrivateValueAsync(UpdatePrivateValueRequest request);
        Task<ServiceResult> UpdatePrivateValueStatusAsync(UpdatePrivateValueStatusRequest request);
        Task<IEnumerable<GetCompletePrivateValueDropDownVm>> GetCompletePrivateValueDropDownAsync
            (GetCompletePrivateValueRequest request);
    }
}
