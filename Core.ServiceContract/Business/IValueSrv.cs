using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Common.Base;
using Core.Common.ShareModels;
using Core.Models.Request.Business.Value;
using Core.Models.ViewModel.Business.Value;

namespace Core.ServiceContract.Business
{
    public interface IValueSrv : IInjectableService
    {

        Task<ServiceResult> AddValueAsync(AddValueRequest request);
        Task<ServiceResult> UpdateValueAsync(UpdateValueRequest request);
        Task<ServiceResult> UpdateValueStatusAsync(UpdateValueStatusRequest request);
        Task<GetValueByIdVm> GetValueByIdAsync(int id);
        Task<BasePagingResult<GetValueVm>> GetValueAsync(GetValueRequest request);
        Task<IEnumerable<GetCompleteValueDropDownVm>> GetCompleteValueDropDownAsync();

    }
}
