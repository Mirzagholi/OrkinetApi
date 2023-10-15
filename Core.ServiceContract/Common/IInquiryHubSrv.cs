using System.Collections.Generic;
using System.Threading.Tasks;

namespace Core.ServiceContract.Common
{
    public interface IInquiryHubSrv : IInjectableService
    {
        Task SendAdminNotifyAsync();
        Task SendProviderNotifyAsync(string providerId);
        Task SendProviderNotifyAsync(List<string> providerIdes);
        Task SendUserNotifyAsync(string userId);
        Task SendUserNotifyAsync(List<string> userIdes);
    }
}
