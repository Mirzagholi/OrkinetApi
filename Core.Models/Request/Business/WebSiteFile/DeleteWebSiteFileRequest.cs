using System.ComponentModel.DataAnnotations;
using Core.Common.Base;
using Microsoft.AspNetCore.Http;

namespace Core.Models.Request.Business.WebSiteFile
{
    public class DeleteWebSiteFileRequest : BaseRequest
    {
        /// <summary>
        /// شناسه فایل
        /// </summary>
        public int Id { get; set; }
    }
}
