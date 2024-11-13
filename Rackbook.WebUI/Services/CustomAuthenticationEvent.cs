using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Net.Http.Headers;
using Rackbook.Infrastructure;
using System.Linq.Dynamic.Core;
using System.Security.Claims;

namespace Rackbook.WebUI.Services
{
    public sealed class CustomAuthenticationEvent : CookieAuthenticationEvents
    {
        private readonly AppDbContext _dbContext;
        private readonly IHttpContextAccessor _httpContext;
        public CustomAuthenticationEvent(AppDbContext dbContext, IHttpContextAccessor httpContext)
        {
            this._dbContext = dbContext;
            this._httpContext = httpContext;
        }

        public override Task RedirectToLogin(RedirectContext<CookieAuthenticationOptions> context)
        {
            context.RedirectUri = "/Login";
            return base.RedirectToLogin(context);
        }

        public override Task CheckSlidingExpiration(CookieSlidingExpirationContext context)
        {
          
            return base.CheckSlidingExpiration(context);
        }

        public override Task RedirectToAccessDenied(RedirectContext<CookieAuthenticationOptions> context)
        {
            return base.RedirectToAccessDenied(context);
        }

        public override Task RedirectToReturnUrl(RedirectContext<CookieAuthenticationOptions> context)
        {
            context.RedirectUri = "/";
            return base.RedirectToReturnUrl(context);
        }



        public override async Task ValidatePrincipal(CookieValidatePrincipalContext context)
        {
            var userPrincipal = context.Principal;

            if (userPrincipal is not null)
            {

                if (context.Principal is not null)
                {
                    var claimsIdentity = context.Principal.Identity as ClaimsIdentity;
                    if (claimsIdentity?.Claims == null || !claimsIdentity.Claims.Any())
                    {
                        // this is not our issued cookie
                        await handleUnauthorizedRequest(context);
                        return;
                    }

                    // Look for the LastChanged claim.
                    var strUserID = (from c in userPrincipal.Claims
                                     where c.Type == ClaimTypes.NameIdentifier
                                     select c.Value).FirstOrDefault();


                    if (string.IsNullOrEmpty(strUserID))
                    {
                        await handleUnauthorizedRequest(context);
                        context.HttpContext.Response.Redirect("/Unauthorized");
                    }
                    else
                    {

                        if (context.HttpContext.Request.Path == "/Login" ||
                            context.HttpContext.Request.Path.ToString().ToLower() == "/verifyuseraccount")
                        {
                            context.HttpContext.Response.Redirect("/");
                            return;
                        }
                    }
                }
            }
        }

        private async Task handleUnauthorizedRequest(CookieValidatePrincipalContext context)
        {
            context.RejectPrincipal();
            if (context.Request.Cookies.Count > 0)
            {
                var siteCookies = context.Request.Cookies.Where(
                    c => c.Key.Contains(".AspNetCore.") ||
                c.Key.Contains("Microsoft.Authentication") ||
                c.Key.Contains("Cookies") || 
                c.Key.Contains("Rackbook_Navigation"));
                foreach (var cookie in siteCookies)
                {
                    context.Response.Cookies.Delete(cookie.Key);
                }

            }

            await Task.CompletedTask;

        }

        private static bool IsAjaxRequest(HttpRequest request)
        {
            return string.Equals(request.Query[HeaderNames.XRequestedWith], "XMLHttpRequest", StringComparison.Ordinal) ||
                string.Equals(request.Headers.XRequestedWith, "XMLHttpRequest", StringComparison.Ordinal);
        }
    }
}
