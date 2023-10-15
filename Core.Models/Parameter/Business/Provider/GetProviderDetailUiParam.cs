using Core.Common.Base;

namespace Core.Models.Parameter.Business.Provider
{
    public class GetProviderDetailUiParam : BaseParam
    {
        public int? Id { get; set; }
        public int? Code { get; set; }
    }
}
