using System.Threading.Tasks;
using Core.Common.Helpers;
using Core.DataContract;
using Core.Common.ShareModels;
using Core.Common.ShareContract;
using Core.Models.Parameter.Security.Provider;
using Core.Models.Request.Security.Provider;
using Core.ServiceContract.Security;
using Core.Models.ViewModel.Security.Provider;
using Core.Models.ViewModel.Security.Jwt;
using Core.Models.Request.Security.User;
using Core.Models.ViewModel.Security.User;
using Core.Models.Parameter.Security.User;

namespace Core.Service.Security
{
    public class ProviderSrv : IProviderSrv
    {

        #region Property
        IRepository _repository { get; set; }
        IJwtService _jwtService { get; set; }
        IServiceResultHelper _serviceResultHelper { get; set; }
        #endregion Property

        #region Constructor


        public ProviderSrv(IRepository repository, IJwtService jwtService, IServiceResultHelper serviceResultHelper)
        {
            _repository = repository;
            _jwtService = jwtService;
            _serviceResultHelper = serviceResultHelper;
        }

        #endregion Constructor

        #region Methods

        //public Task<GetUserByIdVm> GetProviderByIdAsync(int id) => _repository.Sp_GetUserById(new GetUserByIdParams() { Id = id });

        #endregion Methods

    }
}
