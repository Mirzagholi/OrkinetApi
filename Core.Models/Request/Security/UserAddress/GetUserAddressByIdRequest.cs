using Core.Common.Base;

namespace Core.Models.Request.Security.UserAddress
{
    public class GetUserAddressByIdRequest : BaseRequest
    {
        /// <summary>
        /// شناسه
        /// </summary>
        public int Id { get; set; }
    }
}
