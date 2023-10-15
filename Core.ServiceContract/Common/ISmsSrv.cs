using System.Threading.Tasks;
using Core.Models.Request.Common.Sms;
using Core.Models.ViewModel.Common.Sms;

namespace Core.ServiceContract.Common
{
    public interface ISmsSrv : IInjectableService
    {
        Task<SendConfirmationSmsVm> SendConfirmationSmsAsync(SendConfirmationSmsRequest request);
        Task<SendInquirySmsVm> SendInquirySmsAsync(SendInquirySmsRequest request);
        Task<PaidOrderSmsVm> PaidOrderSmsAsync(PaidOrderSmsRequest request);
        Task<PaidProviderOrderSmsVm> PaidProviderOrderSmsAsync(PaidProviderOrderSmsRequest request);
        Task<PaidAdminOrderSmsVm> PaidAdminOrderSmsAsync(PaidAdminOrderSmsRequest request);
    }
}
