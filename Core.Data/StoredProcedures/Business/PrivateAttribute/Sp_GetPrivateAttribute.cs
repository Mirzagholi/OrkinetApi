using System.Threading.Tasks;
using Core.Common.Base;
using Core.Models.Parameter.Business.PrivateAttribute;
using Core.Models.ViewModel.Business.PrivateAttribute;

namespace Core.Data.Repository
{
    public partial class Repository
    {
        public async Task<BasePagingResult<GetPrivateAttributeVm>> Sp_GetPrivateAttribute(GetPrivateAttributeParam parameters) => await _context.GetManyWithPagingAsync<GetPrivateAttributeVm>
            (
                "Business.sp_GetPrivateAttribute",
                parameters
        );

    }

}
