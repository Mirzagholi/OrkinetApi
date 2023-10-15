using Core.Common.Base;

namespace Core.Models.ViewModel.Business.Cart
{
    public class PaidCartVm : BaseDataResult
    {
        public int CartId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MobileNumber { get; set; }
    }
}
