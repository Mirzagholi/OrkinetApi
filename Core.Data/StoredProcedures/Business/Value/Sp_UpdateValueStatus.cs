using System.Threading.Tasks;
using Core.Models.Parameter.Business.Value;
using Core.Models.ViewModel.Business.Value;

namespace Core.Data.Repository
{
    public partial class Repository
    {

        public async Task<UpdateValueStatusVm> Sp_UpdateValueStatus(UpdateValueStatusParam parameters) => await _context.GetAsync<UpdateValueStatusVm>
                (
                    "Business.sp_UpdateValueStatus",
                    parameters
                );
    }
}
