using Core.Common.Base;

namespace Core.Models.Parameter.Business.Provider
{
    public class AddProviderUserMobileParam : BaseParam
    {
        public int Id { get; set; }
        public string Mobile { get; set; }
        public int ConfirmCode { get; set; }
    }
}
