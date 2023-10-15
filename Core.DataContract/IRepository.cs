using System.Collections.Generic;
using Core.Models.ViewModel.Security.Captcha;
using System.Threading.Tasks;
using Core.Common.Base;
using Core.Models.Parameter.Base.Region;
using Core.Models.Parameter.Business.Attribute;
using Core.Models.Parameter.Business.Category;
using Core.Models.Parameter.Business.Menu;
using Core.Models.Parameter.Business.Contact;
using Core.Models.Parameter.Business.PrivateAttribute;
using Core.Models.Parameter.Business.PrivateValue;
using Core.Models.Parameter.Business.Product;
using Core.Models.Parameter.Business.ProductDelivery;
using Core.Models.Parameter.Business.ProductDiscount;
using Core.Models.Parameter.Business.ProductPhoto;
using Core.Models.Parameter.Business.ProductPrice;
using Core.Models.Parameter.Business.Provider;
using Core.Models.Parameter.Business.ProviderContact;
using Core.Models.Parameter.Business.ProviderGallery;
using Core.Models.Parameter.Business.Value;
using Core.Models.ViewModel.Base.Region;
using Core.Models.ViewModel.Business.Attribute;
using Core.Models.ViewModel.Business.Category;
using Core.Models.ViewModel.Business.Contact;
using Core.Models.ViewModel.Business.PrivateAttribute;
using Core.Models.ViewModel.Business.PrivateValue;
using Core.Models.ViewModel.Business.Product;
using Core.Models.ViewModel.Business.ProductDelivery;
using Core.Models.ViewModel.Business.ProductDiscount;
using Core.Models.ViewModel.Business.ProductPhoto;
using Core.Models.ViewModel.Business.ProductPrice;
using Core.Models.ViewModel.Business.Provider;
using Core.Models.ViewModel.Business.ProviderContact;
using Core.Models.ViewModel.Business.ProviderGallery;
using Core.Models.ViewModel.Business.Value;
using Core.Models.ViewModel.Security.UserAddress;
using Core.Models.Parameter.Security.UserAddress;
using Core.Models.ViewModel.Base.Province;
using Core.Models.ViewModel.Base.City;
using Core.Models.Parameter.Base.City;
using Core.Models.Parameter.Base.District;
using Core.Models.ViewModel.Base.District;
using Core.Models.ViewModel.Business.Cart;
using Core.Models.Parameter.Business.Cart;
using Core.Models.ViewModel.Business.Favorite;
using Core.Models.Parameter.Business.Favorite;
using Core.Models.ViewModel.Business.Menu;
using Core.Models.ViewModel.Business.SideBar;
using Core.Models.Parameter.Business.SideBar;
using Core.Models.Parameter.Security.UserRole;
using Core.Models.ViewModel.Security.UserRole;
using Core.Models.Parameter.Security.User;
using Core.Models.ViewModel.Security.User;
using Core.Models.Model.Security;
using Core.Models.Parameter.Security.Token;
using Core.Models.ViewModel.Business.PostalCart;
using Core.Models.ViewModel.Business.CartDeliveryType;
using Core.Models.ViewModel.Business.CartDeliveryPlaceType;
using Core.Models.ViewModel.Business.CartFailedDeliveryType;
using Core.Models.ViewModel.Common.StoreConfig;
using Core.Models.Parameter.Common.ParbadStorage;
using Core.Models.ViewModel.Common.ParbadStorage;
using Core.Models.Parameter.Business.Rating;
using Core.Models.Parameter.Business.ProductComment;
using Core.Models.ViewModel.Business.ProductComment;
using Parbad.Storage.Abstractions.Models;
using Core.Models.Parameter.Business.ProviderAbsorption;
using Core.Models.ViewModel.Business.ProviderAbsorption;
using Core.Models.Parameter.Business.Blog;
using Core.Models.ViewModel.Business.Blog;
using Core.Models.Parameter.Business.ProviderPhoto;
using Core.Models.ViewModel.Business.ProviderPhoto;
using Core.Models.Parameter.Business.WebSiteFile;
using Core.Models.ViewModel.Business.WebSiteFile;
using Core.Models.Parameter.Business.FinancialDocument;
using Core.Models.ViewModel.Business.FinancialDocument;
using Core.Models.ViewModel.Business.Product.GetProviderProductById;

