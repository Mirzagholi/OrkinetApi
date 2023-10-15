using Core.Common.Base;
using System.Data;

namespace Core.Models.Parameter.Business.Cart
{
    public class SetProviderCartStatusParam : BaseParam
    {
        public int ProviderId { get; set; }

        public int CartId { get; set; }

        public int StatusId { get; set; }

        public string Description { get; set; }
    }
}
