using System.Threading.Tasks;
using Core.Models.Parameter.Business.PrivateValue;
using Core.Models.ViewModel.Business.PrivateValue;

namespace Core.Data.Repository
{
    public partial class Repository
    {

        public async Task<UpdatePrivateValueStatusVm> Sp_UpdatePrivateValueStatus(UpdatePrivateValueStatusParam parameters) => await _context.GetAsync<UpdatePrivateValueStatusVm>
                (
                    "Business.sp_UpdatePrivateValueStatus",
                    parameters
                );
    }
}
