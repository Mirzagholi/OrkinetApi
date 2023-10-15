using Core.Common.Base;
using Core.Models.Enum.Business.Product;
using Core.Models.Helper;

namespace Core.Models.ViewModel.Business.Product
{
    public class GetDiscountedProductUiVm : BaseDataResult
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public int ProviderId { get; set; }
        public string ProviderName { get; set; }
        public PreparationType PreparationTypeId { get; set; }
        public string PreparationTypeName => PreparationTypeId.GetPreparationTypeTextByCulture();
        public int Price { get; set; }
        public int DiscountPrice { get; set; }
        public int FinalPrice { get; set; }
        public string Photo { get; set; }
        public int Rating { get; set; }
        public int CdnFileId { get; set; }
    }
}
