using System.Threading.Tasks;
using Core.Common.Base;
using Core.Models.Parameter.Business.WebSiteFile;
using Core.Models.ViewModel.Business.WebSiteFile;

namespace Core.Data.Repository
{
    public partial class Repository
    {
        public async Task<BasePagingResult<GetAllWebSiteFileVm>> Sp_GetAllWebSiteFile(GetAllWebSiteFileParam parameters) => await _context.GetManyWithPagingAsync<GetAllWebSiteFileVm>
            (
                "Business.sp_GetAllWebSiteFile",
                parameters
        );

    }

}
