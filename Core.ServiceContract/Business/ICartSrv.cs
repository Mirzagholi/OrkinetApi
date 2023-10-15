using Core.Common.Base;
using Core.Common.ShareModels;
using Core.Models.Request.Business.Cart;
using Core.Models.ViewModel.Business.Cart;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Core.ServiceContract.Business
{
    public interface ICartSrv : IInjectableService
    {
        Task<ServiceResult> AddCartAsync(List<AddCartRequest> request);

        Task<ServiceResult> SetCartUserAddressAsync(SetCartUserAddressRequest request);

        Task<ServiceResult> StartInquiryCartAsync(StartInquiryCartRequest request);

        Task<ServiceResult> CheckInquiryCartAsync(CheckInquiryCartRequest request);

        Task<ServiceResult> SetCartDeliveryPriceAsync(SetCartDeliveryPriceRequest request);

        Task<BasePagingResult<GetAllActiveInquiryCartVm>> GetAllActiveInquiryCartAsync(GetAllActiveInquiryCartRequest request);

        Task<BasePagingResult<GetAllProviderInquiryCartVm>> GetAllProviderInquiryCartAsync(GetAllProviderInquiryCartRequest request);

        Task<ServiceResult> SetResultInquiryCartAsync(SetResultInquiryCartRequest request);

        Task<ServiceResult> CancelInquiryCartAsync(CancelInquiryCartRequest request);

        Task<ServiceResult> SetCartInfoAsync(SetCartInfoRequest request);

        Task<BaseCartInfoResult<GetProviderInquiryCartProductVm, GetProviderInquiryCartInfoVm>> GetProviderInquiryCartInfoAsync(int cartId);

        Task<IActionResult> PayCartAsync(PayCartRequest request);

        Task<IActionResult> BankVerifyAsync();

        Task<string> GetCartBankResponseAsync(int cartId);

        Task<BasePagingResult<GetAllUserCompleteCartVm>> GetAllUserCompleteCartAsync(GetAllUserCompleteCartRequest request);

        Task<BaseCartInfoResult<GetUserCompleteCartProductVm, GetUserCompleteCartInfoVm>> GetUserCompleteCartInfoAsync(int cartId);

        Task<BasePagingResult<GetAllProviderCompleteCartVm>> GetAllProviderCompleteCartAsync(GetAllProviderCompleteCartRequest request);

        Task<BaseCartInfoResult<GetProviderCompleteCartProductVm, GetProviderCompleteCartInfoVm>> GetProviderCompleteCartInfoAsync(int cartId);

        Task<int> GetProviderInquiryCartCountAsync();

        Task<int> GetProviderCompleteCartCountAsync();

        Task<int> GetProviderCustomerCartCountAsync();

        Task<IEnumerable<GetWeeklyProviderCompleteCartChartVm>> GetWeeklyProviderCompleteCartChartAsync();

        Task<IEnumerable<GetWeeklyProviderCustomerCartChartVm>> GetWeeklyProviderCustomerCartChartAsync();

        Task<ServiceResult> SetProviderCartStatusAsync(SetProviderCartStatusRequest request);
    }
}
