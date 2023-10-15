using Core.Common.Base;
using Core.Models.Enum.Common;
using Core.Models.Helper;
using System;

namespace Core.Models.ViewModel.Business.FinancialDocument
{
    public class GetAllFinancialDocumentInfoVm : BaseDataResult
    {
        public int Id { get; set; }
        public string ProviderName { get; set; }
        public int TotalPrice { get; set; }
        public int ProviderSharePrice { get; set; }
        public int GolonetSharePrice { get; set; }
        public decimal SharePercent { get; set; }
        public DateTime CreatedOn { get; set; }
    }
}
