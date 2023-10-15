using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Common.ShareContract;
using Core.DataContract;
using Core.Models.ViewModel.Business.CartDeliveryType;
using Core.ServiceContract.Business;

namespace Core.Service.Business
{
    public class CartDeliveryTypeSrv : ICartDeliveryTypeSrv
    {

        #region Property

        private readonly IRepository _repository;
        private readonly IServiceResultHelper _serviceResultHelper;

        #endregion Property

        #region Constructor

        public CartDeliveryTypeSrv(IRepository repository,
            IServiceResultHelper serviceResultHelper)
        {
            _repository = repository;
            _serviceResultHelper = serviceResultHelper;
        }

        #endregion Constructor

        #region Methods

        public async Task<IEnumerable<GetAllCartDeliveryTypeVm>> GetAllCartDeliveryTypeAsync() => await _repository.Sp_GetAllCartDeliveryType();

        #endregion
    }
}
