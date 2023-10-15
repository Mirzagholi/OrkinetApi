using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BingCdn.NetCoreConnector;
using Core.Common.Base;
using Core.Common.Extensions;
using Core.Common.Settings;
using Core.Common.ShareContract;
using Core.Common.ShareModels;
using Core.Data.DataHelpers;
using Core.DataContract;
using Core.Models.Enum.Common;
using Core.Models.Parameter.Business.Cart;
using Core.Models.Request.Business.Cart;
using Core.Models.Request.Common.Sms;
using Core.Models.ViewModel.Business.Cart;
using Core.ServiceContract.Business;
using Core.ServiceContract.Common;
using ElmahCore;
using GeoCoordinatePortable;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Parbad;
using Parbad.AspNetCore;

namespace Core.Service.Business
{
    public class CartSrv : ICartSrv
    {
        #region Property

        private readonly IRepository _repository;
        private readonly IServiceResultHelper _serviceResultHelper;
        private readonly IInquiryHubSrv _inquiryHubSrv;
        private readonly IOptionsSnapshot<SiteSettings> _siteSetting;
        private readonly IOnlinePayment _onlinePayment;
        private readonly ICdnService _cdnService;
        private readonly ISmsSrv _smsSrv;
        private readonly string _domianPath;

        #endregion Property

        #region Constructor

        public CartSrv(IRepository repository,
            IServiceResultHelper serviceResultHelper,
            IInquiryHubSrv inquiryHubSrv,
            IOptionsSnapshot<SiteSettings> siteSetting,
            IOnlinePayment onlinePayment,
            ICdnService cdnService,
            ISmsSrv smsSrv,
            IHttpContextAccessor httpContextAccessor)
        {
            _repository = repository;
            _serviceResultHelper = serviceResultHelper;
            _inquiryHubSrv = inquiryHubSrv;
            _siteSetting = siteSetting;
            _onlinePayment = onlinePayment;
            _cdnService = cdnService;
            _smsSrv = smsSrv;
            _domianPath = $"{httpContextAccessor.HttpContext.Request.Scheme}:" +
              $"//{httpContextAccessor.HttpContext.Request.Host}" +
              $"{httpContextAccessor.HttpContext.Request.PathBase}";
        }

        #endregion Constructor

        #region Methods

        public async Task<ServiceResult> AddCartAsync(List<AddCartRequest> request)
        {
            var userId = HttpContextExtensions.GetUserId().Value;

            //در صورت وجود استعلام برای کاربر به صورت خودکار تمامی آن لغو گردد
            var cartIdes = await GetAllUserActiveInquiryCartIdAsync(userId);
            foreach(var cartId in cartIdes)
                await CancelInquiryCartAsync(new CancelInquiryCartRequest { CartId = cartId });

            var response = await _repository.Sp_AddCart(
                new AddCartParam()
                {
                    UserId = userId,
                    Products =  request.MapToCartProductDataSqlType().ToDataTable()
                });

            return _serviceResultHelper.Response(response);
        }

        public async Task<ServiceResult> SetCartUserAddressAsync(SetCartUserAddressRequest request)
        {
            var userId = HttpContextExtensions.GetUserId().Value;
            var response = await _repository.Sp_SetCartUserAddress(
                new SetCartUserAddressParam()
                {
                    UserId = userId,
                    CartId = request.CartId,
                    UserAddressId = request.UserAddressId
                });

            return _serviceResultHelper.Response(response);
        }

        public async Task<ServiceResult> StartInquiryCartAsync(StartInquiryCartRequest request)
        {
            var preProviderIdes = await GetAllInquiryProviderUserIdAsync(request.CartId);
            var userId = HttpContextExtensions.GetUserId().Value;
            var response = await _repository.Sp_StartInquiryCart(
                new StartInquiryCartParam()
                {
                    UserId = userId,
                    CartId = request.CartId,
                    RemainInquiryMinute = _siteSetting.Value.OrderConfig.RemainInquiryMinute
                });

            //notify to admin with hub
            await _inquiryHubSrv.SendAdminNotifyAsync();

            //notify to provider with hub
            var providerIdes = await GetAllInquiryProviderUserIdAsync(request.CartId);
            providerIdes.AddRange(preProviderIdes);
            if (providerIdes.Count > 0)
                await _inquiryHubSrv.SendProviderNotifyAsync(providerIdes);

            return _serviceResultHelper.Response(response);
        }

