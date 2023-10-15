using System.Threading.Tasks;
using Core.Common.Base;
using Core.Common.ShareContract;
using Core.Common.ShareModels;
using Core.DataContract;
using Core.Models.Parameter.Business.Attribute;
using Core.Models.Request.Business.Attribute;
using Core.Models.ViewModel.Business.Attribute;
using Core.ServiceContract.Business;

namespace Core.Service.Business
{
    public class AttributeSrv : IAttributeSrv
    {
        #region Property

        private readonly IRepository _repository;
        private readonly IServiceResultHelper _serviceResultHelper;

        #endregion Property

        #region Constructor

        public AttributeSrv(IRepository repository,
            IServiceResultHelper serviceResultHelper)
        {
            _repository = repository;
            _serviceResultHelper = serviceResultHelper; ;
        }

        #endregion Constructor

        #region Methods

        public async Task<ServiceResult> AddAttributeAsync(AddAttributeRequest request)
        {
            var response = await _repository.Sp_AddAttribute(
                new AddAttributeParam()
                {
                    Name = request.Name.Trim(),
                    Order = request.Order ?? 0
                });

            return _serviceResultHelper.Response(response);
        }

        public async Task<ServiceResult> UpdateAttributeAsync(UpdateAttributeRequest request)
        {
            var response = await _repository.Sp_UpdateAttribute(
                new UpdateAttributeParam()
                {
                    Id = request.Id,
                    Name = request.Name,
                    Order = request.Order ?? 0
                });

            return _serviceResultHelper.Response(response);
        }

        public async Task<ServiceResult> UpdateAttributeStatusAsync(UpdateAttributeStatusRequest request)
        {
            var response = await _repository.Sp_UpdateAttributeStatus(
                new UpdateAttributeStatusParam()
                {
                    Id = request.Id,
                    StatusId = request.StatusId
                });

            return _serviceResultHelper.Response(response);
        }

        public async Task<GetAttributeByIdVm> GetAttributeByIdAsync(int id) => await _repository.Sp_GetAttributeById(new GetAttributeByIdParam() { Id = id });

        public async Task<BasePagingResult<GetAttributeVm>> GetAttributeAsync(GetAttributeRequest request)
        {
            return await _repository.Sp_GetAttribute(new GetAttributeParam
            {
                PageNumber = request.PageNumber,
                PageRecord = request.PageRecord,
                SortColumn = request.SortColumn,
                SortOrder = request.SortOrder
            });
        }

        #endregion
    }
}
