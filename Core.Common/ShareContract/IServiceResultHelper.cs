using Core.Common.ShareModels;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Common.ShareContract
{
    public interface IServiceResultHelper
    {
        ServiceResult Response(object data = null , int? code = null);
        void Response(Exception ex, HttpContext context);
    }
}
