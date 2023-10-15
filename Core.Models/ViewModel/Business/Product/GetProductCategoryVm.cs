using Core.Common.Base;

namespace Core.Models.ViewModel.Business.Product
{
    public class GetProductCategoryVm : BaseDataResult
    {
        public int ProductId { get; set; }
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
    }
}
