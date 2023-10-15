using System.Threading.Tasks;
using Core.Models.Parameter.Business.ProviderContact;
using Core.Models.ViewModel.Business.ProviderContact;

namespace Core.Data.Repository
{
    public partial class Repository
    {

        public async Task<DeleteProviderContactVm> Sp_DeleteProviderContact(DeleteProviderContactParam parameters) => await _context.GetAsync<DeleteProviderContactVm>
                (
                    "Business.sp_DeleteProviderContact",
                    parameters
                );
    }
}
