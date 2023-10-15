using System.Data;
using Core.Common.Base;

namespace Core.Models.Parameter.Business.Product
{
    public class CheckProductForCartParam : BaseParam
    {
        public DataTable Products { get; set; }
    }
}
