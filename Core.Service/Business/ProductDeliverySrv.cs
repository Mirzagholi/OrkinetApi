using System.Threading.Tasks;
using Core.Common.Base;
using Core.Common.Extensions;
using Core.Common.ShareContract;
using Core.Common.ShareModels;
using Core.DataContract;
using Core.Models.Parameter.Business.ProductDelivery;
using Core.Models.Request.Business.ProductDelivery;
using Core.Models.ViewModel.Business.ProductDelivery;
using Core.ServiceContract.Business;

namespace Core.Service.Business
{
    public class ProductDeliverySrv : IProductDeliverySrv
    {

        #region Property

        private readonly IRepository _repository;
        private readonly IServiceResultHelper _serviceResultHelper;

        #endregion Property

        #region Constructor

        public ProductDeliverySrv(IRepository repository,
            IServiceResultHelper serviceResultHelper)
        {
            _repository = repository;
            _serviceResultHelper = serviceResultHelper;
        }

        #endregion Constructor

        #region Methods

        public async Task<ServiceResult> AddProductDeliveryAsync(AddProductDeliveryRequest request)
        {
            var providerId = HttpContextExtensions.GetProviderId().Value;
            var response = await _repository.Sp_AddProductDelivery(
                new AddProductDeliveryParam()
                {
                    Distance = request.Distance,
                    ProviderId = providerId,
                    PurchasePrice = request.PurchasePrice,
                    Price = request.Price
                });

            return _serviceResultHelper.Response(response);
        }

        public async Task<BasePagingResult<GetProductDeliveryVm>> GetProductDeliveryAsync(GetProductDeliveryRequest request)
        {
            var providerId = HttpContextExtensions.GetProviderId().Value;
            return await _repository.Sp_GetProductDelivery(new GetProductDeliveryParam
            {
                ProviderId = providerId,
                PageNumber = request.PageNumber,
                PageRecord = request.PageRecord,
                SortColumn = request.SortColumn,
                SortOrder = request.SortOrder
            });
        }

        public async Task<ServiceResult> UpdateProductDeliveryAsync(UpdateProductDeliveryRequest request)
        {
            var providerId = HttpContextExtensions.GetProviderId().Value;
            var response = await _repository.Sp_UpdateProductDelivery(
                new UpdateProductDeliveryParam()
                {
                    Id = request.Id,
                    Distance = request.Distance,
                    ProviderId = providerId,
                    PurchasePrice = request.PurchasePrice,
                    Price = request.Price
                });

            return _serviceResultHelper.Response(response);
        }

        public async Task<ServiceResult> UpdateProductDeliveryStatusAsync(UpdateProductDeliveryStatusRequest request)
        {
            var providerId = HttpContextExtensions.GetProviderId().Value;
            var response = await _repository.Sp_UpdateProductDeliveryStatus(
                new UpdateProductDeliveryStatusParam()
                {
                    Id = request.Id,
                    ProviderId = providerId,
                    StatusId = request.StatusId
                });

            return _serviceResultHelper.Response(response);
        }

        #endregion
    }
}
