using Core.Common.Base;
using System;

namespace Core.Models.ViewModel.Security.User
{
    public class UserConfirmCodeVm : BaseDataResult
    {
        public DateTime Expiration { get; set; }
        public bool IsSmsSended { get; set; }
    }
}
