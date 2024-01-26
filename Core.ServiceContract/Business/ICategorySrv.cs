using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Common.ShareModels;
using Core.Models.Request.Business.Category;
using Core.Models.Request.Business.Product;
using Core.Models.ViewModel.Business.Category;

namespace Core.ServiceContract.Business
{
    public interface ICategorySrv : IInjectableService
    {

        Task<ServiceResult> AddCategoryAsync(AddCategoryRequest request);
        Task<ServiceResult> UpdateCategoryAsync(UpdateCategoryRequest request);
        Task<ServiceResult> UpdateCategoryStatusAsync(UpdateCategoryStatusRequest request);
        Task<GetCategoryByIdVm> GetCategoryByIdAsync(int id);
        Task<IEnumerable<GetCategoryVm>> GetCategoryAsync();
        Task<IEnumerable<GetCategoryVm>> GetCategoryInFirstPageAsync(GetFirstPageCategoryUiRequest request);

        Task<IEnumerable<GetCategoryDropDownVm>> GetCategoryDropDownAsync();
    }
}
