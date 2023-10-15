using Core.Common.Base;
using System;

namespace Core.Models.ViewModel.Security.User
{
    public class FindUserByIdVm : BaseDataResult
    {
        public int Id { get; set; }

        public string Username { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public int ProviderId { get; set; }

        public string ProviderName { get; set; }

        public string DisplayName => $"{FirstName} {LastName}";

        public bool IsActive { get; set; }

        public DateTime? LastLoggedIn { get; set; }

        public Guid SerialNumber { get; set; }
    }
}
