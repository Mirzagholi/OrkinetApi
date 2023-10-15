using Core.Common.Base;

namespace Core.Models.ViewModel.Business.Cart
{
    public class GetCartUserCoordinateVm : BaseDataResult
    {
        public decimal Latitudes { get; set; }
        public decimal Longitudes { get; set; }
    }
}
