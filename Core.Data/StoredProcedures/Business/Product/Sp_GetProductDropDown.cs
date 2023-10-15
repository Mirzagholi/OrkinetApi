using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Models.Parameter.Business.Product;
using Core.Models.ViewModel.Business.Product;

namespace Core.Data.Repository
{
    public partial class Repository
    {
        public async Task<IEnumerable<GetProductDropDownVm>> Sp_GetProductDropDown(GetProductDropDownParam parameters) => await _context.GetManyAsync<GetProductDropDownVm>
            (
                "Business.sp_GetProductDropDown",
                parameters
        );

    }

}
