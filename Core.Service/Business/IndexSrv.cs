using Core.Models.ViewModel.Business.Index;
using Core.ServiceContract.Business;
using System.Threading.Tasks;

namespace Core.Service.Business
{
    public class IndexSrv : IIndexSrv
    {
        #region Property

        private readonly ICartSrv _cartSrv;
        private readonly IProductDiscountSrv _productDiscountSrv;

        #endregion Property

        #region Constructor

        public IndexSrv(ICartSrv cartSrv,
            IProductDiscountSrv productDiscountSrv)
        {
            _cartSrv = cartSrv;
            _productDiscountSrv = productDiscountSrv;
        }

        #endregion Constructor

        #region Methods

        public async Task<GetProviderIndexDataVm> GetProviderIndexDataAsync()
        {
            var result = new GetProviderIndexDataVm();

            result.InquiryCartCount = 
                await _cartSrv.GetProviderInquiryCartCountAsync();
            result.CompleteCartCount = 
                await _cartSrv.GetProviderCompleteCartCountAsync();
            result.CustomerCartCount =
                await _cartSrv.GetProviderCustomerCartCountAsync();
            result.ActiveProductDiscountCount =
                await _productDiscountSrv.GetProviderActiveProductDiscountCountAsync();
            result.WeeklyCompleteCartChart =
                await _cartSrv.GetWeeklyProviderCompleteCartChartAsync();
            result.WeeklyCustomerCartChart =
                await _cartSrv.GetWeeklyProviderCustomerCartChartAsync();

            return result;
        }

        #endregion
    }
}
