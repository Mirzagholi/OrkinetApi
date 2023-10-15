using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Common.ShareModels;
using Core.Models.Request.Security.UserAddress;
using Core.Models.ViewModel.Security.UserAddress;

namespace Core.ServiceContract.Security
{
    public interface IUserAddressSrv : IInjectableService
    {
        Task<IEnumerable<GetAllUserAddressVm>> GetAllUserAddressAsync();
        Task<GetUserAddressByIdVm> GetUserAddressByIdAsync(GetUserAddressByIdRequest request);
        Task<GetDefaultUserAddressVm> GetDefaultUserAddressAsync();
        Task<ServiceResult> AddUserAddressAsync(AddUserAddressRequest request);
        Task<ServiceResult> UpdateUserAddressAsync(UpdateUserAddressRequest request);
        Task<ServiceResult> DeleteUserAddressAsync(DeleteUserAddressRequest request);
    }
}
