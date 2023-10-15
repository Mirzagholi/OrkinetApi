using System.Collections.Generic;

namespace Core.Service.Hubs.Inquiry
{
    public class InquiryHubUser
    {
        public int UserId { set; get; }
        public int? ProviderId { set; get; }
        public int? CartId { set; get; }
        public string Role { set; get; }
        public HashSet<string> ConnectionIds { get; set; }
    }
}
