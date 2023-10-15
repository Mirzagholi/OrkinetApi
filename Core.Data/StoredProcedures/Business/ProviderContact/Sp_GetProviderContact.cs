using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Models.Parameter.Business.ProviderContact;
using Core.Models.ViewModel.Business.ProviderContact;

namespace Core.Data.Repository
{
    public partial class Repository
    {

        public async Task<IEnumerable<GetProviderContactVm>> Sp_GetProviderContact(GetProviderContactParam parameters) => await _context.GetManyAsync<GetProviderContactVm>
                (
                    "Business.sp_GetProviderContact",
                    parameters
                );
    }
}
