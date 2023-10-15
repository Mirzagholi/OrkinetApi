using Core.Common.Base.Controllers;
using ElmahCore;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Text;

namespace OfoghAds.Controllers
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ApiController, Route("api/[controller]/[action]/{id?}")]
    public class ErrorController : BaseController
    {
        [AllowAnonymous]
        [HttpGet]
        public IActionResult Index(int? id)
        {
            var logBuilder = new StringBuilder();

            var statusCodeReExecuteFeature = HttpContext.Features.Get<IStatusCodeReExecuteFeature>();
            logBuilder.Append("Error ").Append(id).Append(" for ").Append(Request.Method).Append(' ').Append(statusCodeReExecuteFeature?.OriginalPath ?? Request.Path.Value).Append(Request.QueryString.Value).AppendLine("\n");

            var exceptionHandlerFeature = this.HttpContext.Features.Get<IExceptionHandlerFeature>();
            if (exceptionHandlerFeature?.Error != null)
            {
                var exception = exceptionHandlerFeature.Error;
                logBuilder.Append("<h1>Exception: ").Append(exception.Message).Append("</h1>").AppendLine(exception.StackTrace);
            }

            foreach (var header in Request.Headers)
            {
                var headerValues = string.Join(",", value: header.Value);
                logBuilder.Append(header.Key).Append(": ").AppendLine(headerValues);
            }

            ElmahExtensions.RiseError(new Exception(logBuilder.ToString()));

            if (id == null)
            {
                return Content("متاسفانه در حین پردازش درخواست جاری خطایی رخ داده‌ است");
            }

            switch (id.Value)
            {
                case 401:
                case 403:
                    return Content("متاسفانه شما مجوز دسترسی به صفحه‌ی درخواستی را ندارید");
                case 404:
                    return Content("اطلاعات درخواستی یافت نشد");

                default:
                    return Content($"متاسفانه در حین پردازش درخواست جاری خطایی رخ داده ‌است | err code: {id}");
            }
        }
    }
}