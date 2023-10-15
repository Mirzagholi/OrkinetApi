using Core.Common.Base;

namespace Core.Models.Request.Business.Provider
{
    public class GetProviderDetailUiRequest : BaseRequest
    {
        public int? Id { get; set; }
        public int? Code { get; set; }
    }
}
