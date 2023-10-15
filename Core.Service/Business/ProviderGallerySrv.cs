using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BingCdn.NetCoreConnector;
using BingCdn.NetCoreConnector.Common.Helper.ServiceResponse;
using BingCdn.NetCoreConnector.Dto.Cdn.CdnUploadFile;
using BingCdn.NetCoreConnector.Dto.Cdn.CdnUploadManyFile;
using Core.Common.Extensions;
using Core.Common.Settings;
using Core.Common.ShareContract;
using Core.Common.ShareModels;
using Core.Data.DataHelpers;
using Core.DataContract;
using Core.Models.Parameter.Business.ProviderGallery;
using Core.Models.Request.Business.ProviderGallery;
using Core.Models.ViewModel.Business.ProviderGallery;
using Core.ServiceContract.Business;
using Microsoft.Extensions.Options;

namespace Core.Service.Business
{
    public class ProviderGallerySrv : IProviderGallerySrv
    {

        #region Property

        private readonly IRepository _repository;
        private readonly IServiceResultHelper _serviceResultHelper;
        private readonly ICdnService _cdnService;
        private readonly IOptionsSnapshot<SiteSettings> _siteSettings;

        #endregion Property

        #region Constructor


        public ProviderGallerySrv(IRepository repository,
            IServiceResultHelper serviceResultHelper,
            ICdnService cdnService,
            IOptionsSnapshot<SiteSettings> siteSettings)
        {
            _repository = repository;
            _serviceResultHelper = serviceResultHelper;
            _siteSettings = siteSettings ?? throw new ArgumentNullException(nameof(_siteSettings));

            _cdnService = cdnService ?? throw new ArgumentNullException(nameof(_cdnService));
        }

        #endregion Constructor

        #region Methods

        public async Task<ServiceResult> AddProviderGalleryAsync(AddProviderGalleryRequest request)
        {
            var cdnResponse = await _cdnService.CdnUploadManyFileAsync(new CdnUploadManyFileRequestDto { Files = request.Files });

            if (cdnResponse.ResultCode != (int)ServiceResponseKey.Cdn_UploadSuccess || cdnResponse.FileIdes.Count() == 0)
                return null;

            var response = await _repository.Sp_AddProviderGallery(
                new AddProviderGalleryParam()
                {
                    CdnFileIdes = cdnResponse.FileIdes.ToList().MapToIdesSqlType().ToDataTable(),
                    ProviderId = request.ProviderId
                });

            return _serviceResultHelper.Response(response);
        }

        public async Task<IEnumerable<GetProviderGalleryVm>> GetProviderGalleryAsync(GetProviderGalleryRequest request)
        {
            var results =
                await _repository.Sp_GetProviderGallery(new GetProviderGalleryParam() { ProviderId = request.ProviderId });

            if (results == null || results.Count() == 0)
                return null;

            var cdnFiles = await _cdnService.GetCdnManyFilePathAsync(results.Select(z => z.CdnFileId).ToArray());

            foreach (var result in results.ToList())
                result.Path = cdnFiles.FirstOrDefault(z => z.Id == result.CdnFileId).Path;

            return results;
        }

        public async Task<IEnumerable<GetProviderGalleryVm>> GetProviderGalleryProAsync()
        {
            var providerId = HttpContextExtensions.GetProviderId().Value;
            return
                await GetProviderGalleryAsync(new GetProviderGalleryRequest() {ProviderId = providerId});
        }

        public async Task<ServiceResult> UpdateProviderGalleryStatusAsync(UpdateProviderGalleryStatusRequest request)
        {
            var response = await _repository.Sp_UpdateProviderGalleryStatus(
                new UpdateProviderGalleryStatusParam()
                {
                    Id = request.Id,
                    StatusId = request.StatusId
                });

            return _serviceResultHelper.Response(response);
        }

        #endregion
    }
}
