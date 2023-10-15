using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BingCdn.NetCoreConnector;
using Core.Common.Base;
using Core.Common.Extensions;
using Core.Common.Helpers;
using Core.Common.Settings;
using Core.Common.ShareContract;
using Core.Common.ShareModels;
using Core.DataContract;
using Core.Models.Parameter.Business.Provider;
using Core.Models.Request.Business.Provider;
using Core.Models.Request.Common.Sms;
using Core.Models.ViewModel.Business.Product;
using Core.Models.ViewModel.Business.Provider;
using Core.ServiceContract.Business;
using Core.ServiceContract.Common;
using GeoCoordinatePortable;
using Microsoft.Extensions.Options;

namespace Core.Service.Business
{
    public class ProviderSrv : IProviderSrv
    {

        #region Property

        private readonly IRepository _repository;
        private readonly ISmsSrv _smsSrv;
        private readonly IServiceResultHelper _serviceResultHelper;
        private readonly IOptionsSnapshot<SiteSettings> _siteSettings;
        private readonly ICdnService _cdnService;


        #endregion Property

        #region Constructor

        public ProviderSrv(IRepository repository,
            ISmsSrv smsSrv,
            IServiceResultHelper serviceResultHelper,
            IOptionsSnapshot<SiteSettings> siteSettings,
            ICdnService cdnService)
        {
            _repository = repository;
            _serviceResultHelper = serviceResultHelper;
            _smsSrv = smsSrv;
            _siteSettings = siteSettings ?? throw new ArgumentNullException(nameof(_siteSettings));
            _cdnService = cdnService;
        }

        #endregion Constructor

        #region Methods

        public async Task<ServiceResult> AddProviderAsync(AddProviderRequest request)
        {
            var response = await _repository.Sp_AddProvider(
                new AddProviderParam()
                {
                    Name = request.Name.Trim(),
                    Code = request.Code,
                    ProviderTypeId = request.ProviderTypeId,
                    ProvinceId = request.ProvinceId,
                    CityId = request.CityId,
                    RegionId = request.RegionId,
                    Address = request.Address.Trim()
                });

            return _serviceResultHelper.Response(response);
        }

        public async Task<BasePagingResult<GetActiveProviderVm>> GetActiveProviderAsync(GetActiveProviderRequest request)
        {
            return await _repository.Sp_GetActiveProvider(new GetActiveProviderParam
            {
                PageNumber = request.PageNumber,
                PageRecord = request.PageRecord,
                SortColumn = request.SortColumn,
                SortOrder = request.SortOrder
            });
        }

        public async Task<BasePagingResult<GetProviderVm>> GetProviderAsync(GetProviderRequest request)
        {
            return await _repository.Sp_GetProvider(new GetProviderParam
            {
                PageNumber = request.PageNumber,
                PageRecord = request.PageRecord,
                SortColumn = request.SortColumn,
                SortOrder = request.SortOrder
            });
        }

        public async Task<ServiceResult> SetProviderCoordinateAsync(SetProviderCoordinateRequest request)
        {
            var response = await _repository.Sp_SetProviderCoordinate(
                new SetProviderCoordinateParam()
                {
                    Id = request.Id,
                    Latitudes = request.Latitudes,
                    Longitudes = request.Longitudes
                });

            return _serviceResultHelper.Response(response);
        }

        public async Task<ServiceResult> AddProviderUserMobileAsync(AddProviderUserMobileRequest request)
        {
            var confirmCode = AppHelper.GenerateRandomNo4digits();

            var response = await _repository.Sp_AddProviderUserMobile(
                new AddProviderUserMobileParam()
                {
                    Id = request.Id,
                    Mobile = request.Mobile,
                    ConfirmCode = confirmCode
                });

            await _smsSrv.SendConfirmationSmsAsync(new SendConfirmationSmsRequest() { MobileNumber = request.Mobile.Trim(), ConfirmCode = confirmCode.ToString() });
            return _serviceResultHelper.Response(response);
        }

