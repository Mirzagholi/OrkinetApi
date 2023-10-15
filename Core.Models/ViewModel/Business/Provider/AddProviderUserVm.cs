using Core.Common.Base;
using Core.Models.Enum.Common;
using Core.Models.Helper;

namespace Core.Models.ViewModel.Business.Provider
{
    public class AddProviderUserVm : BaseDataResult
    {
        public int Id { get; set; }
        public StatusType StatusId { get; set; }
        public string StatusText => StatusId.GetStatusTextByCulture();
    }
}
