using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Common.Base;
using Core.Common.Extensions;
using Core.Common.Settings;
using Core.Common.ShareContract;
using Core.Common.ShareModels;
using Core.DataContract;
using Core.Models.Parameter.Business.PrivateValue;
using Core.Models.Request.Business.PrivateValue;
using Core.Models.ViewModel.Business.PrivateValue;
using Core.ServiceContract.Business;
using Microsoft.Extensions.Options;

namespace Core.Service.Business
{
    public class PrivateValueSrv : IPrivateValueSrv
    {
        #region Property

        private readonly IRepository _repository;
        private readonly IServiceResultHelper _serviceResultHelper;
        private readonly IOptionsSnapshot<SiteSettings> _siteSettings;

        #endregion Property

        #region Constructor

        public PrivateValueSrv(IRepository repository,
            IServiceResultHelper serviceResultHelper,
            IOptionsSnapshot<SiteSettings> siteSettings)
        {
            _repository = repository;
            _serviceResultHelper = serviceResultHelper;
            _siteSettings = siteSettings ?? throw new ArgumentNullException(nameof(_siteSettings));
        }

        #endregion Constructor

        #region Methods

        public async Task<ServiceResult> AddPrivateValueAsync(AddPrivateValueRequest request)
        {
            var providerId = HttpContextExtensions.GetProviderId().Value;
            var response = await _repository.Sp_AddPrivateValue(
                new AddPrivateValueParam()
                {
                    Name = request.Name.Trim(),
                    Order = request.Order ?? 0,
                    ProviderId = providerId,
                    PrivateAttributeId = request.PrivateAttributeId
                });

            return _serviceResultHelper.Response(response);
        }

        public async Task<BasePagingResult<GetPrivateValueVm>> GetPrivateValueAsync(GetPrivateValueRequest request)
        {
            var providerId = HttpContextExtensions.GetProviderId().Value;
            return await _repository.Sp_GetPrivateValue(new GetPrivateValueParam
            {
                ProviderId = providerId,
                PageNumber = request.PageNumber,
                PageRecord = request.PageRecord,
                SortColumn = request.SortColumn,
                SortOrder = request.SortOrder
            });
        }

        public async Task<ServiceResult> UpdatePrivateValueAsync(UpdatePrivateValueRequest request)
        {
            var providerId = HttpContextExtensions.GetProviderId().Value;
            var response = await _repository.Sp_UpdatePrivateValue(
                new UpdatePrivateValueParam()
                {
                    Id = request.Id,
                    Name = request.Name.Trim(),
                    Order = request.Order ?? 0,
                    ProviderId = providerId,
                    PrivateAttributeId = request.PrivateAttributeId
                });

            return _serviceResultHelper.Response(response);
        }

        public async Task<ServiceResult> UpdatePrivateValueStatusAsync(UpdatePrivateValueStatusRequest request)
        {
            var providerId = HttpContextExtensions.GetProviderId().Value;
            var response = await _repository.Sp_UpdatePrivateValueStatus(
                new UpdatePrivateValueStatusParam()
                {
                    Id = request.Id,
                    StatusId = request.StatusId,
                    ProviderId = providerId,
                    PrivateAttributeId = request.PrivateAttributeId
                });

            return _serviceResultHelper.Response(response);
        }

        public async Task<IEnumerable<GetCompletePrivateValueDropDownVm>> GetCompletePrivateValueDropDownAsync
            (GetCompletePrivateValueRequest request)
        {
            var providerId = HttpContextExtensions.GetProviderId().Value;
            return 
                await _repository.Sp_GetCompletePrivateValueDropDown(new GetCompletePrivateValueParam
                {
                    CategoryId = request.CategoryId,
                    ProviderId = providerId
                });
        } 

        #endregion
    }
}
