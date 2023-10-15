using Core.Common.ShareContract;
using Core.Common.ShareModels;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Net;
using Core.Common.Enum;
using ElmahCore;

namespace Core.Common.Helpers
{
    public class ServiceResultHelper : IServiceResultHelper
    {
        private readonly IHostingEnvironment _hostingEnvironment;

        public ServiceResultHelper(IHostingEnvironment hostingEnv)
        {
            _hostingEnvironment = hostingEnv;
        }

        public ServiceResult Response(object data = null, int? code = null)
        {
            var msg = MessageHelper.Result(code);
            return new ServiceResult() { Status = msg.Status, Messages = new string[] { msg.Text }, Data = data };
        }

        public void Response(Exception ex, HttpContext context)
        {
            context.Response.ContentType = "application/json";

            if (ex.Message.Contains("#"))
            {
                int code = int.Parse(ex.Message.Replace("#", ""));
                var msg = MessageHelper.Result(code);
                var result = JsonConvert.SerializeObject(
                    new ServiceResult()
                    {
                        Status = msg.Status,
                        Messages = new string[] { msg.Text }
                    });

                context.Response.StatusCode = (int)HttpStatusCode.OK;
                context.Response.WriteAsync(result.ToLower());
            }
            else
            {
                ElmahExtensions.RiseError(ex);
                if (_hostingEnvironment.IsDevelopment())
                    throw ex;
                else
                {
                    var result = JsonConvert.SerializeObject(
                        new
                        {
                            Status = MessageStatus.Error,
                            Messages = new string[] { "خطایی در سیستم رخ داده است" }
                        });

                    context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                    context.Response.WriteAsync(result);
                }
            }
        }
    }
}
