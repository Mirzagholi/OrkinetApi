using Core.Common.Base;

namespace Core.Models.ViewModel.Security.User
{
    public class ProviderAuthenticateVm : BaseDataResult
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string FullName { get; set; }
        public string RoleName { get; set; }
        public int ProviderId { get; set; }
        public string Token { get; set; }

    }
}
