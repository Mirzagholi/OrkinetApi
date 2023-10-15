using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Common.Extensions;
using Core.Common.ShareContract;
using Core.Common.ShareModels;
using Core.DataContract;
using Core.Models.Parameter.Business.ProviderContact;
using Core.Models.Request.Business.ProviderContact;
using Core.Models.ViewModel.Business.ProviderContact;
using Core.ServiceContract.Business;

namespace Core.Service.Business
{
    public class ProviderContactSrv : IProviderContactSrv
    {

        #region Property

        private readonly IRepository _repository;
        private readonly IServiceResultHelper _serviceResultHelper;

        #endregion Property

        #region Constructor


        public ProviderContactSrv(IRepository repository,
            IServiceResultHelper serviceResultHelper)
        {
            _repository = repository;
            _serviceResultHelper = serviceResultHelper;
        }

        #endregion Constructor

        #region Methods

        public async Task<ServiceResult> AddProviderContactAsync(AddProviderContactRequest request)
        {
            var providerId = HttpContextExtensions.GetProviderId().Value;
            var response = await _repository.Sp_AddProviderContact(
                new AddProviderContactParam()
                {
                    ContactValue = request.ContactValue.Trim(),
                    ContactTypeId = request.ContactTypeId,
                    ProviderId = providerId
                });

            return _serviceResultHelper.Response(response);
        }

        public async Task<IEnumerable<GetProviderContactVm>> GetProviderContactAsync()
        {
            var providerId = HttpContextExtensions.GetProviderId().Value;
            return
                await _repository.Sp_GetProviderContact(new GetProviderContactParam() { ProviderId = providerId });
        }

        public async Task<ServiceResult> DeleteProviderContactAsync(DeleteProviderContactRequest request)
        {
            var providerId = HttpContextExtensions.GetProviderId().Value;
            var response = await _repository.Sp_DeleteProviderContact(
                new DeleteProviderContactParam()
                {
                    Id = request.Id,
                    ProviderId = providerId
                });

            return _serviceResultHelper.Response(response);
        }

        //public async Task<BasePagingResult<GetProviderVm>> GetProviderAsync(GetProviderRequest request)
        //{
        //    return await _repository.Sp_GetProvider(new GetProviderParams
        //    {
        //        PageNumber = request.PageNumber,
        //        PageRecord = request.PageRecord,
        //        SortColumn = request.SortColumn,
        //        SortOrder = request.SortOrder
        //    });
        //}

        //public async Task<ServiceResult> SetProviderCoordinateAsync(SetProviderCoordinateRequest request)
        //{
        //    var response = await _repository.Sp_SetProviderCoordinate(
        //        new SetProviderCoordinateParams()
        //        {
        //            Id = request.Id,
        //            Latitudes = request.Latitudes,
        //            Longitudes = request.Longitudes
        //        });

        //    return _serviceResultHelper.Response(response);
        //}

        //public async Task<ServiceResult> AddProviderUserMobileAsync(AddProviderUserMobileRequest request)
        //{
        //    var confirmCode = AppHelper.GenerateRandomNo4digits();

        //    //todo : send sms 
        //    var response = await _repository.Sp_AddProviderUserMobile(
        //        new AddProviderUserMobileParams()
        //        {
        //            Id = request.Id,
        //            Mobile = request.Mobile,
        //            ConfirmCode = confirmCode
        //        });

        //    return _serviceResultHelper.Response(response);
        //}

        //public async Task<ServiceResult> ConfirmProviderUserMobileAsync(ConfirmProviderUserMobileRequest request)
        //{
        //    var response = await _repository.Sp_ConfirmProviderUserMobile(
        //        new ConfirmProviderUserMobileParams()
        //        {
        //            Id = request.Id,
        //            Mobile = request.Mobile,
        //            ConfirmCode = request.ConfirmCode
        //        });

        //    return _serviceResultHelper.Response(response);
        //}

        //public async Task<ServiceResult> AddProviderUserAsync(AddProviderUserRequest request)
        //{
        //    var response = await _repository.Sp_AddProviderUser(
        //        new AddProviderUserParams()
        //        {
        //            Id = request.Id,
        //            Username = request.Username,
        //            Password = AppHelper.GetMD5HashData(request.Password)
        //        });

        //    return _serviceResultHelper.Response(response);
        //}

        //public async Task<GetProviderInfoVm> GetProviderInfoAsync()
        //{
        //    var providerId = HttpContextExtensions.GetProviderId().Value;
        //    return
        //        await _repository.Sp_GetProviderInfo(new GetProviderInfoParams() {Id = providerId});
        //}

        //public async Task<ServiceResult> UpdateProviderInfoAsync(UpdateProviderInfoRequest request)
        //{
        //    var logoPath = string.Empty;
        //    if (request.Logo != null)
        //    {
        //        logoPath = await _uploadService.SavePictureAsync(request.Logo, _siteSettings.Value.RootPath.ProviderLogo);
        //        if (string.IsNullOrEmpty(logoPath))
        //        {
        //            //response.SetResultCode(ServiceResponseKey.Slider_UploadImage_Failed);
        //            return null;
        //        }
        //    }

        //var providerId = HttpContextExtensions.GetProviderId().Value;
        //    var response = await _repository.Sp_UpdateProviderInfo(
        //        new UpdateProviderInfoParams()
        //        {
        //            Id = providerId,
        //            ZipCode = request.ZipCode,
        //            AgentName = request.AgentName,
        //            OfficialBill = request.OfficialBill,
        //            Logo = logoPath,
        //            Description = request.Description
        //        });

        //    return _serviceResultHelper.Response(response);
        //}

        #endregion
    }
}
