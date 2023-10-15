using Core.Common.Base;
using Core.Models.Enum.Common;
using Core.Models.Helper;
using System;

namespace Core.Models.ViewModel.Business.Cart
{
    public class GetAllUserCompleteCartVm : BaseDataResult
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MobileNumber { get; set; }
        public int ProductPrice { get; set; }
        public int DeliveryPrice { get; set; }
        public StatusType LastStatusId { get; set; }
        public string LastStatusText => LastStatusId.GetStatusTextByCulture();
        public DateTime CreatedOn { get; set; }
        public string TransactionCode { get; set; }
    }
}
