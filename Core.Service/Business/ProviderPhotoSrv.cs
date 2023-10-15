using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BingCdn.NetCoreConnector;
using Core.Common.Extensions;
using Core.Common.ShareContract;
using Core.Common.ShareModels;
using Core.DataContract;
using Core.Models.Parameter.Business.ProviderPhoto;
using Core.Models.Request.Business.ProviderPhoto;
using Core.Models.ViewModel.Business.ProviderPhoto;
using Core.ServiceContract.Business;

namespace Core.Service.Business
{
    public class ProviderPhotoSrv : IProviderPhotoSrv
    {

        #region Property

        private readonly IRepository _repository;
        private readonly IServiceResultHelper _serviceResultHelper;
        private readonly ICdnService _cdnService;

        #endregion Property

        #region Constructor

        public ProviderPhotoSrv(IRepository repository,
            IServiceResultHelper serviceResultHelper,
            ICdnService cdnService)
        {
            _repository = repository;
            _serviceResultHelper = serviceResultHelper;

            _cdnService = cdnService ?? throw new ArgumentNullException(nameof(_cdnService));
        }

        #endregion Constructor

        #region Methods

        public async Task<ServiceResult> AddProviderPhotoAsync(AddProviderPhotoRequest request)
        {
            var response = await _repository.Sp_AddProviderPhoto(
                new AddProviderPhotoParam()
                {
                    ProviderId = request.ProviderId,
                    ProviderGalleryId = request.ProviderGalleryId
                });

            return _serviceResultHelper.Response(response);
        }

        public async Task<IEnumerable<GetProviderPhotoVm>> GetProviderPhotoAsync(GetProviderPhotoRequest request)
        {
            var results =
                await _repository.Sp_GetProviderPhoto(new GetProviderPhotoParam() { ProviderId = request.ProviderId });

            if (results == null || results.Count() == 0)
                return null;

            var cdnFiles = await _cdnService.GetCdnManyFilePathAsync(results.Select(z => z.CdnFileId).ToArray());

            foreach (var result in results.ToList())
                result.Path = cdnFiles.FirstOrDefault(z => z.Id == result.CdnFileId).Path;

            return results;
        }

        public async Task<ServiceResult> DeleteProviderPhotoAsync(DeleteProviderPhotoRequest request)
        {
            var response = await _repository.Sp_DeleteProviderPhoto(
                new DeleteProviderPhotoParam()
                {
                    ProviderId = request.ProviderId,
                    ProviderGalleryId = request.ProviderGalleryId
                });

            return _serviceResultHelper.Response(response);
        }

        #endregion
    }
}
