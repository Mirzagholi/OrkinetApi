using Core.Common.Base;
using System.Collections.Generic;
using System.Data;

namespace Core.Models.Parameter.Business.ProviderGallery
{
    public class AddProviderGalleryParam : BaseParam
    {
        public int ProviderId { get; set; }
        public DataTable CdnFileIdes { get; set; }
    }
}
