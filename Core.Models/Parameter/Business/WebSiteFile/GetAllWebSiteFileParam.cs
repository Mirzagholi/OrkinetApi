using Core.Common.Base;
using Core.Models.Enum.Common;
using Core.Models.Enum.Business;


namespace Core.Models.Parameter.Business.WebSiteFile
{
    public class GetAllWebSiteFileParam : BasePagingParam
    {
        public WebSiteFileGroupType FileGroupTypeId { get; set; }    
    }
}
