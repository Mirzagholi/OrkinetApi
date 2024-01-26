using Core.Common.Base;
using Core.Models.Enum.Common;

namespace Core.Models.Request.Business.WebSiteFile
{
    public class GetAllWebSiteFileRequest : BasePagingRequest
    {
        public WebSiteFileGroupType FileGroupTypeId { get; set; }  

    }
}
