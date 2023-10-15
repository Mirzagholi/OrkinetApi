using System.Threading.Tasks;
using Core.Models.Parameter.Business.PrivateAttribute;
using Core.Models.ViewModel.Business.PrivateAttribute;

namespace Core.Data.Repository
{
    public partial class Repository
    {

        public async Task<AddPrivateAttributeVm> Sp_AddPrivateAttribute(AddPrivateAttributeParam parameters) => await _context.GetAsync<AddPrivateAttributeVm>
                (
                    "Business.sp_AddPrivateAttribute",
                    parameters
                );
    }
}
