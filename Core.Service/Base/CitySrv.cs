using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Common.ShareContract;
using Core.DataContract;
using Core.Models.Parameter.Base.City;
using Core.Models.Parameter.Base.Region;
using Core.Models.ViewModel.Base.City;
using Core.Models.ViewModel.Base.Region;
using Core.ServiceContract.Base;

namespace Core.Service.Base
{
    public class CitySrv : ICitySrv
    {

        #region Property

        private readonly IRepository _repository;
        private readonly IServiceResultHelper _serviceResultHelper;
        #endregion Property

        #region Constructor


        public CitySrv(IRepository repository,
            IServiceResultHelper serviceResultHelper)
        {
            _repository = repository;
            _serviceResultHelper = serviceResultHelper;
        }

        #endregion Constructor

        #region Methods

        public async Task<IEnumerable<GetCityVm>> GetCityAsync(int provinceId) => await _repository.Sp_GetCity(new GetCityParam() { ProvinceId = provinceId });

        #endregion
    }
}
