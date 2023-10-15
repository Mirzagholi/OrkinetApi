using Core.Common.Base;
using Core.Models.Enum.Business.Contact;

namespace Core.Models.Request.Business.Contact
{
    public class AddContactUsRequest : BaseRequest
    {
        /// <summary>
        /// نام و نام خانوادگی
        /// </summary>
        public string FullName { get; set; }

        /// <summary>
        /// ایمیل
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// موضوع
        /// </summary>
        public string Subject { get; set; }

        /// <summary>
        /// شناسه نوع فرم 
        /// </summary>
        public MessageContactType ContactUsTypeId { get; set; }

        /// <summary>
        /// توضیحات
        /// </summary>
        public string Description { get; set; }
    }
}
