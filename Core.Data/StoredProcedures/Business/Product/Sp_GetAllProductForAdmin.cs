using System.Threading.Tasks;
using Core.Common.Base;
using Core.Models.Parameter.Business.Product;
using Core.Models.ViewModel.Business.Product;

namespace Core.Data.Repository
{
    public partial class Repository
    {
        public async Task<BaseProductPagingResult<GetAllProductForAdminVm, GetAllProductAttrValForAdminVm, GetAllProductPrivateAttrValForAdminVm, GetAllProductPhotosForAdminVm, GetAllProductCategoryForAdminVm>>
            Sp_GetAllProductForAdmin(GetAllProductForAdminParam parameters) => await _context.GetManyProductWithPagingAsync<GetAllProductForAdminVm, GetAllProductAttrValForAdminVm, GetAllProductPrivateAttrValForAdminVm, GetAllProductPhotosForAdminVm, GetAllProductCategoryForAdminVm>
            (
                "Business.sp_GetAllProductForAdmin",
                parameters
            );

    }

}
