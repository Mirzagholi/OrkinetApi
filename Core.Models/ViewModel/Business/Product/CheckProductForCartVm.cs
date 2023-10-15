using Core.Common.Base;
using Core.Models.Enum.Common;
using Core.Models.Helper;

namespace Core.Models.ViewModel.Business.Product
{
    public class CheckProductForCartVm : BaseDataResult
    {
        public int ProductId { get; set; }
        public int Price { get; set; }
        public int DiscountPrice { get; set; }
        public StatusType StatusId { get; set; }
        public string StatusText => StatusId.GetStatusTextByCulture();
    }
}
