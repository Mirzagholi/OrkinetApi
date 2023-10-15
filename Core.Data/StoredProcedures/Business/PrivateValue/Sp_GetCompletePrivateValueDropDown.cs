using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Models.Parameter.Business.PrivateValue;
using Core.Models.ViewModel.Business.PrivateValue;

namespace Core.Data.Repository
{
    public partial class Repository
    {
        public async Task<IEnumerable<GetCompletePrivateValueDropDownVm>> Sp_GetCompletePrivateValueDropDown(GetCompletePrivateValueParam parameters) => await _context.GetManyAsync<GetCompletePrivateValueDropDownVm>
            (
                "Business.sp_GetCompletePrivateValueDropDown",
                parameters
        );

    }

}
