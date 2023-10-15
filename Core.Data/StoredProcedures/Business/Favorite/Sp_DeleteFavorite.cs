using System.Threading.Tasks;
using Core.Models.Parameter.Business.Favorite;
using Core.Models.ViewModel.Business.Favorite;

namespace Core.Data.Repository
{
    public partial class Repository
    {

        public async Task<DeleteFavoriteVm> Sp_DeleteFavorite(DeleteFavoriteParam parameters) => await _context.GetAsync<DeleteFavoriteVm>
                (
                    "Business.sp_DeleteFavorite",
                    parameters
                );
    }
}
