using Core.Common.Base;

namespace Core.Models.Request.Business.Cart
{
    public class SetProviderCartStatusRequest : BaseRequest
    {
        /// <summary>
        ///  شناسه سبد خرید
        /// </summary>
        public int CartId { get; set; }

        /// <summary>
        /// شناسه وضعیت
        /// </summary>
        public int StatusId { get; set; }

        /// <summary>
        /// توضیحات
        /// </summary>
        public string Description { get; set; }
    }
}
