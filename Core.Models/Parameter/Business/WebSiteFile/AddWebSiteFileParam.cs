using Core.Common.Base;
using System.Collections.Generic;
using System.Data;

namespace Core.Models.Parameter.Business.WebSiteFile
{
    public class AddWebSiteFileParam : BaseParam
    {
        public string Title { get; set; }
        public int CdnFileId { get; set; }
    }
}
