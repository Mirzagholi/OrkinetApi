using Core.Common.Base;
using System.Data;

namespace Core.Models.Parameter.Business.Cart
{
    public class AddCartParam : BaseParam
    {
        public int UserId { get; set; }
        public DataTable Products { get; set; }
    }
}
