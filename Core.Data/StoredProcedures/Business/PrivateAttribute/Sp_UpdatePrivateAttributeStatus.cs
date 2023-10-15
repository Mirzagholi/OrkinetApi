using System.Threading.Tasks;
using Core.Models.Parameter.Business.PrivateAttribute;
using Core.Models.ViewModel.Business.PrivateAttribute;

namespace Core.Data.Repository
{
    public partial class Repository
    {

        public async Task<UpdatePrivateAttributeStatusVm> Sp_UpdatePrivateAttributeStatus(UpdatePrivateAttributeStatusParam parameters) => await _context.GetAsync<UpdatePrivateAttributeStatusVm>
                (
                    "Business.sp_UpdatePrivateAttributeStatus",
                    parameters
                );
    }
}
