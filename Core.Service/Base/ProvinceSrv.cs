using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Common.ShareContract;
using Core.DataContract;
using Core.Models.ViewModel.Base.Province;
using Core.ServiceContract.Base;

namespace Core.Service.Base
{
    public class ProvinceSrv : IProvinceSrv
    {

        #region Property

        private readonly IRepository _repository;
        private readonly IServiceResultHelper _serviceResultHelper;
        #endregion Property

        #region Constructor


        public ProvinceSrv(IRepository repository,
            IServiceResultHelper serviceResultHelper)
        {
            _repository = repository;
            _serviceResultHelper = serviceResultHelper;
        }

        #endregion Constructor

        #region Methods

        public async Task<IEnumerable<GetProvinceVm>> GetProvinceAsync() => await _repository.Sp_GetProvince();

        #endregion
    }
}
