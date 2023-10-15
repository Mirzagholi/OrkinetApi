using System.Threading.Tasks;
using Core.Common.Base;
using Core.Common.Extensions;
using Core.Common.ShareContract;
using Core.Common.ShareModels;
using Core.DataContract;
using Core.Models.Parameter.Business.ProductDiscount;
using Core.Models.Request.Business.ProductDiscount;
using Core.Models.ViewModel.Business.ProductDiscount;
using Core.ServiceContract.Business;

namespace Core.Service.Business
{
    public class ProductDiscountSrv : IProductDiscountSrv
    {

        #region Property

        private readonly IRepository _repository;
        private readonly IServiceResultHelper _serviceResultHelper;

        #endregion Property

        #region Constructor

        public ProductDiscountSrv(IRepository repository,
            IServiceResultHelper serviceResultHelper)
        {
            _repository = repository;
            _serviceResultHelper = serviceResultHelper;
        }

        #endregion Constructor

        #region Methods

        public async Task<ServiceResult> AddProductDiscountAsync(AddProductDiscountRequest request)
        {
            var providerId = HttpContextExtensions.GetProviderId().Value;
            var response = await _repository.Sp_AddProductDiscount(
                new AddProductDiscountParam()
                {
                    ProductId = request.ProductId,
                    ProviderId = providerId,
                    Value = request.Value,
                    ExpiredOn = request.ExpiredOn
                });

            return _serviceResultHelper.Response(response);
        }

        public async Task<BasePagingResult<GetProductDiscountVm>> GetProductDiscountAsync(GetProductDiscountRequest request)
        {
            var providerId = HttpContextExtensions.GetProviderId().Value;
            return await _repository.Sp_GetProductDiscount(new GetProductDiscountParam
            {
                ProviderId = providerId,
                PageNumber = request.PageNumber,
                PageRecord = request.PageRecord,
                SortColumn = request.SortColumn,
                SortOrder = request.SortOrder
            });
        }

        public async Task<ServiceResult> UpdateProductDiscountAsync(UpdateProductDiscountRequest request)
        {
            var providerId = HttpContextExtensions.GetProviderId().Value;
            var response = await _repository.Sp_UpdateProductDiscount(
                new UpdateProductDiscountParam()
                {
                    Id = request.Id,
                    ProductId = request.ProductId,
                    ProviderId = providerId,
                    Value = request.Value,
                    ExpiredOn = request.ExpiredOn
                });

            return _serviceResultHelper.Response(response);
        }

        public async Task<ServiceResult> UpdateProductDiscountStatusAsync(UpdateProductDiscountStatusRequest request)
        {
            var providerId = HttpContextExtensions.GetProviderId().Value;
            var response = await _repository.Sp_UpdateProductDiscountStatus(
                new UpdateProductDiscountStatusParam()
                {
                    Id = request.Id,
                    ProviderId = providerId,
                    StatusId = request.StatusId
                });

            return _serviceResultHelper.Response(response);
        }

        public async Task<int> GetProviderActiveProductDiscountCountAsync()
        {
            var providerId = HttpContextExtensions.GetProviderId().Value;

            return await _repository.Sp_GetProviderActiveProductDiscountCount(new GetProviderActiveProductDiscountCountParam
            {
                ProviderId = providerId
            });
        }

        #endregion
    }
}
