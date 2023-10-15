using System.Threading.Tasks;

namespace Core.Service.Hubs.Inquiry
{
    public interface IInquiryClient
    {
        Task AdminInquiryNotify();
        Task ProviderInquiryNotify();
        Task UserInquiryNotify();
    }
}
