using MediatR;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Rackbook.Application.ManageUsers.Queries;
using System.Security.Claims;

namespace Rackbook.WebUI.Controllers
{
    [Route("[controller]/[action]")]
    [Route("[controller]/[action]/{id?}")]
    public class UsersController : ControllerBase
    {
        private readonly IMediator _mediatR;
        public UsersController(IMediator mediatR)
        {
            this._mediatR = mediatR;
        }

        [HttpPost]
        public async Task<ActionResult> Login()
        {

            try
            {
                string Username=  Request.Form["Username"].ToString();
                string Userpassword = Request.Form["Password"].ToString();

                var Result = await this._mediatR.Send(new ReadAllUsers { filter = x => x.UserName.ToLower().Equals(Username.ToLower()) &&
                x.Password.Equals(Userpassword) }); 


                if (Result is not null)
                {
                    var user = await Result.FirstOrDefaultAsync();

                    if (user is not null)
                    {
                        List<Claim> claims = new List<Claim>();
                        claims.Add(new Claim(ClaimTypes.NameIdentifier, user.UserID.ToString()));
                        claims.Add(new Claim(ClaimTypes.Name, user.UserName.ToString()));
                        claims.Add(new Claim(ClaimTypes.GivenName, user.FullName.ToString()));
                        claims.Add(new Claim(ClaimTypes.Role, user.UserRoleName.ToString()));
                        claims.Add(new Claim(ClaimTypes.MobilePhone, user?.Mobile ?? ""));
                        claims.Add(new Claim(ClaimTypes.Email, user?.Email ?? ""));
                        claims.Add(new Claim("CompanyID", user.CompanyID.ToString()));

                        ClaimsIdentity claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                        ClaimsPrincipal claimsPrincipal = new ClaimsPrincipal(claimsIdentity);


                        await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, claimsPrincipal, new AuthenticationProperties
                        {
                            AllowRefresh = true,
                            IsPersistent = true,
                            IssuedUtc = DateTime.UtcNow,
                            ExpiresUtc = DateTime.UtcNow.AddDays(30)                           
                        });


                        return LocalRedirect("/");

                    }
                    else
                    {
                        return LocalRedirect("/Login?error=User ID or Password is invalid");
                    }

                }
                else
                {
                    return LocalRedirect("/Login?error=User ID or Password is invalid");
                }

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        [HttpGet]
        public async Task<ActionResult> Logout()
        {



            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);

            if (HttpContext.Request.Cookies.Count > 0)
            {
                var siteCookies = HttpContext.Request.Cookies.Where(
                    c => c.Key.Contains(".AspNetCore.") ||
                c.Key.Contains("Microsoft.Authentication") ||
                c.Key.Contains("Cookies"));
                foreach (var cookie in siteCookies)
                {
                    HttpContext.Response.Cookies.Delete(cookie.Key);
                }



                

            }

            return LocalRedirect("/Login");
        }
    }
}
