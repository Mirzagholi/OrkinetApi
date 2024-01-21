using System.Data;
using Core.Common.Base;
using Core.Models.Enum.Business.Product;

namespace Core.Models.Parameter.Business.Product
{
    public class GetCheapestProductUiParam : BaseParam
    {
        public int MenuId { get; set; }
        public int? StartingPrice { get; set; }
        public int? EndingPrice { get; set; }
        public DataTable ProviderIdes { get; set; }
        public DataTable SideBarIdes { get; set; }
        public int? PageNumber { get; set; }
        public int? PageRecord { get; set; }
    }


    public class GetFirstPageProductUiParam : BaseParam
    {
        public int? CategoryId { get; set; }
        public ProductListType ProductListTypeId { get; set; }
        public int? PageRecord { get; set; }

        
    }
}
