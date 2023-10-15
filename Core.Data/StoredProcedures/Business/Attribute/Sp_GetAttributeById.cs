using System.Threading.Tasks;
using Core.Models.Parameter.Business.Attribute;
using Core.Models.ViewModel.Business.Attribute;

namespace Core.Data.Repository
{
    public partial class Repository
    {
        public async Task<GetAttributeByIdVm> Sp_GetAttributeById(GetAttributeByIdParam parameters) => await _context.GetAsync<GetAttributeByIdVm>
            (
                "Business.sp_GetAttributeById",
                parameters
            );

    }

}
