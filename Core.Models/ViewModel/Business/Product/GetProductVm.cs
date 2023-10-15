using System;
using System.Collections.Generic;
using Core.Common.Base;
using Core.Models.Enum.Business.Product;
using Core.Models.Enum.Common;
using Core.Models.Helper;

namespace Core.Models.ViewModel.Business.Product
{
    public class GetProductVm : BaseDataResult
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public IEnumerable<GetProductCategoryVm> ProductCategory { get; set; }
        public IEnumerable<GetProductAttrValVm> ProductAttrVal { get; set; }
        public IEnumerable<GetProductPrivateAttrValVm> ProductPrivateAttrVal { get; set; }
        public IEnumerable<GetProductPhotosVm> ProductPhoto { get; set; }
        public PreparationType PreparationTypeId { get; set; }
        public string PreparationTypeText => PreparationTypeId.GetPreparationTypeTextByCulture();
        public int Price { get; set; }
        public StatusType StatusId { get; set; }
        public string StatusText => StatusId.GetStatusTextByCulture();
        public DateTime CreatedOn { get; set; }
        public string ShortDescription { get; set; }
        public string Description { get; set; }
    }
}
