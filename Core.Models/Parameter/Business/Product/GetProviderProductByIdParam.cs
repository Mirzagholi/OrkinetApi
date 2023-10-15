using Core.Common.Base;

namespace Core.Models.Parameter.Business.Product
{
    public class GetProviderProductByIdParam : BaseParam
    {
        public int Id { get; set; }
        public int ProviderId { get; set; }
    }
}
