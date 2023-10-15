using Core.Common.Base;

namespace Core.Models.ViewModel.Business.Cart
{
    public class GetWeeklyProviderCompleteCartChartVm : BaseDataResult
    {
        public int WeekNo { get; set; }

        public int Count { get; set; }
    }
}
