using System.Threading.Tasks;
using Core.Models.Parameter.Business.Product;
using Core.Models.ViewModel.Business.Product;

namespace Core.Data.Repository
{
    public partial class Repository
    {

        public async Task Sp_ConfirmProduct(ConfirmProductParam parameters) => await _context.ExecuteAsync
                (
                    "Business.sp_ConfirmProduct",
                    parameters
                );
    }
}
