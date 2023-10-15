using Core.Models.ViewModel.Business.Index;
using System.Threading.Tasks;

namespace Core.ServiceContract.Business
{
    public interface IIndexSrv : IInjectableService
    {
        Task<GetProviderIndexDataVm> GetProviderIndexDataAsync();
    }
}
