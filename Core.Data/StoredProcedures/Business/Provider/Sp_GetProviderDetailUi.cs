using System.Threading.Tasks;
using Core.Common.Base;
using Core.Models.Parameter.Business.Provider;
using Core.Models.ViewModel.Business.Provider;

namespace Core.Data.Repository
{
    public partial class Repository
    {
        public async Task<BaseDoubleResult<GetProviderDetailUiVm, int>> 
            Sp_GetProviderDetailUi(GetProviderDetailUiParam parameters) => await _context.GetDoubleAsync<GetProviderDetailUiVm, int>
            (
                "Business.sp_GetProviderDetailUi",
                parameters
        );

    }

}
