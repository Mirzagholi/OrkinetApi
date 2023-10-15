using Core.Common.Base;

namespace Core.Models.ViewModel.Business.Cart
{
    public class StartInquiryCartVm : BaseDataResult
    {
        public int ProductId { get; set; }
        public bool? IsConfirm { get; set; }
    }
}
