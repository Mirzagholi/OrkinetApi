using Core.Common.Base;
using Core.Models.Enum.Common;
using Core.Models.Helper;
using System;

namespace Core.Models.ViewModel.Business.Cart
{
    public class GetAllProviderCompleteCartVm : BaseDataResult
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MobileNumber { get; set; }
        public int FinalPrice { get; set; }
        public int DeliveryPrice { get; set; }
        public StatusType? CartStatusId { get; set; }
        public string CartStatusText => CartStatusId?.GetStatusTextByCulture();
        public string CartStatusDescription { get; set; }
        public DateTime CreatedOn { get; set; }
    }
}
