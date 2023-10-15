using Core.Common.Base;

namespace Core.Models.ViewModel.Business.Provider
{
    public class GetProviderUiVm : BaseDataResult
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public int Rating { get; set; }
        public int CdnFileId { get; set; }
        public string Photo { get; set; }
    }
}
