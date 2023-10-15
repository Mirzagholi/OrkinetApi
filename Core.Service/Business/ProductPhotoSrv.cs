using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BingCdn.NetCoreConnector;
using Core.Common.Extensions;
using Core.Common.ShareContract;
using Core.Common.ShareModels;
using Core.DataContract;
using Core.Models.Parameter.Business.ProductPhoto;
using Core.Models.Request.Business.ProductPhoto;
using Core.Models.ViewModel.Business.ProductPhoto;
using Core.ServiceContract.Business;
using Microsoft.AspNetCore.Http;

namespace Core.Service.Business
{
    public class ProductPhotoSrv : IProductPhotoSrv
    {

        #region Property

        private readonly IRepository _repository;
        private readonly IServiceResultHelper _serviceResultHelper;
        private readonly ICdnService _cdnService;

        #endregion Property

        #region Constructor

        public ProductPhotoSrv(IRepository repository,
            IServiceResultHelper serviceResultHelper,
            ICdnService cdnService)
        {
            _repository = repository;
            _serviceResultHelper = serviceResultHelper;

            _cdnService = cdnService ?? throw new ArgumentNullException(nameof(_cdnService));
        }

        #endregion Constructor

        #region Methods

        public async Task<ServiceResult> AddProductPhotoAsync(AddProductPhotoRequest request)
        {
            var providerId = HttpContextExtensions.GetProviderId().Value;
            var response = await _repository.Sp_AddProductPhoto(
                new AddProductPhotoParam()
                {
                    ProductId = request.ProductId,
                    ProviderId = providerId,
                    ProviderGalleryId = request.ProviderGalleryId
                });

            return _serviceResultHelper.Response(response);
        }

        public async Task<IEnumerable<GetProductPhotoVm>> GetProductPhotoAsync(GetProductPhotoRequest request)
        {
            var results =
                await _repository.Sp_GetProductPhoto(new GetProductPhotoParam() { ProductId = request.ProductId });

            if (results == null || results.Count() == 0)
                return null;

            var cdnFiles = await _cdnService.GetCdnManyFilePathAsync(results.Select(z => z.CdnFileId).ToArray());

            foreach (var result in results.ToList())
                result.Path = cdnFiles.FirstOrDefault(z => z.Id == result.CdnFileId).Path;

            return results;
        }

        public async Task<ServiceResult> DeleteProductPhotoAsync(DeleteProductPhotoRequest request)
        {
            var providerId = HttpContextExtensions.GetProviderId().Value;
            var response = await _repository.Sp_DeleteProductPhoto(
                new DeleteProductPhotoParam()
                {
                    ProductId = request.ProductId,
                    ProviderId = providerId,
                    ProviderGalleryId = request.ProviderGalleryId
                });

            return _serviceResultHelper.Response(response);
        }

        #endregion
    }
}
