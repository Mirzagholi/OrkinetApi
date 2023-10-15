using System.Threading.Tasks;
using Core.Common.Base;
using Core.Common.ShareModels;
using Core.Models.Request.Business.WebSiteFile;
using Core.Models.ViewModel.Business.WebSiteFile;

namespace Core.ServiceContract.Business
{
    public interface IWebSiteFileSrv : IInjectableService
    {
        Task<ServiceResult> AddWebSiteFileAsync(AddWebSiteFileRequest request);
        Task<BasePagingResult<GetAllWebSiteFileVm>> GetAllWebSiteFileAsync(GetAllWebSiteFileRequest request);
        Task<ServiceResult> DeleteWebSiteFileAsync(DeleteWebSiteFileRequest request);
    }
}
