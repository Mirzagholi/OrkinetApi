
using Core.Common.ShareModels;
using System;
using System.Collections.Generic;
using System.Text;
using Core.Common.Enum;

namespace Core.Common.Helpers
{
    public class MessageHelper
    {
        public static Message Result(int? code)
        {
            code ??= 0;
            return code switch
            {
                0 => new Message() {Status = MessageStatus.Success, Text = "عملیات موفق"},
                1 => new Message() {Status = MessageStatus.Error, Text = "خطا در ثبت اطلاعات"},
                2 => new Message() {Status = MessageStatus.Error, Text = "خطا در ویرایش اطلاعات"},
                3 => new Message() {Status = MessageStatus.Error, Text = "خطا در حذف رکورد"},
                4 => new Message() {Status = MessageStatus.Error, Text = "نام کاربری یا کلمه عبور صحیح نمی باشد"},
                5 => new Message() { Status = MessageStatus.Error, Text = "این شماره موبایل قبلا در سیستم به ثبت رسیده است" },
                6 => new Message() {Status = MessageStatus.Error, Text = "ایمیل قبلا در سیستم به ثبت رسیده است"},
                7 => new Message() {Status = MessageStatus.Error, Text = "کد تاییده ثبت نام صحیح نمی باشد"},
                8 => new Message() {Status = MessageStatus.Error, Text = "خطای داخلی"},
                9 => new Message() {Status = MessageStatus.Error, Text = "نام کاربری یافت نشد"},
                10 => new Message() {Status = MessageStatus.Error, Text = "کد وارد شده صحیح نیست"},
                11 => new Message() {Status = MessageStatus.Error, Text = "کد امنیتی وارد شده معتبر نمی باشد"},
                12 => new Message() {Status = MessageStatus.Error, Text = "اطلاعات وارد شده تکراری می باشد"},
                13 => new Message() {Status = MessageStatus.Error, Text = "اطلاعات مورد نظر یافت نشد"},
                14 => new Message() {Status = MessageStatus.Error, Text = "کاربر مورد نظر غیر فعال می باشد"},
                15 => new Message() {Status = MessageStatus.Error, Text = "لطفا کد فعال سازی را وارد نمایید"},
                16 => new Message() {Status = MessageStatus.Error, Text = "کد تامین کننده تکراری می باشد"},
                17 => new Message() {Status = MessageStatus.Error, Text = "نام تامین کننده تکراری می باشد"},
                18 => new Message() {Status = MessageStatus.Error, Text = "کد تامین کننده باید بزرگتر از 100 باشد"},
                19 => new Message() {Status = MessageStatus.Error, Text = "امکان ساخت کاربر وجود ندارد"},
                20 => new Message() {Status = MessageStatus.Error, Text = "حذف امکانپذیر نمی باشد" },
                21 => new Message() { Status = MessageStatus.Error, Text = "مبلغ تخفیف از محصول بیشتر است" },
                22 => new Message() { Status = MessageStatus.Error, Text = "کد محصول تکراری می باشد" },
                23 => new Message() { Status = MessageStatus.Error, Text = "لیست اطلاعات موجود نمی باشد" },
                24 => new Message() { Status = MessageStatus.Error, Text = "استعلام امکان پذیر نیست" },
                25 => new Message() { Status = MessageStatus.Error, Text = "استعلام کامل نشده است" },
                26 => new Message() { Status = MessageStatus.Error, Text = "این محصول در لیست علاقه مندی ها وجود دارد" },
                27 => new Message() { Status = MessageStatus.Error, Text = "تاریخ وارد شده شما صحیح نمی باشد" },
                28 => new Message() { Status = MessageStatus.Error, Text = "نیاز به وجود قیمت ثابت فاصله می باشد" },
                29 => new Message() { Status = MessageStatus.Error, Text = "مجوز پرداخت وجود ندارد" },
                30 => new Message() { Status = MessageStatus.Error, Text = "امکان ارتباط با درگاه میسر نمی باشد" },
                31 => new Message() { Status = MessageStatus.Error, Text = "نام کاربری قبلا در سیستم به ثبت رسیده است" },
                32 => new Message() { Status = MessageStatus.Error, Text = "قبل از بسته شدن تمامی سند های مالی امکان ثبت سند جدید وجود ندارد" },
                33 => new Message() { Status = MessageStatus.Error, Text = "سفارش جدیدی برای ثبت سند مالی یافت نشد" },
                _ => new Message() {Status = MessageStatus.Error, Text = "خطای نامشخص"}
            };
        }
    }
}
