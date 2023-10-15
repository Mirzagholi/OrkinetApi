using Core.Common.Base;

namespace Core.Models.ViewModel.Business.Cart
{
    public class GetUserCompleteCartProductVm : BaseDataResult
    {
        public int ProductId { get; set; }
        public string ProductCode { get; set; }
        public string ProductName { get; set; }
        public int Quantity { get; set; }
        public int Price { get; set; }
        public int DiscountPrice { get; set; }
        public int FinalPrice { get; set; }
        public string Photo { get; set; }
        public int CdnFileId { get; set; }
    }
}
