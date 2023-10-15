using Core.Common.Base;

namespace Core.Models.Parameter.Business.Provider
{
    public class AddProviderUserParam : BaseParam
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public byte[] Password { get; set; }

    }
}
