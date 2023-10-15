using Core.Common.Base;
using System.Data;

namespace Core.Models.Parameter.Business.Cart
{
    public class GetCartUserCoordinateParam : BaseParam
    {
        public int UserId { get; set; }
        public int CartId { get; set; }
    }
}