        public async Task<ServiceResult> CheckInquiryCartAsync(CheckInquiryCartRequest request)
        {
            var preProviderIdes = await GetAllInquiryProviderUserIdAsync(request.CartId);
            var userId = HttpContextExtensions.GetUserId().Value;
            var response = await _repository.Sp_CheckInquiryCart(
                new CheckInquiryCartParam()
                {
                    UserId = userId,
                    CartId = request.CartId
                });

            //notify to admin with hub
            await _inquiryHubSrv.SendAdminNotifyAsync();

            //notify to provider with hub
            var providerIdes = await GetAllInquiryProviderUserIdAsync(request.CartId);
            providerIdes.AddRange(preProviderIdes);
            if (providerIdes.Count > 0)
                await _inquiryHubSrv.SendProviderNotifyAsync(providerIdes);

            return _serviceResultHelper.Response(response);
        }

        public async Task<BasePagingResult<GetAllActiveInquiryCartVm>> GetAllActiveInquiryCartAsync(GetAllActiveInquiryCartRequest request)
        {
            //delete all expire inquiry
            await DeleteExpireInquiryCartAsync();

            return await _repository.Sp_GetAllActiveInquiryCart(new GetAllActiveInquiryCartParam
            {
                PageNumber = request.PageNumber,
                PageRecord = request.PageRecord,
                SortColumn = request.SortColumn,
                SortOrder = request.SortOrder
            });
        }

        public async Task<BasePagingResult<GetAllProviderInquiryCartVm>> GetAllProviderInquiryCartAsync(GetAllProviderInquiryCartRequest request)
        {
            //delete all expire inquiry
            await DeleteExpireInquiryCartAsync();

            var providerId = HttpContextExtensions.GetProviderId().Value;
            var results = 
                await _repository.Sp_GetAllProviderInquiryCart(new GetAllProviderInquiryCartParam
            {
                ProviderId = providerId,
                PageNumber = request.PageNumber,
                PageRecord = request.PageRecord,
                SortColumn = request.SortColumn,
                SortOrder = request.SortOrder
            });


            if (results == null || results.List.Count() == 0)
                return results;

            var cdnFiles = await _cdnService.GetCdnManyFilePathAsync(results.List.Select(z => z.CdnFileId).ToArray());

            foreach (var result in results.List.ToList())
            {
                var photo = cdnFiles.FirstOrDefault(z => z.Id == result.CdnFileId);
                if (photo != null)
                    result.Photo = photo.Path;
            }

            return results;
        }

        public async Task<ServiceResult> SetCartDeliveryPriceAsync(SetCartDeliveryPriceRequest request)
        {
            var userId = HttpContextExtensions.GetUserId().Value;
            var userCoordinate = await _repository.Sp_GetCartUserCoordinate(
                new GetCartUserCoordinateParam
                {
                    UserId = userId,
                    CartId = request.CartId
                });

            if (userCoordinate == null)
                return _serviceResultHelper.Response();

            var providerCoordinates = await _repository.Sp_GetCartProviderCoordinate(
                new GetCartProviderCoordinateParam
                {
                    UserId = userId,
                    CartId = request.CartId
                });

            if (providerCoordinates == null || providerCoordinates.Count() == 0)
                return _serviceResultHelper.Response();

            var providerDistances = new List<ProviderDistanceRequest>();
            foreach (var item in providerCoordinates)
            {
                var pin1 = new GeoCoordinate((double)userCoordinate.Latitudes, (double)userCoordinate.Longitudes);
                var pin2 = new GeoCoordinate((double)item.Latitudes, (double)item.Longitudes);
                //meter
                double distanceBetween = pin1.GetDistanceTo(pin2);
                providerDistances.Add(new ProviderDistanceRequest
                {
                    ProviderId = item.ProviderId,
                    Kilometer = distanceBetween != 0 ? (int)(distanceBetween / 1000) : 0
                });
            }

            var response = await _repository.Sp_SetCartDeliveryPrice(
                new SetCartDeliveryPriceParam()
                {
                    UserId = userId,
                    CartId = request.CartId,
                    Distance = providerDistances.MapToProviderDistanceDataSqlType().ToDataTable()
                });

            return _serviceResultHelper.Response(response);
        }

        private async Task DeleteExpireInquiryCartAsync() => await _repository.Sp_DeleteExpireInquiryCart(
            new DeleteExpireInquiryCartParam { RemainInquiryMinute = _siteSetting.Value.OrderConfig.RemainInquiryMinute });

