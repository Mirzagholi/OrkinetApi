using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Common.Base;
using Core.Common.ShareModels;
using Core.Models.Request.Business.Blog;
using Core.Models.ViewModel.Business.Blog;

namespace Core.ServiceContract.Business
{
    public interface IBlogSrv : IInjectableService
    {

        Task<ServiceResult> AddBlogAsync(AddBlogRequest request);
        Task<ServiceResult> UpdateBlogAsync(UpdateBlogRequest request);
        Task<ServiceResult> DeleteBlogAsync(DeleteBlogRequest request);
        Task<BasePagingResult<GetAllBlogVm>> GetAllBlogAsync(GetAllBlogRequest request);
        Task<IEnumerable<GetAllBlogUiVm>> GetAllBlogUiAsync();
        Task<GetAllBlogInfoUiVm> GetAllBlogInfoUiAsync(int id);

    }
}
