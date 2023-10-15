using System.Threading.Tasks;
using Core.Models.Parameter.Business.WebSiteFile;

namespace Core.Data.Repository
{
    public partial class Repository
    {

        public async Task Sp_AddWebSiteFile(AddWebSiteFileParam parameters) => await _context.ExecuteAsync
                (
                    "Business.sp_AddWebSiteFile",
                    parameters
                );
    }
}
