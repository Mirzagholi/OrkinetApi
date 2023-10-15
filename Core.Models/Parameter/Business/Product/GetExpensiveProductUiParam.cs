using System.Data;
using Core.Common.Base;

namespace Core.Models.Parameter.Business.Product
{
    public class GetExpensiveProductUiParam : BaseParam
    {
        public int MenuId { get; set; }
        public int? StartingPrice { get; set; }
        public int? EndingPrice { get; set; }
        public DataTable ProviderIdes { get; set; }
        public DataTable SideBarIdes { get; set; }
        public int? PageNumber { get; set; }
        public int? PageRecord { get; set; }
    }
}
