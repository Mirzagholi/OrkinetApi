using Core.Common.Base;

namespace Core.Models.Parameter.Business.ProviderAbsorption
{
    public class AddProviderAbsorptionParam : BaseParam
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string ProviderName { get; set; }

        public string PhoneNumber { get; set; }

        public string Description { get; set; }
    }
}
