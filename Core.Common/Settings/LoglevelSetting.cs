using MsLogLevel = Microsoft.Extensions.Logging.LogLevel;

namespace Core.Common.Settings
{
    public class LoglevelSetting
    {
        public MsLogLevel Default { get; set; }
        public MsLogLevel System { get; set; }
        public MsLogLevel Microsoft { get; set; }
    }
}