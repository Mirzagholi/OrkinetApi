using Core.Common.Base;

namespace Core.Models.Parameter.Business.Provider
{
    public class UpdateProviderInfoParam : BaseParam
    {
        public int Id { get; set; }
        public string ZipCode { get; set; }
        public string AgentName { get; set; }
        public bool OfficialBill { get; set; }
        public string Logo { get; set; }
        public string Description { get; set; }
    }
}
