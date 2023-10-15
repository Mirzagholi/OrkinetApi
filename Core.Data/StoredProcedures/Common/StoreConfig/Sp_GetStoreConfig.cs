using System.Threading.Tasks;
using Core.Models.ViewModel.Common.StoreConfig;

namespace Core.Data.Repository
{
    public partial class Repository
    {
        public async Task<GetStoreConfigVm> Sp_GetStoreConfig() => await _context.GetAsync<GetStoreConfigVm>
            (
                "Business.sp_GetStoreConfig"
            );
    }
}
