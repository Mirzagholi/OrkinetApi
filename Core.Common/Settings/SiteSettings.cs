namespace Core.Common.Settings
{
    public class SiteSettings
    {
        public LoggingSetting Logging { get; set; }
        public SqlServer SqlServer { get; set; }
        public CdnConfig CdnConfig { get; set; }
        public UiConfig UiConfig { get; set; }
        public BearerTokens BearerTokens { get; set; }
        public OrderConfig OrderConfig { get; set; }
        public SmsPanelSetting SmsPanel { get; set; }
        public SmsTextSetting SmsText { get; set; }
    }
}