        public async Task<ServiceResult> SetResultInquiryCartAsync(SetResultInquiryCartRequest request)
        {
            var providerId = HttpContextExtensions.GetProviderId().Value;
            var response = await _repository.Sp_SetResultInquiryCart(
                new SetResultInquiryCartParam()
                {
                    CartId = request.CartId,
                    ProviderId = providerId,
                    ProductId = request.ProductId,
                    IsConfirm = request.IsConfirm
                });

            //notify to admin with hub
            await _inquiryHubSrv.SendAdminNotifyAsync();

            //notify to user with hub
            if (response.UserId > 0)
                await _inquiryHubSrv.SendUserNotifyAsync(response.UserId.ToString());

            //check all inquiry is done
            var userInquiryStatusResponse = await _repository.Sp_UserInquiryStatus(new UserInquiryStatusParam
            {
                CartId = request.CartId,
                UserId = response.UserId
            });
            if (userInquiryStatusResponse != null && !string.IsNullOrEmpty(userInquiryStatusResponse.MobileNumber))
                await _smsSrv.SendInquirySmsAsync(new SendInquirySmsRequest { 
                    MobileNumber = userInquiryStatusResponse.MobileNumber,
                    FullName = $"{userInquiryStatusResponse.FirstName} {userInquiryStatusResponse.LastName}"
                });
                
            return _serviceResultHelper.Response();
        }

        public async Task<ServiceResult> CancelInquiryCartAsync(CancelInquiryCartRequest request)
        {
            //get retlated provider before cancel inquiry
            var providerIdes = await GetAllInquiryProviderUserIdAsync(request.CartId);

            var userId = HttpContextExtensions.GetUserId().Value;
            var response = await _repository.Sp_CancelInquiryCart(
                new CancelInquiryCartParam()
                {
                    UserId = userId,
                    CartId = request.CartId
                });

            //notify to admin with hub
            await _inquiryHubSrv.SendAdminNotifyAsync();

            //notify to provider with hub
            if (providerIdes.Count > 0)
                await _inquiryHubSrv.SendProviderNotifyAsync(providerIdes);

            return _serviceResultHelper.Response(response);
        }

        private async Task<List<string>> GetAllInquiryProviderUserIdAsync(int cartId)
        {
            var results = await _repository.Sp_GetAllInquiryProviderUserId(new GetAllInquiryProviderUserIdParam { CartId = cartId });
            return results.ToList();
        }

        private async Task<IEnumerable<int>> GetAllUserActiveInquiryCartIdAsync(int userId)
        {
            var results = await _repository.Sp_GetAllUserActiveInquiryCartId(new GetAllUserActiveInquiryCartIdParam { UserId = userId });
            return results;
        }

        public async Task<ServiceResult> SetCartInfoAsync(SetCartInfoRequest request)
        {
            var userId = HttpContextExtensions.GetUserId().Value;
            var response = await _repository.Sp_SetCartInfo(
                new SetCartInfoParam()
                {
                    UserId = userId,
                    CartId = request.CartId,
                    PostalCartId = request.PostalCartId,
                    CartDeliveryTypeId = request.CartDeliveryTypeId,
                    CartDeliveryPlaceTypeId = request.CartDeliveryPlaceTypeId,
                    CartFailedDeliveryTypeId = request.CartFailedDeliveryTypeId,
                    DailyDeliveryStartOn = request.DailyDeliveryStartOn,
                    DailyDeliveryEndOn = request.DailyDeliveryEndOn,
                    TomorrowDeliveryOn = request.TomorrowDeliveryOn
                });

            return _serviceResultHelper.Response(response);
        }

        public async Task<BaseCartInfoResult<GetProviderInquiryCartProductVm,
            GetProviderInquiryCartInfoVm>> GetProviderInquiryCartInfoAsync(int cartId)
        {
            var providerId = HttpContextExtensions.GetProviderId().Value;
            var results = 
                await _repository.Sp_GetProviderInquiryCartInfo(new GetProviderInquiryCartInfoParam
            {
                CartId = cartId,
                ProviderId = providerId
            });

            if (results == null || results.Products.Count() == 0)
                return results;

            var cdnFiles = await _cdnService.GetCdnManyFilePathAsync(results.Products.Select(z => z.CdnFileId).ToArray());

            foreach (var result in results.Products.ToList())
            {
                var photo = cdnFiles.FirstOrDefault(z => z.Id == result.CdnFileId);
                if (photo != null)
                    result.Photo = photo.Path;
            }
            return results;
        }

