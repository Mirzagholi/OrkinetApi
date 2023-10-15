using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Models.Parameter.Business.Cart;
using Core.Models.ViewModel.Business.Cart;

namespace Core.Data.Repository
{
    public partial class Repository
    {

        public async Task<IEnumerable<GetWeeklyProviderCustomerCartChartVm>> Sp_GetWeeklyProviderCustomerCartChart
            (GetWeeklyProviderCustomerCartChartParam parameters) => await _context.GetManyAsync<GetWeeklyProviderCustomerCartChartVm>
                (
                    "Business.sp_GetWeeklyProviderCustomerCartChart",
                    parameters
                );

    }
}
