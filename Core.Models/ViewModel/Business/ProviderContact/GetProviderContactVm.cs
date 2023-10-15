using Core.Common.Base;
using Core.Models.Enum.Common;
using Core.Models.Helper;

namespace Core.Models.ViewModel.Business.ProviderContact
{
    public class GetProviderContactVm : BaseDataResult
    {
        public int Id { get; set; }
        public string ContactValue { get; set; }
        public ContactType ContactTypeId { get; set; }
        public string ContactTypeText => ContactTypeId.GetContactTypeTextByCulture();
        public bool ProvinceId { get; set; }
    }
}
