using Core.Common.Base;

namespace Core.Models.ViewModel.Security.User
{
    public class AdminAuthenticateVm : BaseDataResult
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string RoleName { get; set; }
        public string Token { get; set; }

    }
}
