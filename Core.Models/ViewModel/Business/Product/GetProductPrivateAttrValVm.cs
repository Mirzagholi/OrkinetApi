using Core.Common.Base;

namespace Core.Models.ViewModel.Business.Product
{
    public class GetProductPrivateAttrValVm : BaseDataResult
    {
        public int ProductId { get; set; }
        public int PrivateAttributeId { get; set; }
        public string PrivateAttributeName { get; set; }
        public int PrivateValueId { get; set; }
        public string PrivateValueName { get; set; }
    }
}