namespace Core.DataContract
{
    public interface IRepository
    {

        // TODO
        // transaction
        // commit
        // rollback

        #region Account

        Task<GetUserInfoVm> Sp_GetUserInfo(GetUserInfoParam parameters);
        Task<AuthenticateVm> Sp_Authentication(AuthenticateParam parameters);
        Task<UserActivationVm> Sp_UserActivation(UserActivationParam parameters);
        Task<GetCaptchaVm> Sp_GetCaptcha();
        Task<UserConfirmCodeVm> Sp_UserConfirmCode(UserConfirmCodeParam parameters);
        Task<ResetPasswordVm> Sp_ResetPassword(ResetPasswordParam parameters);
        Task<AdminAuthenticateVm> Sp_AdminAuthentication(AdminAuthenticateParam parameters);
        Task<UpdateUserVm> Sp_UpdateUser(UpdateUserParam parameters);
        Task<LoginOrRegisterVm> Sp_LoginOrRegister(LoginOrRegisterParam parameters);
        Task<SetPasswordVm> Sp_SetPassword(SetPasswordParam parameters);

        #endregion

        #region Token

        Task Sp_AddUserToken(UserToken parameters);

        Task Sp_DeleteExpiredUserToken();

        Task Sp_DeleteUserToken(DeleteUserTokenParam parameters);

        Task Sp_DeleteUserTokensWithSameRefreshTokenSource(DeleteUserTokensWithSameRefreshTokenSourceParam parameters);

        Task<UserToken> Sp_FindUserToken(FindUserTokenParam parameters);

        Task Sp_DeleteUserTokenByUserId(DeleteUserTokenByUserIdParam parameters);

        Task<UserToken> Sp_IsValidUserToken(IsValidUserTokenParam parameters);

        #endregion

        #region User

        Task<FindUserByIdVm> Sp_FindUserById(FindUserByIdParam parameters);

        Task Sp_UpdateUserLastActivity(UpdateUserLastActivityParam parameters);

        Task<IEnumerable<string>> Sp_GetAllAdminId();

        #endregion

        #region UserRole

        Task<IEnumerable<GetUserRoleVm>> Sp_GetUserRole(GetUserRoleParam parameters);

        #endregion

        #region Category

        Task<AddCategoryVm> Sp_AddCategory(AddCategoryParam parameters);
        Task<UpdateCategoryVm> Sp_UpdateCategory(UpdateCategoryParam parameters);
        Task<UpdateCategoryStatusVm> Sp_UpdateCategoryStatus(UpdateCategoryStatusParam parameters);
        Task<GetCategoryByIdVm> Sp_GetCategoryById(GetCategoryByIdParam parameters);
        Task<IEnumerable<GetCategoryVm>> Sp_GetCategory();
        Task<IEnumerable<GetCategoryDropDownVm>> Sp_GetCategoryDropDown();

        #endregion

        #region Menu

        Task<IEnumerable<GetRootMenuBoxVm>> Sp_GetRootMenuBox();
        Task<IEnumerable<GetSubMenuBoxVm>> Sp_GetSubMenuBox(GetSubMenuBoxParam parameters);
        Task<IEnumerable<GetLandingMenuVm>> Sp_GetLandingMenu();

        #endregion

        #region SideBar

        Task<IEnumerable<GetLandingSideBarVm>> Sp_GetLandingSideBar(GetLandingSideBarParam parameters);

        #endregion

        #region Attribute

        Task<AddAttributeVm> Sp_AddAttribute(AddAttributeParam parameters);
        Task<BasePagingResult<GetAttributeVm>> Sp_GetAttribute(GetAttributeParam parameters);
        Task<GetAttributeByIdVm> Sp_GetAttributeById(GetAttributeByIdParam parameters);
        Task<UpdateAttributeVm> Sp_UpdateAttribute(UpdateAttributeParam parameters);
        Task<UpdateAttributeStatusVm> Sp_UpdateAttributeStatus(UpdateAttributeStatusParam parameters);

