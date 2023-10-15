using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Models.Parameter.Business.Cart;
using Core.Models.ViewModel.Business.Cart;

namespace Core.Data.Repository
{
    public partial class Repository
    {

        public async Task<IEnumerable<GetWeeklyProviderCompleteCartChartVm>> Sp_GetWeeklyProviderCompleteCartChart
            (GetWeeklyProviderCompleteCartChartParam parameters) => await _context.GetManyAsync<GetWeeklyProviderCompleteCartChartVm>
                (
                    "Business.sp_GetWeeklyProviderCompleteCartChart",
                    parameters
                );

    }
}
