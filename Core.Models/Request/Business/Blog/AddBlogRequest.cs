using Core.Common.Base;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace Core.Models.Request.Business.Blog
{
    public class AddBlogRequest : BaseRequest
    {
        /// <summary>
        /// نام
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// تصویر 
        /// </summary>
        [DataType(DataType.Upload)]
        public IFormFile File { get; set; }

        /// <summary>
        /// نام خانوادگی
        /// </summary>
        public string Text { get; set; }
    }
}