        #endregion

        #region Value

        Task<AddValueVm> Sp_AddValue(AddValueParam parameters);
        Task<BasePagingResult<GetValueVm>> Sp_GetValue(GetValueParam parameters);
        Task<GetValueByIdVm> Sp_GetValueById(GetValueByIdParam parameters);
        Task<UpdateValueVm> Sp_UpdateValue(UpdateValueParam parameters);
        Task<UpdateValueStatusVm> Sp_UpdateValueStatus(UpdateValueStatusParam parameters);
        Task<IEnumerable<GetCompleteValueDropDownVm>> Sp_GetCompleteValueDropDown();

        #endregion

        #region Provider

        Task<AddProviderVm> Sp_AddProvider(AddProviderParam parameters);
        Task<BasePagingResult<GetProviderVm>> Sp_GetProvider(GetProviderParam parameters);
        Task<SetProviderCoordinateVm> Sp_SetProviderCoordinate(SetProviderCoordinateParam parameters);
        Task<AddProviderUserMobileVm> Sp_AddProviderUserMobile(AddProviderUserMobileParam parameters);
        Task<ConfirmProviderUserMobileVm> Sp_ConfirmProviderUserMobile(ConfirmProviderUserMobileParam parameters);
        Task<AddProviderUserVm> Sp_AddProviderUser(AddProviderUserParam parameters);
        Task<ProviderAuthenticateVm> Sp_ProviderAuthentication(ProviderAuthenticateParam parameters);
        Task<GetProviderInfoVm> Sp_GetProviderInfo(GetProviderInfoParam parameters);
        Task<UpdateProviderInfoVm> Sp_UpdateProviderInfo(UpdateProviderInfoParam parameters);
        Task<BasePagingResult<GetActiveProviderVm>> Sp_GetActiveProvider(GetActiveProviderParam parameters);
        Task<IEnumerable<GetProviderUiVm>> Sp_GetProviderUi();
        Task<IEnumerable<GetProviderWithCoordinateUiVm>> Sp_GetProviderWithCoordinateUi();
        Task<IEnumerable<GetProviderLandingSideBarVm>> Sp_GetProviderLandingSideBar();
        Task<BaseDoubleResult<GetProviderDetailUiVm, int>> Sp_GetProviderDetailUi(GetProviderDetailUiParam parameters);

        #endregion

        #region ProviderContact

        Task<AddProviderContactVm> Sp_AddProviderContact(AddProviderContactParam parameters);
        Task<IEnumerable<GetProviderContactVm>> Sp_GetProviderContact(GetProviderContactParam parameters);
        Task<DeleteProviderContactVm> Sp_DeleteProviderContact(DeleteProviderContactParam parameters);

        #endregion

        #region Region

        Task<IEnumerable<GetRegionVm>> Sp_GetRegion(GetRegionParam parameters);

        #endregion

        #region PrivateAttribute

        Task<AddPrivateAttributeVm> Sp_AddPrivateAttribute(AddPrivateAttributeParam parameters);
        Task<BasePagingResult<GetPrivateAttributeVm>> Sp_GetPrivateAttribute(GetPrivateAttributeParam parameters);
        Task<UpdatePrivateAttributeVm> Sp_UpdatePrivateAttribute(UpdatePrivateAttributeParam parameters);
        Task<UpdatePrivateAttributeStatusVm> Sp_UpdatePrivateAttributeStatus(UpdatePrivateAttributeStatusParam parameters);
        Task<IEnumerable<GetPrivateAttributeDropDownVm>> Sp_GetPrivateAttributeDropDown(
            GetPrivateAttributeDropDownParam parameters);

        #endregion

        #region PrivateValue

