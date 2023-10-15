using Core.Common.Base;

namespace Core.Models.ViewModel.Business.Cart
{
    public class UserInquiryStatusVm : BaseDataResult
    {
        public string MobileNumber { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
