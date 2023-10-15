using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Core.Common.Base;
using Microsoft.AspNetCore.Http;

namespace Core.Models.Request.Business.ProviderGallery
{
    public class AddProviderGalleryRequest : BaseRequest
    {
        /// <summary>
        /// تصویر ها
        /// </summary>
        [DataType(DataType.Upload)]
        public List<IFormFile> Files { get; set; }

        /// <summary>
        /// شناسه تامین کننده
        /// </summary>
        public int ProviderId { get; set; }
    }
}
