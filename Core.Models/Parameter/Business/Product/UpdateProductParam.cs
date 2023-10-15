using System.Data;
using Core.Common.Base;
using Core.Models.Enum.Business.Product;

namespace Core.Models.Parameter.Business.Product
{
    public class UpdateProductParam : BaseParam
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DataTable CategoryIdes { get; set; }
        public int ProviderId { get; set; }
        public DataTable Values { get; set; }
        public DataTable PrivateValues { get; set; }
        public PreparationType PreparationTypeId { get; set; }
        public string ShortDescription { get; set; }
        public string Description { get; set; }
    }
}
