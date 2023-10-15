using Core.Common.Base;

namespace Core.Models.ViewModel.Business.Product
{
    public class GetAllProductAttrValForAdminVm : BaseDataResult
    {
        public int ProductId { get; set; }
        public int AttributeId { get; set; }
        public string AttributeName { get; set; }
        public int ValueId { get; set; }
        public string ValueName { get; set; }
    }
}
