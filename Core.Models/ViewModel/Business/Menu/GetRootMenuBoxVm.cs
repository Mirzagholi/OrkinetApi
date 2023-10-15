using Core.Common.Base;

namespace Core.Models.ViewModel.Business.Menu
{
    public class GetRootMenuBoxVm : BaseDataResult
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Slug { get; set; }
        public string Image { get; set; }
        public int? CdnImageId  { get; set; }
    }
}
