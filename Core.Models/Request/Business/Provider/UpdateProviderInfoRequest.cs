using System.ComponentModel.DataAnnotations;
using Core.Common.Base;
using Microsoft.AspNetCore.Http;

namespace Core.Models.Request.Business.Provider
{
    public class UpdateProviderInfoRequest : BaseRequest
    {
        /// <summary>
        /// کد پستی
        /// </summary>
        public string ZipCode { get; set; }

        /// <summary>
        /// نام و نام خانوادگی اپراتور
        /// </summary>
        public string AgentName { get; set; }

        /// <summary>
        /// سند مالی دارد
        /// </summary>
        public bool OfficialBill { get; set; }


        //[Display(ResourceType = typeof(SliderResources), Name = "Slider_Photo_Display")]
        //[Required(ErrorMessageResourceType = typeof(ValidationResources),
        //    ErrorMessageResourceName = "MetaData_Required")]
        //[UploadFileExtensions(StaticAnnotationMetaHelper.PhotoExtension,
        //    ErrorMessageResourceType = typeof(ValidationResources), ErrorMessageResourceName = "MetaData_PhotoExtensions")]


        /// <summary>
        /// لوگو
        /// </summary>
        [DataType(DataType.Upload)]
        public IFormFile Logo { get; set; }

        /// <summary>
        /// توضیحات
        /// </summary>
        public string Description { get; set; }
    }
}
