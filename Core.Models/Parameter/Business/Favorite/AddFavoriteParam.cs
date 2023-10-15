using System.Data;
using Core.Common.Base;

namespace Core.Models.Parameter.Business.Favorite
{
    public class AddFavoriteParam : BaseParam
    {
        public int UserId { get; set; }
        public int ProductId { get; set; }
    }
}
