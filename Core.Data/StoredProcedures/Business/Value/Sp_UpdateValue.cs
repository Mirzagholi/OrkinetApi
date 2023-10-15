using System.Threading.Tasks;
using Core.Models.Parameter.Business.Value;
using Core.Models.ViewModel.Business.Value;

namespace Core.Data.Repository
{
    public partial class Repository
    {

        public async Task<UpdateValueVm> Sp_UpdateValue(UpdateValueParam parameters) => await _context.GetAsync<UpdateValueVm>
                (
                    "Business.sp_UpdateValue",
                    parameters
                );
    }
}
