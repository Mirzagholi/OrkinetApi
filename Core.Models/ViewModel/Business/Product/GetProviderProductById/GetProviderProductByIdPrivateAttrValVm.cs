using Core.Common.Base;

namespace Core.Models.ViewModel.Business.Product.GetProviderProductById
{
    public class GetProviderProductByIdPrivateAttrValVm : BaseDataResult
    {
        public int PrivateAttributeId { get; set; }
        public int PrivateValueId { get; set; }
    }
}
