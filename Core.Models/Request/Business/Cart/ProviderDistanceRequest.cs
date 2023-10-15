using Core.Common.Base;
using Core.Models.Enum.Business.Contact;
using System;

namespace Core.Models.Request.Business.Cart
{
    public class ProviderDistanceRequest : BaseRequest
    {
        public int ProviderId { get; set; }
        public int Kilometer { get; set; }
    }
}
