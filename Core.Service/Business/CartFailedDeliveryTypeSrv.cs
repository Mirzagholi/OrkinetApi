using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Common.ShareContract;
using Core.DataContract;
using Core.Models.ViewModel.Business.CartFailedDeliveryType;
using Core.ServiceContract.Business;

namespace Core.Service.Business
{
    public class CartFailedDeliveryTypeSrv : ICartFailedDeliveryTypeSrv
    {

        #region Property

        private readonly IRepository _repository;
        private readonly IServiceResultHelper _serviceResultHelper;

        #endregion Property

        #region Constructor

        public CartFailedDeliveryTypeSrv(IRepository repository,
            IServiceResultHelper serviceResultHelper)
        {
            _repository = repository;
            _serviceResultHelper = serviceResultHelper;
        }

        #endregion Constructor

        #region Methods

        public async Task<IEnumerable<GetAllCartFailedDeliveryTypeVm>> GetAllCartFailedDeliveryTypeAsync() => await _repository.Sp_GetAllCartFailedDeliveryType();

        #endregion
    }
}
