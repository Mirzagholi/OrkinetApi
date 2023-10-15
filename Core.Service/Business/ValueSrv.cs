using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Common.Base;
using Core.Common.ShareContract;
using Core.Common.ShareModels;
using Core.DataContract;
using Core.Models.Parameter.Business.Value;
using Core.Models.Request.Business.Value;
using Core.Models.ViewModel.Business.Value;
using Core.ServiceContract.Business;

namespace Core.Service.Business
{
    public class ValueSrv : IValueSrv
    {
        #region Property

        private readonly IRepository _repository;
        private readonly IServiceResultHelper _serviceResultHelper;

        #endregion Property

        #region Constructor

        public ValueSrv(IRepository repository,
            IServiceResultHelper serviceResultHelper)
        {
            _repository = repository;
            _serviceResultHelper = serviceResultHelper;
        }

        #endregion Constructor

        #region Methods

        public async Task<ServiceResult> AddValueAsync(AddValueRequest request)
        {
            var response = await _repository.Sp_AddValue(
                new AddValueParam()
                {
                    Name = request.Name.Trim(),
                    AttributeId = request.AttributeId,
                    Order = request.Order ?? 0
                });

            return _serviceResultHelper.Response(response);
        }

        public async Task<ServiceResult> UpdateValueAsync(UpdateValueRequest request)
        {
            var response = await _repository.Sp_UpdateValue(
                new UpdateValueParam()
                {
                    Id = request.Id,
                    Name = request.Name,
                    AttributeId = request.AttributeId,
                    Order = request.Order ?? 0
                });

            return _serviceResultHelper.Response(response);
        }

        public async Task<ServiceResult> UpdateValueStatusAsync(UpdateValueStatusRequest request)
        {
            var response = await _repository.Sp_UpdateValueStatus(
                new UpdateValueStatusParam()
                {
                    Id = request.Id,
                    StatusId = request.StatusId
                });

            return _serviceResultHelper.Response(response);
        }

        public async Task<GetValueByIdVm> GetValueByIdAsync(int id) => await _repository.Sp_GetValueById(new GetValueByIdParam() { Id = id });

        public async Task<BasePagingResult<GetValueVm>> GetValueAsync(GetValueRequest request)
        {
            return await _repository.Sp_GetValue(new GetValueParam
            {
                AttributeId = request.AttributeId,
                PageNumber = request.PageNumber,
                PageRecord = request.PageRecord,
                SortColumn = request.SortColumn,
                SortOrder = request.SortOrder
            });
        }

        public async Task<IEnumerable<GetCompleteValueDropDownVm>> GetCompleteValueDropDownAsync() => await _repository.Sp_GetCompleteValueDropDown();

        #endregion
    }
}
