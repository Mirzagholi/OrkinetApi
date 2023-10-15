using Core.Common.Base;
using Core.Models.Enum.Common;
using Core.Models.Helper;
using System;

namespace Core.Models.ViewModel.Business.FinancialDocument
{
    public class GetAllFinancialDocumentVm : BaseDataResult
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime StartOn { get; set; }
        public DateTime EndOn { get; set; }
        public StatusType StatusId { get; set; }
        public string StatusText => StatusId.GetStatusTextByCulture();
        public DateTime CreatedOn { get; set; }
    }
}
