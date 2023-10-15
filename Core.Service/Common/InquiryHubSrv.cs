using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.DataContract;
using Core.Service.Hubs;
using Core.Service.Hubs.Inquiry;
using Core.ServiceContract.Common;
using Microsoft.AspNetCore.SignalR;

namespace Core.Service.Common
{
    public class InquiryHubSrv : IInquiryHubSrv
    {
        #region Property

        private readonly IHubContext<InquiryHub, IInquiryClient> _inquiryHubContext;
        private readonly IRepository _repository;
        private static DateTime NextAdminFetchOn;
        private static List<string> AdminIdes;

        #endregion Property

        #region Constructor

        public InquiryHubSrv(
            IRepository repository,
            IHubContext<InquiryHub, IInquiryClient> inquiryHubContext)
        {
            _repository = repository;
            _inquiryHubContext = inquiryHubContext;
        }

        #endregion Constructor

        #region Methods

        public async Task SendAdminNotifyAsync()
        {
            var adminIdes = await GetAdminIdesAsync();

            if (adminIdes.Count > 0)
                await _inquiryHubContext.Clients.Users(adminIdes.Distinct().ToList()).AdminInquiryNotify();
        }

        public async Task SendProviderNotifyAsync(string providerId)
        {
            if (!string.IsNullOrEmpty(providerId))
                await _inquiryHubContext.Clients.User(providerId).ProviderInquiryNotify();
        }

        public async Task SendProviderNotifyAsync(List<string> providerIdes)
        {
            if (providerIdes.Count > 0)
                await _inquiryHubContext.Clients.Users(providerIdes.Distinct().ToList()).ProviderInquiryNotify();
        }

        public async Task SendUserNotifyAsync(string userId)
        {
            if (!string.IsNullOrEmpty(userId))
                await _inquiryHubContext.Clients.User(userId).UserInquiryNotify();
        }

        public async Task SendUserNotifyAsync(List<string> userIdes)
        {
            if (userIdes.Count > 0)
                await _inquiryHubContext.Clients.Users(userIdes.Distinct().ToList()).UserInquiryNotify();
        }

        private async Task<List<string>> GetAdminIdesAsync()
        {
            if (AdminIdes != null && 
                AdminIdes.Count > 0 &&
                NextAdminFetchOn != null &&
                NextAdminFetchOn > DateTime.Now)
                return AdminIdes;

            AdminIdes = (await _repository.Sp_GetAllAdminId()).ToList();

            NextAdminFetchOn = DateTime.Now.AddMinutes(5);
            return AdminIdes;
        }

        #endregion
    }
}