        public async Task<IActionResult> PayCartAsync(PayCartRequest request)
        {
            var userId = HttpContextExtensions.GetUserId().Value;

            //check allow to pay cart
            var accessToPay = await _repository.Sp_AllowPayCart(new AllowPayCartParam
            {
                CartId = request.CartId,
                UserId = userId,
                RemainPaidMinute = _siteSetting.Value.OrderConfig.RemainPaidMinute
            });

            if (!accessToPay)
                return new ObjectResult(new { error = _serviceResultHelper.Response(null, 29).Messages[0] })
                {
                    StatusCode = 500
                };

            //get price of cart
            var cartPrice = await _repository.Sp_GetCartTotalPrice(new GetCartTotalPriceParam
            {
                CartId = request.CartId,
                UserId = userId
            });

            if (cartPrice == null)
                return new ObjectResult(new { error = _serviceResultHelper.Response(null, 29).Messages[0] })
                {
                    StatusCode = 500
                };

            //redirect to bank
            var callbackUrl = $"{_domianPath}/api/cart/bankverify";

            var result = await _onlinePayment.RequestAsync(invoice =>
            {
                invoice
                    .SetAmount((decimal)cartPrice * 10) //تبدیل تومان به ریال
                    .SetCallbackUrl(callbackUrl)
                    .SetGateway(BankGateways.Sepehr.ToString());

                invoice.UseAutoRandomTrackingNumber();
            });

            if (!result.IsSucceed)
            {
                ElmahExtensions.RiseError(new Exception(result.Message));
                return new ObjectResult(new { error = _serviceResultHelper.Response(null, 30).Messages[0] })
                {
                    StatusCode = 500
                };
            }

            //update cart tracking number
            await _repository.Sp_UpdateCartTrackingNumber(new UpdateCartTrackingNumberParam
            {
                CartId = request.CartId,
                TrackingNumber = result.TrackingNumber
            });

            return result.GatewayTransporter.TransportToGateway();
        }

        public async Task<IActionResult> BankVerifyAsync()
        {
            var invoice = await _onlinePayment.FetchAsync();

            // Check if the invoice is new or it's already processed before.
            if (invoice.Status != PaymentFetchResultStatus.ReadyForVerifying)
            {
                // You can also see if the invoice is already verified before.
                return new RedirectResult($"{_siteSetting.Value.UiConfig.Url}/payresult");
            }

            var verifyResult = await _onlinePayment.VerifyAsync(invoice);

            if (!verifyResult.IsSucceed)
                return new RedirectResult($"{_siteSetting.Value.UiConfig.Url}/payresult");

            //send sms to user
            var paidCartResponse = 
                await _repository.Sp_PaidCart(new PaidCartParam { TrackingNumber = invoice.TrackingNumber });
            await _smsSrv.PaidOrderSmsAsync(new PaidOrderSmsRequest
            {
                MobileNumber = paidCartResponse.MobileNumber,
                FullName = $"{paidCartResponse.FirstName} {paidCartResponse.LastName}",
                Code = paidCartResponse.CartId.ToString()
            });

            //send sms to provider
            var providersData =
                await _repository.Sp_GetAllCartProviderData(new GetAllCartProviderDataParam { CartId = paidCartResponse.CartId });
            foreach (var provider in providersData)
            {
                await _smsSrv.PaidProviderOrderSmsAsync(new PaidProviderOrderSmsRequest
                {
                    Name = provider.Name,
                    MobileNumber = provider.MobileNumber
                });
            }

            //send sms to admin
            await _smsSrv.PaidAdminOrderSmsAsync(new PaidAdminOrderSmsRequest
            {
                MobileNumber = "09354582000"
            });

            return new RedirectResult($"{_siteSetting.Value.UiConfig.Url}/payresult?ci=" + paidCartResponse.CartId);
        }

        public async Task<string> GetCartBankResponseAsync(int cartId)
        {
            var userId = HttpContextExtensions.GetUserId().Value;

            var result = await _repository.Sp_GetCartBankResponse(new GetCartBankResponseParam
            {
                CartId = cartId,
                UserId = userId
            });

            return result;
        }

        public async Task<BasePagingResult<GetAllUserCompleteCartVm>> GetAllUserCompleteCartAsync(GetAllUserCompleteCartRequest request)
        {
            var userId = HttpContextExtensions.GetUserId().Value;

            return await _repository.Sp_GetAllUserCompleteCart(new GetAllUserCompleteCartParam
            {
                UserId = userId,
                PageNumber = request.PageNumber,
                PageRecord = request.PageRecord
            });
        }

