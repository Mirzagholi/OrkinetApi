using System.Threading.Tasks;
using Core.Models.Parameter.Business.Rating;

namespace Core.Data.Repository
{
    public partial class Repository
    {
        public async Task Sp_UpdateProviderRating(UpdateProviderRatingParam parameters) => await _context.ExecuteAsync
                (
                    "Business.sp_UpdateProviderRating",
                    parameters
                );
    }
}
