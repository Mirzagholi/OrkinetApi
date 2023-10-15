using System.Threading.Tasks;
using Core.Common.Base;
using Core.Common.ShareContract;
using Core.Common.ShareModels;
using Core.DataContract;
using Core.Models.Parameter.Business.ProviderAbsorption;
using Core.Models.Request.Business.Cart;
using Core.Models.Request.Business.ProviderAbsorption;
using Core.Models.ViewModel.Business.Cart;
using Core.Models.ViewModel.Business.ProviderAbsorption;
using Core.ServiceContract.Business;

namespace Core.Service.Business
{
    public class ProviderAbsorptionSrv : IProviderAbsorptionSrv
    {

        #region Property

        private readonly IRepository _repository;
        private readonly IServiceResultHelper _serviceResultHelper;

        #endregion Property

        #region Constructor

        public ProviderAbsorptionSrv(IRepository repository,
            IServiceResultHelper serviceResultHelper)
        {
            _repository = repository;
            _serviceResultHelper = serviceResultHelper;
        }

        #endregion Constructor

        #region Methods

        public async Task<ServiceResult> AddProviderAbsorptionAsync(AddProviderAbsorptionRequest request)
        {
            await _repository.Sp_AddProviderAbsorption(
                new AddProviderAbsorptionParam()
                {
                    FirstName = request.FirstName.Trim(),
                    LastName = request.LastName.Trim(),
                    ProviderName = request.ProviderName.Trim(),
                    PhoneNumber = request.PhoneNumber.Trim(),
                    Description = request.Description
                });

            return _serviceResultHelper.Response(null);
        }

        public async Task<BasePagingResult<GetAllProviderAbsorptionVm>> GetAllProviderAbsorptionAsync(GetAllProviderAbsorptionRequest request)
        {
            return 
                await _repository.Sp_GetAllProviderAbsorption(new GetAllProviderAbsorptionParam
                {
                    PageNumber = request.PageNumber,
                    PageRecord = request.PageRecord,
                    SortColumn = request.SortColumn,
                    SortOrder = request.SortOrder
                });
        }


        #endregion

    }
}
