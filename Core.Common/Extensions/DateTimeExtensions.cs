﻿using System;
using System.Globalization;

namespace Core.Common.Extensions
{
    public static class DateTimeExtensions
    {
        public static DateTime PersianToMiladiDateTime(this DateTime date)
        {

            return
                new DateTime(date.Year, date.Month, date.Day, date.Hour, date.Minute, date.Second, new PersianCalendar());
        }

        public static DateTime PersianToMiladiDate(this DateTime date)
        {
            return
                new DateTime(date.Year, date.Month, date.Day, new PersianCalendar());
        }

        public static string MiladiToStringPersianDateTime(this DateTime date)
        {
            var pc = new PersianCalendar();
            return
                $"{pc.GetYear(date):00}/{pc.GetMonth(date):00}/{pc.GetDayOfMonth(date):00} {date.Hour:00}:{date.Minute:00}:{date.Second:00}";
        }

        public static string MiladiToStringPersianDate(this DateTime date)
        {
            var pc = new PersianCalendar();
            return
                $"{pc.GetYear(date):00}/{pc.GetMonth(date):00}/{pc.GetDayOfMonth(date):00}";
        }

        public static string CovertToName(this DateTime date)
        {
            var pc = new PersianCalendar();
            return
                $"{pc.GetYear(date):00}-{pc.GetMonth(date):00}-{pc.GetDayOfMonth(date):00} {date.Hour:00}.{date.Minute:00}.{date.Second:00}";
        }
        public static string ToFileId(this DateTime date)
        {
            var pc = new PersianCalendar();
            return
                $"{date.Second:00}{pc.GetDayOfMonth(date):00}{pc.GetMonth(date):00}{pc.GetYear(date):00}{date.Minute:00}{date.Hour:00}";
        }

        public static string MiladiToStringPersianYear(this DateTime date)
        {
            var pc = new PersianCalendar();
            return
                $"{pc.GetYear(date):00}".Substring(2);
        }

        public static string MiladiToStringPersianYearMonth(this DateTime date)
        {
            var pc = new PersianCalendar();
            return
                $"{pc.GetYear(date):00}/{pc.GetMonth(date):00}";
        }
    }

}