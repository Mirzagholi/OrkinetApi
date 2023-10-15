using System.Threading.Tasks;
using Core.Models.Parameter.Business.Favorite;
using Core.Models.ViewModel.Business.Favorite;

namespace Core.Data.Repository
{
    public partial class Repository
    {

        public async Task<AddFavoriteVm> Sp_AddFavorite(AddFavoriteParam parameters) => await _context.GetAsync<AddFavoriteVm>
                (
                    "Business.sp_AddFavorite",
                    parameters
                );
    }
}
