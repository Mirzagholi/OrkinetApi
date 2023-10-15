using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Common.Base;
using Core.Common.ShareContract;
using Core.Common.ShareModels;
using Core.DataContract;
using Core.Models.Parameter.Business.Rating;
using Core.Models.Parameter.Business.Value;
using Core.Models.Request.Business.Rating;
using Core.Models.Request.Business.Value;
using Core.Models.ViewModel.Business.Value;
using Core.ServiceContract.Business;

namespace Core.Service.Business
{
    public class RatingSrv : IRatingSrv
    {
        #region Property

        private readonly IRepository _repository;
        private readonly IServiceResultHelper _serviceResultHelper;

        #endregion Property

        #region Constructor

        public RatingSrv(IRepository repository,
            IServiceResultHelper serviceResultHelper)
        {
            _repository = repository;
            _serviceResultHelper = serviceResultHelper;
        }

        #endregion Constructor

        #region Methods

        public async Task<ServiceResult> UpdateProductRatingAsync(UpdateProductRatingRequest request)
        {
            await _repository.Sp_UpdateProductRating(
                new UpdateProductRatingParam()
                {
                    ProductId = request.ProductId,
                    Rating = request.Rating
                });

            return _serviceResultHelper.Response(null);
        }

        public async Task<ServiceResult> UpdateProviderRatingAsync(UpdateProviderRatingRequest request)
        {
            await _repository.Sp_UpdateProviderRating(
                new UpdateProviderRatingParam()
                {
                    ProviderId = request.ProviderId,
                    Rating = request.Rating
                });

            return _serviceResultHelper.Response(null);
        }

        #endregion
    }
}
