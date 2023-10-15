using System.Threading.Tasks;
using Core.Models.Parameter.Business.Cart;
using Core.Models.ViewModel.Business.Cart;

namespace Core.Data.Repository
{
    public partial class Repository
    {

        public async Task Sp_SetProviderCartStatus(SetProviderCartStatusParam parameters) => await _context.ExecuteAsync
                (
                    "Business.sp_SetProviderCartStatus",
                    parameters
                );
    }
}
