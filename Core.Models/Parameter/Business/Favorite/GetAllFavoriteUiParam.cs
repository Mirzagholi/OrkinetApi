using System.Data;
using Core.Common.Base;

namespace Core.Models.Parameter.Business.Favorite
{
    public class GetAllFavoriteUiParam : BaseParam
    {
        public int UserId { get; set; }
        public int? PageNumber { get; set; }
        public int? PageRecord { get; set; }
    }
}
