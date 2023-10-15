using System.Threading.Tasks;
using Core.Models.Parameter.Business.Attribute;
using Core.Models.ViewModel.Business.Attribute;

namespace Core.Data.Repository
{
    public partial class Repository
    {

        public async Task<UpdateAttributeVm> Sp_UpdateAttribute(UpdateAttributeParam parameters) => await _context.GetAsync<UpdateAttributeVm>
                (
                    "Business.sp_UpdateAttribute",
                    parameters
                );
    }
}
