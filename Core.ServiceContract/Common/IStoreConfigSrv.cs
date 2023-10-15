using Core.Models.ViewModel.Common.StoreConfig;
using System.Threading.Tasks;

namespace Core.ServiceContract.Business
{
    public interface IStoreConfigSrv : IInjectableService
    {
        Task<GetStoreConfigVm> GetStoreConfigAsync();
    }
}
