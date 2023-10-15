using System.Threading.Tasks;
using Core.Models.Parameter.Business.Contact;
using Core.Models.ViewModel.Business.Contact;

namespace Core.Data.Repository
{
    public partial class Repository
    {

        public async Task<AddContactUsVm> Sp_AddContactUs(AddContactUsParam parameters) => await _context.GetAsync<AddContactUsVm>
                (
                    "Business.sp_AddContactUs",
                    parameters
                );
    }
}
