using System;
using System.Collections.Generic;
using Core.Common.Base;
using Core.Models.Enum.Business.Product;

namespace Core.Models.ViewModel.Business.Product.GetProviderProductById
{
    public class GetProviderProductByIdVm : BaseDataResult
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public IEnumerable<int> ProductCategory { get; set; }
        public IEnumerable<GetProviderProductByIdAttrValVm> ProductAttrVal { get; set; }
        public IEnumerable<GetProviderProductByIdPrivateAttrValVm> ProductPrivateAttrVal { get; set; }
        public IEnumerable<GetProviderProductByIdPhotoVm> ProductPhoto { get; set; }
        public PreparationType PreparationTypeId { get; set; }
        public string ShortDescription { get; set; }
        public string Description { get; set; }
    }
}
