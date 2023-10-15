using Core.Common.Base;
using System;

namespace Core.Models.ViewModel.Security.User
{
    public class LoginOrRegisterVm : BaseDataResult
    {
        public bool ExistUser { get; set; }
        public DateTime? Expiration { get; set; }
    }
}
