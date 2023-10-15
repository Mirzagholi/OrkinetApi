using System.Threading.Tasks;
using Core.Models.Parameter.Business.ProductComment;

namespace Core.Data.Repository
{
    public partial class Repository
    {

        public async Task Sp_AddUserProductComment(AddUserProductCommentParam parameters) => await _context.ExecuteAsync
                (
                    "Business.sp_AddUserProductComment",
                    parameters
                );
    }
}
