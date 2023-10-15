using Core.Common.Base;

namespace Core.Models.Parameter.Business.FinancialDocument
{
    public class GetAllFinancialDocumentInfoParam : BasePagingParam
    {
        public int FinancialDocumentId { get; set; }
    }
}