        public async Task<BaseCartInfoResult<GetUserCompleteCartProductVm, GetUserCompleteCartInfoVm>> GetUserCompleteCartInfoAsync(int cartId)
        {
            var userId = HttpContextExtensions.GetUserId().Value;

            var results = await _repository.Sp_GetUserCompleteCartInfo(new GetUserCompleteCartInfoParam
            {
                CartId = cartId,
                UserId = userId
            });

            if (results == null || results.Products.Count() == 0)
                return null;

            var cdnFiles = await _cdnService.GetCdnManyFilePathAsync(results.Products.Select(z => z.CdnFileId).ToArray());

            foreach (var result in results.Products.ToList())
            {
                var photo = cdnFiles.FirstOrDefault(z => z.Id == result.CdnFileId);
                if (photo != null)
                    result.Photo = photo.Path;
            }

            return results;
        }

        public async Task<BasePagingResult<GetAllProviderCompleteCartVm>> GetAllProviderCompleteCartAsync(GetAllProviderCompleteCartRequest request)
        {
            var providerId = HttpContextExtensions.GetProviderId().Value;

            return await _repository.Sp_GetAllProviderCompleteCart(new GetAllProviderCompleteCartParam
            {
                ProviderId = providerId,
                PageNumber = request.PageNumber,
                PageRecord = request.PageRecord,
                SortColumn = request.SortColumn,
                SortOrder = request.SortOrder
            });
        }

        public async Task<BaseCartInfoResult<GetProviderCompleteCartProductVm,
            GetProviderCompleteCartInfoVm>> GetProviderCompleteCartInfoAsync(int cartId)
        {
            var providerId = HttpContextExtensions.GetProviderId().Value;
            var results = await _repository.Sp_GetProviderCompleteCartInfo(new GetProviderCompleteCartInfoParam
            {
                CartId = cartId,
                ProviderId = providerId
            });

            if (results == null || results.Products.Count() == 0)
                return results;

            var cdnFiles = await _cdnService.GetCdnManyFilePathAsync(results.Products.Select(z => z.CdnFileId).ToArray());

            foreach (var result in results.Products.ToList())
            {
                var photo = cdnFiles.FirstOrDefault(z => z.Id == result.CdnFileId);
                if (photo != null)
                    result.Photo = photo.Path;
            }

            return results;
        }

        public async Task<int> GetProviderInquiryCartCountAsync()
        {
            var providerId = HttpContextExtensions.GetProviderId().Value;

            return await _repository.Sp_GetProviderInquiryCartCount(new GetProviderInquiryCartCountParam
            {
                ProviderId = providerId
            });
        }

        public async Task<int> GetProviderCompleteCartCountAsync()
        {
            var providerId = HttpContextExtensions.GetProviderId().Value;

            return await _repository.Sp_GetProviderCompleteCartCount(new GetProviderCompleteCartCountParam
            {
                ProviderId = providerId
            });
        }

        public async Task<int> GetProviderCustomerCartCountAsync()
        {
            var providerId = HttpContextExtensions.GetProviderId().Value;

            return await _repository.Sp_GetProviderCustomerCartCount(new GetProviderCustomerCartCountParam
            {
                ProviderId = providerId
            });
        }

        public async Task<IEnumerable<GetWeeklyProviderCompleteCartChartVm>> GetWeeklyProviderCompleteCartChartAsync()
        {
            var providerId = HttpContextExtensions.GetProviderId().Value;

            return  await _repository.Sp_GetWeeklyProviderCompleteCartChart(new GetWeeklyProviderCompleteCartChartParam
            {
                ProviderId = providerId
            });
        }

        public async Task<IEnumerable<GetWeeklyProviderCustomerCartChartVm>> GetWeeklyProviderCustomerCartChartAsync()
        {
            var providerId = HttpContextExtensions.GetProviderId().Value;

            return await _repository.Sp_GetWeeklyProviderCustomerCartChart(new GetWeeklyProviderCustomerCartChartParam
            {
                ProviderId = providerId
            });
        }

        public async Task<ServiceResult> SetProviderCartStatusAsync(SetProviderCartStatusRequest request)
        {
            var providerId = HttpContextExtensions.GetProviderId().Value;
            await _repository.Sp_SetProviderCartStatus(
                new SetProviderCartStatusParam()
                {
                    ProviderId = providerId,
                    CartId = request.CartId,
                    StatusId = request.StatusId,
                    Description= request.Description
                });

            return _serviceResultHelper.Response(null);
        }


        #endregion
    }
}
