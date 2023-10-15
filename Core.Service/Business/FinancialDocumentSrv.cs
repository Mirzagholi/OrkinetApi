using System.Threading.Tasks;
using Core.Common.Base;
using Core.Common.Extensions;
using Core.Common.ShareContract;
using Core.Common.ShareModels;
using Core.DataContract;
using Core.Models.Parameter.Business.FinancialDocument;
using Core.Models.Request.Business.FinancialDocument;
using Core.Models.ViewModel.Business.FinancialDocument;
using Core.ServiceContract.Business;

namespace Core.Service.Business
{
    public class FinancialDocumentSrv : IFinancialDocumentSrv
    {
        #region Property

        private readonly IRepository _repository;
        private readonly IServiceResultHelper _serviceResultHelper;

        #endregion Property

        #region Constructor

        public FinancialDocumentSrv(IRepository repository,
            IServiceResultHelper serviceResultHelper)
        {
            _repository = repository;
            _serviceResultHelper = serviceResultHelper;
        }

        #endregion Constructor

        #region Methods

        public async Task<ServiceResult> AddFinancialDocumentAsync(AddFinancialDocumentRequest request)
        {
            var userId = HttpContextExtensions.GetUserId().Value;
            await _repository.Sp_AddFinancialDocument(
                new AddFinancialDocumentParam()
                {
                    Name = request.Name.Trim(),
                    EndOn = request.EndOn,
                    CreatedById = userId
                });

            return _serviceResultHelper.Response(null);
        }

        public async Task<BasePagingResult<GetAllFinancialDocumentVm>> GetAllFinancialDocumentAsync(GetAllFinancialDocumentRequest request)
        {
            return await _repository.Sp_GetAllFinancialDocument(new GetAllFinancialDocumentParam
            {
                PageNumber = request.PageNumber,
                PageRecord = request.PageRecord,
                SortColumn = request.SortColumn,
                SortOrder = request.SortOrder
            });
        }

        public async Task<BasePagingResult<GetAllFinancialDocumentInfoVm>> GetAllFinancialDocumentInfoAsync(GetAllFinancialDocumentInfoRequest request)
        {
            return await _repository.Sp_GetAllFinancialDocumentInfo(new GetAllFinancialDocumentInfoParam
            {
                FinancialDocumentId = request.FinancialDocumentId,
                PageNumber = request.PageNumber,
                PageRecord = request.PageRecord,
                SortColumn = request.SortColumn,
                SortOrder = request.SortOrder
            });
        }

        #endregion
    }
}
