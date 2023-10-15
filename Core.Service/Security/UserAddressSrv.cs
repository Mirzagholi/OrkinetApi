using System.Threading.Tasks;
using Core.Common.Extensions;
using Core.DataContract;
using Core.ServiceContract.Security;
using Core.Common.ShareModels;
using Core.Common.ShareContract;
using Core.Models.Request.Security.UserAddress;
using Core.Models.Parameter.Security.UserAddress;
using Core.Models.ViewModel.Security.UserAddress;
using System.Collections.Generic;

namespace Core.Service.Security
{
    public class UserAddressSrv : IUserAddressSrv
    {

        #region Property

        private readonly IRepository _repository;
        private readonly IServiceResultHelper _serviceResultHelper;

        #endregion Property

        #region Constructor

        public UserAddressSrv(IRepository repository, IServiceResultHelper serviceResultHelper)
        {
            _repository = repository;
            _serviceResultHelper = serviceResultHelper;
        }

        #endregion Constructor

        #region Methods

        public async Task<GetDefaultUserAddressVm> GetDefaultUserAddressAsync()
        {
            var userId = HttpContextExtensions.GetUserId().Value;
            return
                await _repository.Sp_GetDefaultUserAddress(new GetDefaultUserAddressParam() { UserId = userId });
        }

        public async Task<GetUserAddressByIdVm> GetUserAddressByIdAsync(GetUserAddressByIdRequest request)
        {
            var userId = HttpContextExtensions.GetUserId().Value;
            return
                await _repository.Sp_GetUserAddressById(new GetUserAddressByIdParam() 
                {
                    Id = request.Id,
                    UserId = userId 
                });
        }

        public async Task<ServiceResult> AddUserAddressAsync(AddUserAddressRequest request)
        {
            var userId = HttpContextExtensions.GetUserId().Value;
            var response = await _repository.Sp_AddUserAddress(
                new AddUserAddressParam()
                {
                    UserId = userId,
                    ProvinceId = request.ProvinceId,
                    CityId = request.CityId,
                    DistrictId = request.DistrictId,
                    Address = request.Address,
                    ZipCode = request.ZipCode,
                    HouseNumber = request.HouseNumber,
                    HouseUnit = request.HouseUnit,
                    Latitudes = request.Latitudes,
                    Longitudes = request.Longitudes,
                    FirstName = request.FirstName,
                    LastName = request.LastName,
                    DeliveredToMe = request.DeliveredToMe,
                    MobileNumber = request.MobileNumber

                });

            return _serviceResultHelper.Response(response);
        }

        public async Task<ServiceResult> DeleteUserAddressAsync(DeleteUserAddressRequest request)
        {
            var userId = HttpContextExtensions.GetUserId().Value;
            var response = await _repository.Sp_DeleteUserAddress(
                new DeleteUserAddressParam()
                {
                    Id = request.Id,
                    UserId = userId
                });

            return _serviceResultHelper.Response(response);
        }

        public async Task<ServiceResult> UpdateUserAddressAsync(UpdateUserAddressRequest request)
        {
            var userId = HttpContextExtensions.GetUserId().Value;
            var response = await _repository.Sp_UpdateUserAddress(
                new UpdateUserAddressParam()
                {
                    Id = request.Id,
                    UserId = userId,
                    ProvinceId = request.ProvinceId,
                    CityId = request.CityId,
                    DistrictId = request.DistrictId,
                    Address = request.Address,
                    ZipCode = request.ZipCode,
                    HouseNumber = request.HouseNumber,
                    HouseUnit = request.HouseUnit,
                    Latitudes = request.Latitudes,
                    Longitudes = request.Longitudes,
                    FirstName = request.FirstName,
                    LastName = request.LastName,
                    DeliveredToMe = request.DeliveredToMe,
                    MobileNumber = request.MobileNumber

                });

            return _serviceResultHelper.Response(response);
        }

        public async Task<IEnumerable<GetAllUserAddressVm>> GetAllUserAddressAsync()
        {
            var userId = HttpContextExtensions.GetUserId().Value;
            return
                await _repository.Sp_GetAllUserAddress(new GetAllUserAddressParam(){ UserId = userId });
        }

        #endregion Methods

    }
}
