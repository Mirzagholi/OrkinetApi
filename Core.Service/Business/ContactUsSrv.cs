using System.Threading.Tasks;
using Core.Common.ShareContract;
using Core.Common.ShareModels;
using Core.DataContract;
using Core.Models.Parameter.Business.Contact;
using Core.Models.Request.Business.Contact;
using Core.ServiceContract.Business;

namespace Core.Service.Business
{
    public class ContactUsSrv : IContactUsSrv
    {
        #region Property

        private readonly IRepository _repository;
        private readonly IServiceResultHelper _serviceResultHelper;

        #endregion Property

        #region Constructor

        public ContactUsSrv(IRepository repository,
            IServiceResultHelper serviceResultHelper)
        {
            _repository = repository;
            _serviceResultHelper = serviceResultHelper;
        }

        #endregion Constructor

        #region Methods

        public async Task<ServiceResult> AddContactUsAsync(AddContactUsRequest request)
        {
            var response = await _repository.Sp_AddContactUs(
                new AddContactUsParam()
                {
                    FullName = request.FullName,
                    Subject = request.Subject,
                    Email = request.Email,
                    ContactUsTypeId = request.ContactUsTypeId,
                    Description = request.Description
                });

            return _serviceResultHelper.Response(response);
        }

        #endregion
    }
}
