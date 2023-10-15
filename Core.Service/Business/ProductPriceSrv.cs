using System.Threading.Tasks;
using Core.Common.Extensions;
using Core.Common.ShareContract;
using Core.Common.ShareModels;
using Core.DataContract;
using Core.Models.Parameter.Business.ProductPrice;
using Core.Models.Request.Business.ProductPrice;
using Core.ServiceContract.Business;

namespace Core.Service.Business
{
    public class ProductPriceSrv : IProductPriceSrv
    {

        #region Property

        private readonly IRepository _repository;
        private readonly IServiceResultHelper _serviceResultHelper;

        #endregion Property

        #region Constructor

        public ProductPriceSrv(IRepository repository,
            IServiceResultHelper serviceResultHelper)
        {
            _repository = repository;
            _serviceResultHelper = serviceResultHelper;
        }

        #endregion Constructor

        #region Methods

        public async Task<ServiceResult> UpdateProductPriceAsync(UpdateProductPriceRequest request)
        {
            var providerId = HttpContextExtensions.GetProviderId().Value;
            var response = await _repository.Sp_UpdateProductPrice(
                new UpdateProductPriceParam()
                {
                    Id = request.Id,
                    ProviderId = providerId,
                    Price = request.Price,
                });

            return _serviceResultHelper.Response(response);
        }

        #endregion
    }
}
