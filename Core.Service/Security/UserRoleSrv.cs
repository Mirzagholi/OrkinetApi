using System.Threading.Tasks;
using Core.DataContract;
using Core.ServiceContract.Security;
using Core.Common.ShareContract;
using System;
using System.Collections.Generic;
using Core.Models.Parameter.Security.UserRole;
using Core.Models.ViewModel.Security.UserRole;

namespace Core.Service.Security
{
    public class UserRoleSrv : IUserRoleSrv
    {

        #region Property

        private readonly IRepository _repository;
        private readonly IServiceResultHelper _serviceResultHelper;

        #endregion Property

        #region Constructor


        public UserRoleSrv(
            IRepository repository,
            IServiceResultHelper serviceResultHelper)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));

            _serviceResultHelper = serviceResultHelper ?? throw new ArgumentNullException(nameof(serviceResultHelper));
        }

        #endregion Constructor

        #region Methods

        public async Task<IEnumerable<GetUserRoleVm>> FindUserRolesAsync(int userId)
        {
            return
                await _repository.Sp_GetUserRole(new GetUserRoleParam() { UserId = userId });
        }

        #endregion Methods

    }
}
