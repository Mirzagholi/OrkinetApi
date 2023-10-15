using System.Threading.Tasks;
using Core.Models.Parameter.Business.Value;
using Core.Models.ViewModel.Business.Value;

namespace Core.Data.Repository
{
    public partial class Repository
    {

        public async Task<AddValueVm> Sp_AddValue(AddValueParam parameters) => await _context.GetAsync<AddValueVm>
                (
                    "Business.sp_AddValue",
                    parameters
                );
    }
}
