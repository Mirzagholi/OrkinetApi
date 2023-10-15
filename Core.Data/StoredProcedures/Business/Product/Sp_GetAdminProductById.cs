using System.Threading.Tasks;
using Core.Common.Base;
using Core.Models.Parameter.Business.Product;
using Core.Models.ViewModel.Business.Product.GetProviderProductById;

namespace Core.Data.Repository
{
    public partial class Repository
    {
        public async Task<BaseFifthResult<GetProviderProductByIdVm, GetProviderProductByIdAttrValVm, GetProviderProductByIdPrivateAttrValVm, GetProviderProductByIdPhotoVm, int>>
            Sp_GetAdminProductById(GetProviderProductByIdParam parameters) => await _context.GetFifthAsync<GetProviderProductByIdVm, GetProviderProductByIdAttrValVm, GetProviderProductByIdPrivateAttrValVm, GetProviderProductByIdPhotoVm, int>
            (
                "Business.sp_GetProviderProductById",
                parameters
            );

    }

}
