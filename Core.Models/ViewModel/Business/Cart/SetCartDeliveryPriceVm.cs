using Core.Common.Base;

namespace Core.Models.ViewModel.Business.Cart
{
    public class SetCartDeliveryPriceVm : BaseDataResult
    {
        public int ProviderId { get; set; }
        public int DeliveryPrice { get; set; }
    }
}