        Task<AddPrivateValueVm> Sp_AddPrivateValue(AddPrivateValueParam parameters);
        Task<BasePagingResult<GetPrivateValueVm>> Sp_GetPrivateValue(GetPrivateValueParam parameters);
        Task<UpdatePrivateValueVm> Sp_UpdatePrivateValue(UpdatePrivateValueParam parameters);
        Task<UpdatePrivateValueStatusVm> Sp_UpdatePrivateValueStatus(UpdatePrivateValueStatusParam parameters);
        Task<IEnumerable<GetCompletePrivateValueDropDownVm>> Sp_GetCompletePrivateValueDropDown
            (GetCompletePrivateValueParam parameters);

        #endregion

        #region ProviderGallery

        Task<AddProviderGalleryVm> Sp_AddProviderGallery(AddProviderGalleryParam parameters);
        Task<IEnumerable<GetProviderGalleryVm>> Sp_GetProviderGallery(GetProviderGalleryParam parameters);
        Task<UpdateProviderGalleryStatusVm> Sp_UpdateProviderGalleryStatus(UpdateProviderGalleryStatusParam parameters);

        #endregion

        #region Product

        Task<AddProductVm> Sp_AddProduct(AddProductParam parameters);
        Task<BaseProductPagingResult<GetProductVm, GetProductAttrValVm, GetProductPrivateAttrValVm, GetProductPhotosVm, GetProductCategoryVm>> 
            Sp_GetProduct(GetProductParam parameters);
        Task<UpdateProductVm> Sp_UpdateProduct(UpdateProductParam parameters);
        Task<UpdateProductStatusVm> Sp_UpdateProductStatus(UpdateProductStatusParam parameters);
        Task<IEnumerable<GetProductDropDownVm>> Sp_GetProductDropDown(GetProductDropDownParam parameters);
        Task<IEnumerable<GetLandingDiscountedProductVm>> Sp_GetLandingDiscountedProduct();
        Task<IEnumerable<GetLandingEconomicProductVm>> Sp_GetLandingEconomicProduct();
        Task<IEnumerable<GetLandingMostSalesProductVm>> Sp_GetLandingMostSalesProduct();
        Task<IEnumerable<GetLandingVipProductVm>> Sp_GetLandingVipProduct();
        Task<BasePagingResult<GetAllProductUiVm>> Sp_GetAllProductUi(GetAllProductUiParam parameters);
        Task<BasePagingResult<GetDiscountedProductUiVm>> Sp_GetDiscountedProductUi(GetDiscountedProductUiParam parameters);
        Task<BasePagingResult<GetNewestProductUiVm>> Sp_GetNewestProductUi(GetNewestProductUiParam parameters);
        Task<BasePagingResult<GetExpensiveProductUiVm>> Sp_GetExpensiveProductUi(GetExpensiveProductUiParam parameters);
        Task<BasePagingResult<GetCheapestProductUiVm>> Sp_GetCheapestProductUi(GetCheapestProductUiParam parameters);
        Task<BaseProductDetailResult<GetProductDetailUiVm>> Sp_GetProductDetailUi(GetProductDetailUiParam parameters);
        Task<IEnumerable<CheckProductForCartVm>> Sp_CheckProductForCart(CheckProductForCartParam parameters);
        Task<BaseProductPagingResult<GetAllProductForAdminVm, GetAllProductAttrValForAdminVm, GetAllProductPrivateAttrValForAdminVm, GetAllProductPhotosForAdminVm, GetAllProductCategoryForAdminVm>>
             Sp_GetAllProductForAdmin(GetAllProductForAdminParam parameters);
        Task Sp_ConfirmProduct(ConfirmProductParam parameters);
        Task<BaseFifthResult<GetProviderProductByIdVm, GetProviderProductByIdAttrValVm, GetProviderProductByIdPrivateAttrValVm,
            GetProviderProductByIdPhotoVm, int>> Sp_GetAdminProductById(GetProviderProductByIdParam parameters);

        #endregion

        #region ProductPrice

        Task<UpdateProductPriceVm> Sp_UpdateProductPrice(UpdateProductPriceParam parameters);

        #endregion

        #region ProductPhoto

