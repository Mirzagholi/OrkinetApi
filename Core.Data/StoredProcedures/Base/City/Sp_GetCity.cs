using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Models.Parameter.Base.City;
using Core.Models.ViewModel.Base.City;
namespace Core.Data.Repository
{
    public partial class Repository
    {
        public async Task<IEnumerable<GetCityVm>> Sp_GetCity(GetCityParam parameters) => await _context.GetManyAsync<GetCityVm>
            (
                "Base.sp_GetCity",
                parameters
            );

    }

}
