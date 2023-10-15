using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Common.ShareContract;
using Core.DataContract;
using Core.Models.Parameter.Base.District;
using Core.Models.Parameter.Base.Region;
using Core.Models.ViewModel.Base.District;
using Core.Models.ViewModel.Base.Region;
using Core.ServiceContract.Base;

namespace Core.Service.Base
{
    public class DistrictSrv : IDistrictSrv
    {

        #region Property

        private readonly IRepository _repository;
        private readonly IServiceResultHelper _serviceResultHelper;
        #endregion Property

        #region Constructor


        public DistrictSrv(IRepository repository,
            IServiceResultHelper serviceResultHelper)
        {
            _repository = repository;
            _serviceResultHelper = serviceResultHelper;
        }

        #endregion Constructor

        #region Methods

        public async Task<IEnumerable<GetDistrictVm>> GetDistrictAsync(int cityId) => await _repository.Sp_GetDistrict(new GetDistrictParam() { CityId = cityId });

        #endregion
    }
}