        public async Task<ServiceResult> ConfirmProviderUserMobileAsync(ConfirmProviderUserMobileRequest request)
        {
            var response = await _repository.Sp_ConfirmProviderUserMobile(
                new ConfirmProviderUserMobileParam()
                {
                    Id = request.Id,
                    Mobile = request.Mobile,
                    ConfirmCode = request.ConfirmCode
                });

            return _serviceResultHelper.Response(response);
        }

        public async Task<ServiceResult> AddProviderUserAsync(AddProviderUserRequest request)
        {
            var response = await _repository.Sp_AddProviderUser(
                new AddProviderUserParam()
                {
                    Id = request.Id,
                    Username = request.Username,
                    Password = AppHelper.GetMD5HashData(request.Password)
                });

            return _serviceResultHelper.Response(response);
        }

        public async Task<GetProviderInfoVm> GetProviderInfoAsync()
        {
            var providerId = HttpContextExtensions.GetProviderId().Value;
            return
                await _repository.Sp_GetProviderInfo(new GetProviderInfoParam() {Id = providerId});
        }

        public async Task<ServiceResult> UpdateProviderInfoAsync(UpdateProviderInfoRequest request)
        {
            var providerId = HttpContextExtensions.GetProviderId().Value;

            //todo : add to cdn
            string logoPath = null;
            //if (request.Logo != null)
            //{
            //    logoPath = await _uploadService.SavePictureAsync(request.Logo, _siteSettings.Value.RootPath.ProviderLogo,$"Logo{providerId}");
            //    if (string.IsNullOrEmpty(logoPath))
            //        return null;
            //}

            var response = await _repository.Sp_UpdateProviderInfo(
                new UpdateProviderInfoParam()
                {
                    Id = providerId,
                    ZipCode = request.ZipCode,
                    AgentName = request.AgentName,
                    OfficialBill = request.OfficialBill,
                    Logo = logoPath,
                    Description = request.Description
                });

            return _serviceResultHelper.Response(response);
        }

        public async Task<IEnumerable<GetProviderUiVm>> GetProviderUiAsync() {
            var results =
                await _repository.Sp_GetProviderUi();

            if (results == null || results.Count() == 0)
                return null;

            var cdnFiles = await _cdnService.GetCdnManyFilePathAsync(results.Select(z => z.CdnFileId).ToArray());

            foreach (var result in results.ToList())
            {
                var photo = cdnFiles.FirstOrDefault(z => z.Id == result.CdnFileId);
                if (photo != null)
                    result.Photo = photo.Path;
            }

            return results;
        }

        public async Task<IEnumerable<GetClosestProviderUiVm>> GetClosestProviderUiAsync(GetClosestProviderUiRequest request)
        {
            var results = await _repository.Sp_GetProviderWithCoordinateUi();
            var response = new List<GetClosestProviderUiVm>();
            foreach (var item in results)
            {
                var pin1 = new GeoCoordinate((double)request.Latitudes, (double)request.Longitudes);
                var pin2 = new GeoCoordinate((double)item.Latitudes, (double)item.Longitudes);

                //meter
                double distanceBetween = pin1.GetDistanceTo(pin2);
                response.Add(new GetClosestProviderUiVm
                {
                    Id = item.Id,
                    Name = item.Name,
                    Code = item.Code,
                    Meter = (long)distanceBetween
                });
            }
            return response.OrderBy(z => z.Meter);
        }

        public async Task<IEnumerable<GetProviderLandingSideBarVm>> 
            GetProviderLandingSideBarAsync() => await _repository.Sp_GetProviderLandingSideBar();

        public async Task<GetProviderDetailUiVm> GetProviderDetailUiAsync(GetProviderDetailUiRequest request)
        {
            var results =
                await _repository.Sp_GetProviderDetailUi(new GetProviderDetailUiParam
                {
                    Id = request.Id,
                    Code = request.Code
                });

            if (results == null || results.Data1.Count() == 0)
                return null;

            var response = results.Data1.FirstOrDefault();

            if (results.Data2.Count() == 0)
                return response;

            var cdnFiles = await _cdnService.GetCdnManyFilePathAsync(results.Data2.Select(z => z).ToArray());

            if (cdnFiles != null)
                response.Photos = cdnFiles.Select(z => z.Path).ToList();

            return response;
        }


        #endregion

    }
}
