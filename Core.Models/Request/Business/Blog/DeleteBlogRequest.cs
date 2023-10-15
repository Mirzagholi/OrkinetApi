using Core.Common.Base;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace Core.Models.Request.Business.Blog
{
    public class DeleteBlogRequest : BaseRequest
    {
        /// <summary>
        /// شناسه
        /// </summary>
        public int Id { get; set; }
       
    }
}
