using System.Threading.Tasks;
using Core.Models.Parameter.Business.ProviderContact;
using Core.Models.ViewModel.Business.ProviderContact;

namespace Core.Data.Repository
{
    public partial class Repository
    {

        public async Task<AddProviderContactVm> Sp_AddProviderContact(AddProviderContactParam parameters) => await _context.GetAsync<AddProviderContactVm>
                (
                    "Business.sp_AddProviderContact",
                    parameters
                );
    }
}
