using System.Threading.Tasks;
using Core.Models.Parameter.Business.Value;
using Core.Models.ViewModel.Business.Value;

namespace Core.Data.Repository
{
    public partial class Repository
    {
        public async Task<GetValueByIdVm> Sp_GetValueById(GetValueByIdParam parameters) => await _context.GetAsync<GetValueByIdVm>
            (
                "Business.sp_GetValueById",
                parameters
            );

    }

}
