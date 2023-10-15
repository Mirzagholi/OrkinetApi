using System.Threading.Tasks;
using Core.Common.Base;
using Core.Common.ShareModels;
using Core.Models.Request.Business.Attribute;
using Core.Models.ViewModel.Business.Attribute;

namespace Core.ServiceContract.Business
{
    public interface IAttributeSrv : IInjectableService
    {

        Task<ServiceResult> AddAttributeAsync(AddAttributeRequest request);
        Task<ServiceResult> UpdateAttributeAsync(UpdateAttributeRequest request);
        Task<ServiceResult> UpdateAttributeStatusAsync(UpdateAttributeStatusRequest request);
        Task<GetAttributeByIdVm> GetAttributeByIdAsync(int id);
        Task<BasePagingResult<GetAttributeVm>> GetAttributeAsync(GetAttributeRequest request);

    }
}
