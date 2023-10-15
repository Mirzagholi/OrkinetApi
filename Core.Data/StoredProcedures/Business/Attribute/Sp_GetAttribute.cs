using System.Threading.Tasks;
using Core.Common.Base;
using Core.Models.Parameter.Business.Attribute;
using Core.Models.ViewModel.Business.Attribute;

namespace Core.Data.Repository
{
    public partial class Repository
    {

        public async Task<BasePagingResult<GetAttributeVm>> Sp_GetAttribute(GetAttributeParam parameters) => await _context.GetManyWithPagingAsync<GetAttributeVm>
                (
                    "Business.sp_GetAttribute",
                    parameters
        );
    }
}
