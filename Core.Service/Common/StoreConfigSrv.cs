using System.Threading.Tasks;
using Core.Common.ShareContract;
using Core.DataContract;
using Core.Models.ViewModel.Common.StoreConfig;
using Core.ServiceContract.Business;

namespace Core.Service.Business
{
    public class StoreConfigSrv : IStoreConfigSrv
    {
        #region Property

        private readonly IRepository _repository;
        private readonly IServiceResultHelper _serviceResultHelper;

        #endregion Property

        #region Constructor

        public StoreConfigSrv(IRepository repository,
            IServiceResultHelper serviceResultHelper)
        {
            _repository = repository;
            _serviceResultHelper = serviceResultHelper;
        }

        #endregion Constructor

        #region Methods

        public async Task<GetStoreConfigVm> GetStoreConfigAsync() => await _repository.Sp_GetStoreConfig();

        #endregion
    }
}
