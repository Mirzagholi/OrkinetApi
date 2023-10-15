using Core.Common.Base;

namespace Core.Models.ViewModel.Business.Provider
{
    public class GetProviderLandingSideBarVm : BaseDataResult
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
    }
}
