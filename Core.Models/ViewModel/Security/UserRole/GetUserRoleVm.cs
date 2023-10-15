using Core.Common.Base;

namespace Core.Models.ViewModel.Security.UserRole
{
    public class GetUserRoleVm : BaseDataResult
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
