using System.Threading.Tasks;
using Core.Models.Parameter.Business.Attribute;
using Core.Models.ViewModel.Business.Attribute;

namespace Core.Data.Repository
{
    public partial class Repository
    {

        public async Task<UpdateAttributeStatusVm> Sp_UpdateAttributeStatus(UpdateAttributeStatusParam parameters) => await _context.GetAsync<UpdateAttributeStatusVm>
                (
                    "Business.sp_UpdateAttributeStatus",
                    parameters
                );
    }
}
