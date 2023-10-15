using Core.Common.Base;

namespace Core.Models.Parameter.Business.Product
{
    public class GetProductParam : BasePagingParam
    {
        public int ProviderId { get; set; }
    }
}
