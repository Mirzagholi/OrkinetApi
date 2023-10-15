using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Common.Base;
using Core.Common.Extensions;
using Core.Common.Settings;
using Core.Common.ShareContract;
using Core.Common.ShareModels;
using Core.DataContract;
using Core.Models.Parameter.Business.PrivateAttribute;
using Core.Models.Request.Business.PrivateAttribute;
using Core.Models.ViewModel.Business.PrivateAttribute;
using Core.ServiceContract.Business;
using Microsoft.Extensions.Options;

namespace Core.Service.Business
{
    public class PrivateAttributeSrv : IPrivateAttributeSrv
    {
        #region Property

        private readonly IRepository _repository;
        private readonly IServiceResultHelper _serviceResultHelper;
        private readonly IOptionsSnapshot<SiteSettings> _siteSettings;

        #endregion Property

        #region Constructor

        public PrivateAttributeSrv(IRepository repository,
            IServiceResultHelper serviceResultHelper,
            IOptionsSnapshot<SiteSettings> siteSettings)
        {
            _repository = repository;
            _serviceResultHelper = serviceResultHelper;
            _siteSettings = siteSettings ?? throw new ArgumentNullException(nameof(_siteSettings));
        }

        #endregion Constructor

        #region Methods

        public async Task<ServiceResult> AddPrivateAttributeAsync(AddPrivateAttributeRequest request)
        {
            var providerId = HttpContextExtensions.GetProviderId().Value;
            var response = await _repository.Sp_AddPrivateAttribute(
                new AddPrivateAttributeParam()
                {
                    Name = request.Name.Trim(),
                    Order = request.Order ?? 0,
                    ProviderId = providerId
                });

            return _serviceResultHelper.Response(response);
        }

        public async Task<BasePagingResult<GetPrivateAttributeVm>> GetPrivateAttributeAsync(GetPrivateAttributeRequest request)
        {
            var providerId = HttpContextExtensions.GetProviderId().Value;
            return await _repository.Sp_GetPrivateAttribute(new GetPrivateAttributeParam
            {
                ProviderId = providerId,
                PageNumber = request.PageNumber,
                PageRecord = request.PageRecord,
                SortColumn = request.SortColumn,
                SortOrder = request.SortOrder
            });
        }

        public async Task<ServiceResult> UpdatePrivateAttributeAsync(UpdatePrivateAttributeRequest request)
        {
            var providerId = HttpContextExtensions.GetProviderId().Value;
            var response = await _repository.Sp_UpdatePrivateAttribute(
                new UpdatePrivateAttributeParam()
                {
                    Id = request.Id,
                    Name = request.Name.Trim(),
                    Order = request.Order ?? 0,
                    ProviderId = providerId
                });

            return _serviceResultHelper.Response(response);
        }

        public async Task<ServiceResult> UpdatePrivateAttributeStatusAsync(UpdatePrivateAttributeStatusRequest request)
        {
            var providerId = HttpContextExtensions.GetProviderId().Value;
            var response = await _repository.Sp_UpdatePrivateAttributeStatus(
                new UpdatePrivateAttributeStatusParam()
                {
                    Id = request.Id,
                    StatusId = request.StatusId,
                    ProviderId = providerId
                });

            return _serviceResultHelper.Response(response);
        }

        public async Task<IEnumerable<GetPrivateAttributeDropDownVm>> GetPrivateAttributeDropDownAsync()
        {
            var providerId = HttpContextExtensions.GetProviderId().Value;

            return
                await _repository.Sp_GetPrivateAttributeDropDown(new GetPrivateAttributeDropDownParam() { ProviderId = providerId }); ;
        }
        #endregion
    }
}
