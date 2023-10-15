using System;
using Core.Common.Base;
using Core.Models.Enum.Common;
using Core.Models.Helper;

namespace Core.Models.ViewModel.Business.ProductDiscount
{
    public class GetProductDiscountVm : BaseDataResult
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public int Value { get; set; }
        public StatusType StatusId { get; set; }
        public string StatusText => StatusId.GetStatusTextByCulture();
        public DateTime ExpiredOn { get; set; }
        public DateTime CreatedOn { get; set; }
    }
}
