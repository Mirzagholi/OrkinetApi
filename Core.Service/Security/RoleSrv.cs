using Core.DataContract;
using Core.ServiceContract.Security;
using Core.Common.ShareContract;
using System;

namespace Core.Service.Security
{
    public class RoleSrv : IRoleSrv
    {

        #region Property

        private readonly IRepository _repository;
        private readonly IServiceResultHelper _serviceResultHelper;

        #endregion Property

        #region Constructor


        public RoleSrv(
            IRepository repository,
            IServiceResultHelper serviceResultHelper)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));

            _serviceResultHelper = serviceResultHelper ?? throw new ArgumentNullException(nameof(serviceResultHelper));
        }

        #endregion Constructor

        #region Methods



        #endregion Methods

    }
}
