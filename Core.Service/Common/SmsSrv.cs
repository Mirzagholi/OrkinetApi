using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Core.Common.Settings;
using Core.Common.ShareContract;
using Core.Models.Request.Common.Sms;
using Core.Models.ViewModel.Common.Sms;
using Core.ServiceContract.Common;
using Microsoft.Extensions.Options;

namespace Core.Service.Common
{
    public class SmsSrv : ISmsSrv
    {
        #region Property

        private readonly IServiceResultHelper _serviceResultHelper;
        private readonly IOptionsSnapshot<SiteSettings> _siteSettings;
        private readonly Uri _baseUrl;

        #endregion Property

        #region Constructor

        public SmsSrv(
            IServiceResultHelper serviceResultHelper,
            IOptionsSnapshot<SiteSettings> siteSettings)
        {
            _serviceResultHelper = serviceResultHelper;
            _siteSettings = siteSettings ?? throw new ArgumentNullException(nameof(_siteSettings));
            _baseUrl = new Uri("http://rest.ippanel.com:8080/");
        }

        #endregion Constructor

        #region Methods

        public async Task<SendConfirmationSmsVm> SendConfirmationSmsAsync(SendConfirmationSmsRequest request)
        {
            var response = new SendConfirmationSmsVm();
            using (var client = new HttpClient())
            {
                client.BaseAddress = _baseUrl;
                client.DefaultRequestHeaders.Add("Authorization", "AccessKey  " + _siteSettings.Value.SmsPanel.Apikey.Trim());

                var myContent =
                    "{\"pattern_code\": \"asj31wummxemxm9\", \"originator\": \"" + _siteSettings.Value.SmsPanel.LineNumber.Trim() +
                     "\", \"recipient\": \"" + request.MobileNumber.Trim() + "\", \"values\": { \"verification-code\": \"" + request.ConfirmCode + "\" }}";
                var buffer = System.Text.Encoding.UTF8.GetBytes(myContent);
                var byteContent = new ByteArrayContent(buffer);
                byteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");

                var result = await client.PostAsync("/v1/messages/patterns/send", byteContent);
                response.IsSuccessStatusCode = result.IsSuccessStatusCode;
                if (result.IsSuccessStatusCode)
                {
                    response.Code = await result.Content.ReadAsStringAsync();
                }
            }

            return response;
        }

        public async Task<SendInquirySmsVm> SendInquirySmsAsync(SendInquirySmsRequest request)
        {
            var response = new SendInquirySmsVm();
            using (var client = new HttpClient())
            {
                client.BaseAddress = _baseUrl;
                client.DefaultRequestHeaders.Add("Authorization", "AccessKey  " + _siteSettings.Value.SmsPanel.Apikey.Trim());

                var myContent =
                    "{\"pattern_code\": \"7pectqt2b0\", \"originator\": \"" + _siteSettings.Value.SmsPanel.LineNumber.Trim() +
                     "\", \"recipient\": \"" + request.MobileNumber.Trim() + "\", \"values\": { \"name\": \"" + request.FullName + "\" }}";
                var buffer = System.Text.Encoding.UTF8.GetBytes(myContent);
                var byteContent = new ByteArrayContent(buffer);
                byteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");

                var result = await client.PostAsync("/v1/messages/patterns/send", byteContent);
                response.IsSuccessStatusCode = result.IsSuccessStatusCode;
                if (result.IsSuccessStatusCode)
                {
                    response.Code = await result.Content.ReadAsStringAsync();
                }
            }

            return response;
        }

        public async Task<PaidOrderSmsVm> PaidOrderSmsAsync(PaidOrderSmsRequest request)
        {
            var response = new PaidOrderSmsVm();
            using (var client = new HttpClient())
            {
                client.BaseAddress = _baseUrl;
                client.DefaultRequestHeaders.Add("Authorization", "AccessKey  " + _siteSettings.Value.SmsPanel.Apikey.Trim());

                var myContent =
                    "{\"pattern_code\": \"cv4rw3uany\", \"originator\": \"" + _siteSettings.Value.SmsPanel.LineNumber.Trim() +
                     "\", \"recipient\": \"" + request.MobileNumber.Trim() + "\", \"values\": { \"name\": \"" + request.FullName + "\", \"code\": \"" + request.Code + "\" }}";
                var buffer = System.Text.Encoding.UTF8.GetBytes(myContent);
                var byteContent = new ByteArrayContent(buffer);
                byteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");

                var result = await client.PostAsync("/v1/messages/patterns/send", byteContent);
                response.IsSuccessStatusCode = result.IsSuccessStatusCode;
                if (result.IsSuccessStatusCode)
                {
                    response.Code = await result.Content.ReadAsStringAsync();
                }
            }

            return response;
        }

        public async Task<PaidProviderOrderSmsVm> PaidProviderOrderSmsAsync(PaidProviderOrderSmsRequest request)
        {
            var response = new PaidProviderOrderSmsVm();
            using (var client = new HttpClient())
            {
                client.BaseAddress = _baseUrl;
                client.DefaultRequestHeaders.Add("Authorization", "AccessKey  " + _siteSettings.Value.SmsPanel.Apikey.Trim());

                var myContent =
                    "{\"pattern_code\": \"ju58f52rmq\", \"originator\": \"" + _siteSettings.Value.SmsPanel.LineNumber.Trim() +
                     "\", \"recipient\": \"" + request.MobileNumber.Trim() + "\"}";
                var buffer = System.Text.Encoding.UTF8.GetBytes(myContent);
                var byteContent = new ByteArrayContent(buffer);
                byteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");

                var result = await client.PostAsync("/v1/messages/patterns/send", byteContent);
                response.IsSuccessStatusCode = result.IsSuccessStatusCode;
                if (result.IsSuccessStatusCode)
                {
                    response.Code = await result.Content.ReadAsStringAsync();
                }
            }

            return response;
        }

        public async Task<PaidAdminOrderSmsVm> PaidAdminOrderSmsAsync(PaidAdminOrderSmsRequest request)
        {
            var response = new PaidAdminOrderSmsVm();
            using (var client = new HttpClient())
            {
                client.BaseAddress = _baseUrl;
                client.DefaultRequestHeaders.Add("Authorization", "AccessKey  " + _siteSettings.Value.SmsPanel.Apikey.Trim());

                var myContent =
                    "{\"pattern_code\": \"ju58f52rmq\", \"originator\": \"" + _siteSettings.Value.SmsPanel.LineNumber.Trim() +
                     "\", \"recipient\": \"" + request.MobileNumber.Trim() + "\"}";
                var buffer = System.Text.Encoding.UTF8.GetBytes(myContent);
                var byteContent = new ByteArrayContent(buffer);
                byteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");

                var result = await client.PostAsync("/v1/messages/patterns/send", byteContent);
                response.IsSuccessStatusCode = result.IsSuccessStatusCode;
                if (result.IsSuccessStatusCode)
                {
                    response.Code = await result.Content.ReadAsStringAsync();
                }
            }

            return response;
        }


        #endregion
    }
}