        Task<AddProductPhotoVm> Sp_AddProductPhoto(AddProductPhotoParam parameters);
        Task<IEnumerable<GetProductPhotoVm>> Sp_GetProductPhoto(GetProductPhotoParam parameters);
        Task<DeleteProductPhotoVm> Sp_DeleteProductPhoto(DeleteProductPhotoParam parameters);

        #endregion

        #region ProductDiscount

        Task<AddProductDiscountVm> Sp_AddProductDiscount(AddProductDiscountParam parameters);
        Task<BasePagingResult<GetProductDiscountVm>> Sp_GetProductDiscount(GetProductDiscountParam parameters);
        Task<UpdateProductDiscountVm> Sp_UpdateProductDiscount(UpdateProductDiscountParam parameters);
        Task<UpdateProductDiscountStatusVm> Sp_UpdateProductDiscountStatus(UpdateProductDiscountStatusParam parameters);
        Task<int> Sp_GetProviderActiveProductDiscountCount(GetProviderActiveProductDiscountCountParam parameters);

        #endregion

        #region ProductDelivery

        Task<AddProductDeliveryVm> Sp_AddProductDelivery(AddProductDeliveryParam parameters);
        Task<BasePagingResult<GetProductDeliveryVm>> Sp_GetProductDelivery(GetProductDeliveryParam parameters);
        Task<UpdateProductDeliveryVm> Sp_UpdateProductDelivery(UpdateProductDeliveryParam parameters);
        Task<UpdateProductDeliveryStatusVm> Sp_UpdateProductDeliveryStatus(UpdateProductDeliveryStatusParam parameters);

        #endregion

        #region Contact

        Task<AddContactUsVm> Sp_AddContactUs(AddContactUsParam parameters);

        #endregion

        #region UserAddress

        Task<AddUserAddressVm> Sp_AddUserAddress(AddUserAddressParam parameters);
        Task<UpdateUserAddressVm> Sp_UpdateUserAddress(UpdateUserAddressParam parameters);
        Task<DeleteUserAddressVm> Sp_DeleteUserAddress(DeleteUserAddressParam parameters);
        Task<IEnumerable<GetAllUserAddressVm>> Sp_GetAllUserAddress(GetAllUserAddressParam parameters);
        Task<GetUserAddressByIdVm> Sp_GetUserAddressById(GetUserAddressByIdParam parameters);
        Task<GetDefaultUserAddressVm> Sp_GetDefaultUserAddress(GetDefaultUserAddressParam parameters);

        #endregion

        #region Province

        Task<IEnumerable<GetProvinceVm>> Sp_GetProvince();

        #endregion

        #region City

        Task<IEnumerable<GetCityVm>> Sp_GetCity(GetCityParam parameters);

        #endregion

        #region District

        Task<IEnumerable<GetDistrictVm>> Sp_GetDistrict(GetDistrictParam parameters);

        #endregion

        #region Cart

