using System.Data;
using Core.Common.Base;
using Core.Models.Enum.Business.Product;

namespace Core.Models.Parameter.Business.Product
{
    public class AddProductParam : BaseParam
    {
        public string Name { get; set; }
        public DataTable CategoryIdes { get; set; }
        public int ProviderId { get; set; }
        public int Price { get; set; }
        public DataTable ValueIdes { get; set; }
        public DataTable PrivateValueIdes { get; set; }
        public DataTable ProviderGalleryIdes { get; set; }
        public PreparationType PreparationTypeId { get; set; }
        public string ShortDescription { get; set; }
        public string Description { get; set; }
    }
}
