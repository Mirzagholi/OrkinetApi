using Core.Common.Base;
using Core.Models.ViewModel.Business.Cart;
using System.Collections.Generic;

namespace Core.Models.ViewModel.Business.Index
{
    public class GetProviderIndexDataVm : BaseDataResult
    {
        public int InquiryCartCount { get; set; }

        public int CompleteCartCount { get; set; }

        public int CustomerCartCount { get; set; }

        public int ActiveProductDiscountCount { get; set; }

        public IEnumerable<GetWeeklyProviderCompleteCartChartVm> WeeklyCompleteCartChart { get; set; }

        public IEnumerable<GetWeeklyProviderCustomerCartChartVm> WeeklyCustomerCartChart { get; set; }
    }
}
