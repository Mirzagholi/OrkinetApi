using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Common.Base;
using Core.Common.ShareModels;
using Core.Models.Request.Business.Favorite;
using Core.Models.ViewModel.Business.Favorite;

namespace Core.ServiceContract.Business
{
    public interface IFavoriteSrv : IInjectableService
    {
        Task<ServiceResult> AddFavoriteSAsync(AddFavoriteRequest request);
        Task<ServiceResult> DeleteFavoriteSAsync(DeleteFavoriteRequest request);
        Task<BasePagingResult<GetAllFavoriteUiVm>> GetAllFavoriteUiAsync(GetAllFavoriteUiRequest request);
    }
}
