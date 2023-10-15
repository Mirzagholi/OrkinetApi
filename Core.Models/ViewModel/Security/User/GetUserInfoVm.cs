using System;
using Core.Common.Base;
using Core.Models.Enum.Security;
using Core.Models.Helper;

namespace Core.Models.ViewModel.Security.User
{
    public class GetUserInfoVm : BaseDataResult
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public GenderType GenderTypeId { get; set; }
        public string GenderTypeText => GenderTypeId.GetGenderTypeTextByCulture();
        public string Avatar { get; set; }
        public string Mobile { get; set; }
        public string Email { get; set; }
        public DateTime CreatedOn { get; set; }
    }
}
