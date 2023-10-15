using System.Threading.Tasks;
using Core.Models.Parameter.Business.PrivateAttribute;
using Core.Models.ViewModel.Business.PrivateAttribute;

namespace Core.Data.Repository
{
    public partial class Repository
    {

        public async Task<UpdatePrivateAttributeVm> Sp_UpdatePrivateAttribute(UpdatePrivateAttributeParam parameters) => await _context.GetAsync<UpdatePrivateAttributeVm>
                (
                    "Business.sp_UpdatePrivateAttribute",
                    parameters
                );
    }
}
