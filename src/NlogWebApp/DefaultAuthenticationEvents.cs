using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using Sino.Web.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NlogWebApp
{
    public class DefaultAuthenticationEvents : CookieAuthenticationEvents
    {
        public override Task RedirectToAccessDenied(CookieRedirectContext context)
        {
            context.RedirectUri = null;
            context.Response.StatusCode = 200;
            context.Response.ContentType = "application/json";
            context.Response.WriteAsync(JsonConvert.SerializeObject(new BaseResponse
            {
                ErrorCode = "100002",
                ErrorMessage = "无权限",
                Success = false
            }));
            return Task.CompletedTask;
        }

        public override Task RedirectToLogout(CookieRedirectContext context)
        {
            return base.RedirectToLogout(context);
        }

        public override Task RedirectToLogin(CookieRedirectContext context)
        {
            context.RedirectUri = null;
            context.Response.StatusCode = 200;
            context.Response.ContentType = "application/json";
            context.Response.WriteAsync(JsonConvert.SerializeObject(new BaseResponse
            {
                ErrorCode = "100001",
                ErrorMessage = "未登录",
                Success = false
            }));
            return Task.CompletedTask;
        }

        public override Task RedirectToReturnUrl(CookieRedirectContext context)
        {
            return base.RedirectToReturnUrl(context);
        }
    }
}
