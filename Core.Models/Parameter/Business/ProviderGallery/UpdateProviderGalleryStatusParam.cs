using Core.Common.Base;
using Core.Models.Enum.Common;

namespace Core.Models.Parameter.Business.ProviderGallery
{
    public class UpdateProviderGalleryStatusParam : BaseParam
    {
        public int Id { get; set; }
        public StatusType StatusId { get; set; }
    }
}
