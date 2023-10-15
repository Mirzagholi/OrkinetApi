using System.Threading.Tasks;
using Core.Models.Parameter.Business.WebSiteFile;
using Core.Models.ViewModel.Business.WebSiteFile;

namespace Core.Data.Repository
{
    public partial class Repository
    {

        public async Task<DeleteWebSiteFileVm> Sp_DeleteWebSiteFile(DeleteWebSiteFileParam parameters) => await _context.GetAsync<DeleteWebSiteFileVm>
                (
                    "Business.sp_DeleteWebSiteFile",
                    parameters
                );
    }
}
