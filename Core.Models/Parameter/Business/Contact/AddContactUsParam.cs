using Core.Common.Base;
using Core.Models.Enum.Business.Contact;

namespace Core.Models.Parameter.Business.Contact
{
    public class AddContactUsParam : BaseParam
    {
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Subject { get; set; }
        public MessageContactType ContactUsTypeId { get; set; }
        public string Description { get; set; }
    }
}
