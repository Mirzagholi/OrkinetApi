using System.ComponentModel.DataAnnotations;
using Core.Common.Base;
using Microsoft.AspNetCore.Http;

namespace Core.Models.Request.Business.WebSiteFile
{
    public class AddWebSiteFileRequest : BaseRequest
    {
        /// <summary>
        /// فایل
        /// </summary>
        [DataType(DataType.Upload)]
        public IFormFile File { get; set; }

        /// <summary>
        /// شناسه تامین کننده
        /// </summary>
        public string Title { get; set; }
    }
}
