using Core.Common.Base;

namespace Core.Models.ViewModel.Business.Product
{
    public class GetClosestProviderUiVm : BaseDataResult
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public long Meter { get; set; }
    }
}
