using Core.Common.Base;

namespace Core.Models.ViewModel.Business.Product
{
    public class GetProviderWithCoordinateUiVm : BaseDataResult
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public decimal Latitudes { get; set; }
        public decimal Longitudes { get; set; }
    }
}
