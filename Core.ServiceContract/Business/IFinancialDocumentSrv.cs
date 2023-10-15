using Core.Common.Base;
using Core.Common.ShareModels;
using Core.Models.Request.Business.FinancialDocument;
using Core.Models.ViewModel.Business.FinancialDocument;
using System.Threading.Tasks;

namespace Core.ServiceContract.Business
{
    public interface IFinancialDocumentSrv : IInjectableService
    {
        Task<ServiceResult> AddFinancialDocumentAsync(AddFinancialDocumentRequest request);
        Task<BasePagingResult<GetAllFinancialDocumentVm>> GetAllFinancialDocumentAsync(GetAllFinancialDocumentRequest request);
        Task<BasePagingResult<GetAllFinancialDocumentInfoVm>> GetAllFinancialDocumentInfoAsync(GetAllFinancialDocumentInfoRequest request);
    }
}
