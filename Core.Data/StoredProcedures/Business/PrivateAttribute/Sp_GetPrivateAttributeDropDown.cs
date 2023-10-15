using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Models.Parameter.Business.PrivateAttribute;
using Core.Models.ViewModel.Business.PrivateAttribute;

namespace Core.Data.Repository
{
    public partial class Repository
    {
        public async Task<IEnumerable<GetPrivateAttributeDropDownVm>> Sp_GetPrivateAttributeDropDown(GetPrivateAttributeDropDownParam parameters) => await _context.GetManyAsync<GetPrivateAttributeDropDownVm>
            (
                "Business.sp_GetPrivateAttributeDropDown",
                parameters
        );

    }

}
