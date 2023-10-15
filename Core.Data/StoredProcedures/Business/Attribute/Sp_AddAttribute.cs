using System.Threading.Tasks;
using Core.Models.Parameter.Business.Attribute;
using Core.Models.ViewModel.Business.Attribute;

namespace Core.Data.Repository
{
    public partial class Repository
    {

        public async Task<AddAttributeVm> Sp_AddAttribute(AddAttributeParam parameters) => await _context.GetAsync<AddAttributeVm>
                (
                    "Business.sp_AddAttribute",
                    parameters
                );
    }
}
