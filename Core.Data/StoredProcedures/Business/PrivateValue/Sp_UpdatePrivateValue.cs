using System.Threading.Tasks;
using Core.Models.Parameter.Business.PrivateValue;
using Core.Models.ViewModel.Business.PrivateValue;

namespace Core.Data.Repository
{
    public partial class Repository
    {

        public async Task<UpdatePrivateValueVm> Sp_UpdatePrivateValue(UpdatePrivateValueParam parameters) => await _context.GetAsync<UpdatePrivateValueVm>
                (
                    "Business.sp_UpdatePrivateValue",
                    parameters
                );
    }
}