        Task<AddCartVm> Sp_AddCart(AddCartParam parameters);
        Task<SetCartUserAddressVm> Sp_SetCartUserAddress(SetCartUserAddressParam parameters);
        Task<IEnumerable<StartInquiryCartVm>> Sp_StartInquiryCart(StartInquiryCartParam parameters);
        Task<IEnumerable<CheckInquiryCartVm>> Sp_CheckInquiryCart(CheckInquiryCartParam parameters);
        Task<IEnumerable<SetCartDeliveryPriceVm>> Sp_SetCartDeliveryPrice(SetCartDeliveryPriceParam parameters);
        Task<IEnumerable<GetCartProviderCoordinateVm>> Sp_GetCartProviderCoordinate(GetCartProviderCoordinateParam parameters);
        Task<GetCartUserCoordinateVm> Sp_GetCartUserCoordinate(GetCartUserCoordinateParam parameters);
        Task<BasePagingResult<GetAllActiveInquiryCartVm>> Sp_GetAllActiveInquiryCart(GetAllActiveInquiryCartParam parameters);
        Task Sp_DeleteExpireInquiryCart(DeleteExpireInquiryCartParam parameters);
        Task<IEnumerable<string>> Sp_GetAllInquiryProviderUserId(GetAllInquiryProviderUserIdParam parameters);
        Task<BasePagingResult<GetAllProviderInquiryCartVm>> Sp_GetAllProviderInquiryCart(GetAllProviderInquiryCartParam parameters);
        Task<SetResultInquiryCartVm> Sp_SetResultInquiryCart(SetResultInquiryCartParam parameters);
        Task<CancelInquiryCartVm> Sp_CancelInquiryCart(CancelInquiryCartParam parameters);
        Task<IEnumerable<int>> Sp_GetAllUserActiveInquiryCartId(GetAllUserActiveInquiryCartIdParam parameters);
        Task<IEnumerable<GetAllPostalCartVm>> Sp_GetAllPostalCart();
        Task<IEnumerable<GetAllCartDeliveryTypeVm>> Sp_GetAllCartDeliveryType();
        Task<IEnumerable<GetAllCartDeliveryPlaceTypeVm>> Sp_GetAllCartDeliveryPlaceType();
        Task<IEnumerable<GetAllCartFailedDeliveryTypeVm>> Sp_GetAllCartFailedDeliveryType();
        Task<GetStoreConfigVm> Sp_GetStoreConfig();
        Task<SetCartInfoVm> Sp_SetCartInfo(SetCartInfoParam parameters);
        Task<bool> Sp_AllowPayCart(AllowPayCartParam parameters);
        Task<int?> Sp_GetCartTotalPrice(GetCartTotalPriceParam parameters);
        Task<UserInquiryStatusVm> Sp_UserInquiryStatus(UserInquiryStatusParam parameters);
        Task<PaidCartVm> Sp_PaidCart(PaidCartParam parameters);
        Task<string> Sp_GetCartBankResponse(GetCartBankResponseParam parameters);
        Task Sp_UpdateCartTrackingNumber(UpdateCartTrackingNumberParam parameters);
        Task<BasePagingResult<GetAllUserCompleteCartVm>> Sp_GetAllUserCompleteCart(GetAllUserCompleteCartParam parameters);
        Task<BaseCartInfoResult<GetUserCompleteCartProductVm, GetUserCompleteCartInfoVm>>
            Sp_GetUserCompleteCartInfo(GetUserCompleteCartInfoParam parameters);
        Task<BasePagingResult<GetAllProviderCompleteCartVm>> Sp_GetAllProviderCompleteCart(GetAllProviderCompleteCartParam parameters);
        Task<BaseCartInfoResult<GetProviderInquiryCartProductVm, GetProviderInquiryCartInfoVm>>
            Sp_GetProviderInquiryCartInfo(GetProviderInquiryCartInfoParam parameters);
        Task<BaseCartInfoResult<GetProviderCompleteCartProductVm, GetProviderCompleteCartInfoVm>> 
            Sp_GetProviderCompleteCartInfo(GetProviderCompleteCartInfoParam parameters);
        Task<int> Sp_GetProviderCompleteCartCount(GetProviderCompleteCartCountParam parameters);
        Task<int> Sp_GetProviderInquiryCartCount(GetProviderInquiryCartCountParam parameters);
        Task<int> Sp_GetProviderCustomerCartCount(GetProviderCustomerCartCountParam parameters);
        Task<IEnumerable<GetWeeklyProviderCompleteCartChartVm>> Sp_GetWeeklyProviderCompleteCartChart(GetWeeklyProviderCompleteCartChartParam parameters);
        Task<IEnumerable<GetWeeklyProviderCustomerCartChartVm>> Sp_GetWeeklyProviderCustomerCartChart(GetWeeklyProviderCustomerCartChartParam parameters);
        Task<IEnumerable<GetAllCartProviderDataVm>> Sp_GetAllCartProviderData(GetAllCartProviderDataParam parameters);
        Task Sp_SetProviderCartStatus(SetProviderCartStatusParam parameters);

        #endregion

        #region Favorite

        Task<AddFavoriteVm> Sp_AddFavorite(AddFavoriteParam parameters);
        Task<DeleteFavoriteVm> Sp_DeleteFavorite(DeleteFavoriteParam parameters);
        Task<BasePagingResult<GetAllFavoriteUiVm>> Sp_GetAllFavoriteUi(GetAllFavoriteUiParam parameters);

