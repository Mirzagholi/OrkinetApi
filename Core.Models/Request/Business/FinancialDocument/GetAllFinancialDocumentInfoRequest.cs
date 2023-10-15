using Core.Common.Base;

namespace Core.Models.Request.Business.FinancialDocument
{
    public class GetAllFinancialDocumentInfoRequest : BasePagingRequest
    {
        public int FinancialDocumentId { get; set; }
    }
}
