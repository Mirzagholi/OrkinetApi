using System.Threading.Tasks;
using Core.Common.ShareModels;
using Core.Models.Request.Business.Contact;

namespace Core.ServiceContract.Business
{
    public interface IContactUsSrv : IInjectableService
    {

        Task<ServiceResult> AddContactUsAsync(AddContactUsRequest request);
    }
}