        #endregion

        #region Parbad

        Task<int> Sp_AddPayment(AddPaymentParam parameters);
        Task<GetPaymentByIdVm> Sp_GetPaymentById(GetPaymentByIdParam parameters);
        Task Sp_UpdatePayment(UpdatePaymentParam parameters);
        Task Sp_DeletePayment(DeletePaymentParam parameters);
        Task<int> Sp_AddTransaction(AddTransactionParam parameters);
        Task<GetTransactionByIdVm> Sp_GetTransactionById(GetTransactionByIdParam parameters);
        Task Sp_UpdateTransaction(UpdateTransactionParam parameters);
        Task Sp_DeleteTransaction(DeleteTransactionParam parameters);
        Task<IEnumerable<Payment>> Sp_GetAllPayment();
        Task<IEnumerable<Transaction>> Sp_GetAllTransaction();

        #endregion

        #region Rating

        Task Sp_UpdateProductRating(UpdateProductRatingParam parameters);
        Task Sp_UpdateProviderRating(UpdateProviderRatingParam parameters);

        #endregion

        #region ProductComment

        Task Sp_AddUserProductComment(AddUserProductCommentParam parameters);
        Task<BasePagingResult<GetAllProductCommentVm>> Sp_GetAllProductComment(GetAllProductCommentParam parameters);
        Task Sp_UpdateProductCommentConfirm(UpdateProductCommentConfirmParam parameters);
        Task Sp_ReplyAdminProductComment(ReplyAdminProductCommentParam parameters);
        Task<IEnumerable<GetAllProductCommentReplyVm>> Sp_GetAllProductCommentReply(GetAllProductCommentReplyParam parameters);
        Task<BasePagingResult<GetAllProductCommentUiVm>> Sp_GetAllProductCommentUi(GetAllProductCommentUiParam parameters);

        #endregion

        #region ProviderAbsorption

        Task Sp_AddProviderAbsorption(AddProviderAbsorptionParam parameters);
        Task<BasePagingResult<GetAllProviderAbsorptionVm>> Sp_GetAllProviderAbsorption(GetAllProviderAbsorptionParam parameters);

        #endregion

        #region Blog

        Task Sp_AddBlog(AddBlogParam parameters);
        Task<BasePagingResult<GetAllBlogVm>> Sp_GetAllBlog(GetAllBlogParam parameters);
        Task<IEnumerable<GetAllBlogUiVm>> Sp_GetAllBlogUi();
        Task<GetAllBlogInfoUiVm> Sp_GetAllBlogInfoUi(GetAllBlogInfoUiParam parameters);

        #endregion

        #region ProviderPhoto

        Task<AddProviderPhotoVm> Sp_AddProviderPhoto(AddProviderPhotoParam parameters);
        Task<IEnumerable<GetProviderPhotoVm>> Sp_GetProviderPhoto(GetProviderPhotoParam parameters);
        Task<DeleteProviderPhotoVm> Sp_DeleteProviderPhoto(DeleteProviderPhotoParam parameters);

        #endregion

        #region WebSiteFile

        Task Sp_AddWebSiteFile(AddWebSiteFileParam parameters);
        Task<BasePagingResult<GetAllWebSiteFileVm>> Sp_GetAllWebSiteFile(GetAllWebSiteFileParam parameters);
        Task<DeleteWebSiteFileVm> Sp_DeleteWebSiteFile(DeleteWebSiteFileParam parameters);

        #endregion

        #region FinancialDocument

        Task Sp_AddFinancialDocument(AddFinancialDocumentParam parameters);
        Task<BasePagingResult<GetAllFinancialDocumentVm>> Sp_GetAllFinancialDocument(GetAllFinancialDocumentParam parameters);
        Task<BasePagingResult<GetAllFinancialDocumentInfoVm>> Sp_GetAllFinancialDocumentInfo(GetAllFinancialDocumentInfoParam parameters);

        #endregion
    }
}
