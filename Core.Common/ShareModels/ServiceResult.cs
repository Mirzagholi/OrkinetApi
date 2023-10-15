using Core.Common.Enum;


namespace Core.Common.ShareModels
{
   public class ServiceResult
    {
        public int Code { get; set; }
        public MessageStatus Status { get; set; }
        public string[] Messages { get; set; }
        public object Data { get; set; }
    }
}
