using Core.Common.Base;

namespace Core.Models.ViewModel.Business.PostalCart
{
    public class GetAllPostalCartVm : BaseDataResult
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Text { get; set; }
    }
}
