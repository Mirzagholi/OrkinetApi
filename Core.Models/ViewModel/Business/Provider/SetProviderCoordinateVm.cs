using Core.Common.Base;
using Core.Models.Enum.Common;
using Core.Models.Helper;

namespace Core.Models.ViewModel.Business.Provider
{
    public class SetProviderCoordinateVm : BaseDataResult
    {
        public int Id { get; set; }
        public decimal Latitudes { get; set; }
        public decimal Longitudes { get; set; }
        public StatusType StatusId { get; set; }
        public string StatusText => StatusId.GetStatusTextByCulture();
    }
}
