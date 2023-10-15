using Core.Common.Base;
using System.Data;

namespace Core.Models.Parameter.Business.Cart
{
    public class SetCartDeliveryPriceParam : BaseParam
    {
        public int UserId { get; set; }
        public int CartId { get; set; }
        public DataTable Distance { get; set; }
    }
}
