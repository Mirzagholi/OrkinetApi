using System;
using Core.Common.Base;
using Core.Models.Enum.Common;
using Core.Models.Helper;

namespace Core.Models.ViewModel.Business.ProductDelivery
{
    public class GetProductDeliveryVm : BaseDataResult
    {
        public int Id { get; set; }
        public int Distance { get; set; }
        public int? PurchasePrice { get; set; }
        public int Price { get; set; }
        public StatusType StatusId { get; set; }
        public string StatusText => StatusId.GetStatusTextByCulture();
        public DateTime CreatedOn { get; set; }
    }
}
