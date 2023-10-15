using Core.Common.Base;

namespace Core.Models.Parameter.Common.ParbadStorage
{
    public class UpdateTransactionParam : BaseParam
    {
        public int Id { get; set; }
        public bool IsSucceed { get; set; }
    }
}
