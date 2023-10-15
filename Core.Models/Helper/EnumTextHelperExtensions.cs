using Core.Models.Enum.Business.Product;
using Core.Models.Enum.Business.Provider;
using Core.Models.Enum.Common;
using Core.Models.Enum.Security;

namespace Core.Models.Helper
{
    public static class EnumTextHelperExtensions
    {
        public static string GetStatusTextByCulture(this StatusType status)
        {
            var result = string.Empty;
            switch (status)
            {
                case StatusType.Active:
                    //result += EnumResources.Status_Active_Display;
                    result += "فعال";
                    break;
                case StatusType.DeActive:
                    result += "غیر فعال";
                    break;
                case StatusType.Deleted:
                    result += "حذف شده";
                    break;
                case StatusType.WaitForConfirm:
                    result += "در انتظار تایید";
                    break;
                case StatusType.WaitForGetCoordinate:
                    result += "در انتظار ثبت موقعیت در نقشه";
                    break;
                case StatusType.WaitForCreateAccount:
                    result += "در انتظار ساخت حساب کاربری";
                    break;
                case StatusType.WaitForConfirmAccount:
                    result += "در انتظار تایید حساب کاربری";
                    break;
                case StatusType.PreOrder:
                    result += "پیش سفارش";
                    break;
                case StatusType.Inquiring:
                    result += "در حال استعلام";
                    break;
                case StatusType.DoneInquiry:
                    result += "اتمام استعلام";
                    break;
                case StatusType.Paid:
                    result += "پرداخت شده";
                    break;
                case StatusType.Delivered:
                    result += "تحویل داده شده";
                    break;
                case StatusType.UnDelivered:
                    result += "تحویل داده نشده";
                    break;
                case StatusType.Final:
                    result += "نهایی";
                    break;
                case StatusType.Open:
                    result += "باز";
                    break;
                case StatusType.Close:
                    result += "بسته";
                    break;
                default:
                    result += "مشخص نشده";
                    break;
            }
            return
                result;
        }

        public static string GetProviderTypeTextByCulture(this ProviderType providerType)
        {
            var result = string.Empty;
            switch (providerType)
            {
                case ProviderType.Shop:
                    result += "فروشگاه";
                    break;
                case ProviderType.Kiosk:
                    result += "کیوسک";
                    break;
                case ProviderType.Wholesaler:
                    result += "عمده فروش";
                    break;
            }
            return
                result;
        }

        public static string GetContactTypeTextByCulture(this ContactType contactType)
        {
            var result = string.Empty;
            switch (contactType)
            {
                case ContactType.Email:
                    result += "فروشگاه";
                    break;
                case ContactType.Mobile:
                    result += "موبایل";
                    break;
                case ContactType.Phone:
                    result += "شماره تلفن";
                    break;
                case ContactType.Fax:
                    result += "فکس";
                    break;
            }
            return
                result;
        }

        public static string GetPreparationTypeTextByCulture(this PreparationType preparationType)
        {
            var result = string.Empty;
            switch (preparationType)
            {
                case PreparationType.Daily:
                    result += "سفارش روز";
                    break;
                case PreparationType.Tomorrow:
                    result += "سفارش فردایی";
                    break;
            }
            return
                result;
        }

        public static string GetGenderTypeTextByCulture(this GenderType genderType)
        {
            var result = string.Empty;
            switch (genderType)
            {
                case GenderType.Male:
                    result += "مرد";
                    break;
                case GenderType.Female:
                    result += "زن";
                    break;
            }
            return
                result;
        }
    }
}