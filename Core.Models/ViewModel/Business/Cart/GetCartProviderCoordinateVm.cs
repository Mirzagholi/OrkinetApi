using Core.Common.Base;

namespace Core.Models.ViewModel.Business.Cart
{
    public class GetCartProviderCoordinateVm : BaseDataResult
    {
        public int ProviderId { get; set; }
        public decimal Latitudes { get; set; }
        public decimal Longitudes { get; set; }
    }
}
