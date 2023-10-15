using System.Threading.Tasks;
using Core.Common.Base;
using Core.Models.Parameter.Business.Favorite;
using Core.Models.ViewModel.Business.Favorite;

namespace Core.Data.Repository
{
    public partial class Repository
    {
        public async Task<BasePagingResult<GetAllFavoriteUiVm>> Sp_GetAllFavoriteUi(GetAllFavoriteUiParam parameters) => await _context.GetManyWithPagingAsync<GetAllFavoriteUiVm>
            (
                "Business.sp_GetAllFavoriteUi",
                parameters
            );

    }

}
