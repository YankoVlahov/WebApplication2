using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;
using System.Configuration;
using System.Security.Claims;
using WebApplication2.Models;

namespace WebApplication2.Services
{
    public class UserManager : IUserManager
    {
        private readonly masterthesisContext _dbContext;
        private readonly IHttpContextAccessor _accessor;

        public UserManager(masterthesisContext dbContext, IHttpContextAccessor accessor)
        {
            _accessor = accessor;
            _dbContext = dbContext;

        }
            

        public async Task SignIn(HttpContext httpContext, UserRequest user, bool isPersistent = false)
        {
            
                var identitySqlUser = await _dbContext.IdentitySqlUsers.Where(x => x.Name == user.Name).FirstOrDefaultAsync();

                ClaimsIdentity identity = new ClaimsIdentity(this.GetUserClaims(identitySqlUser), CookieAuthenticationDefaults.AuthenticationScheme);
                //ClaimsPrincipal principal = new ClaimsPrincipal(identity);

                //await httpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);
                await httpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(identity));
            
        }

        public async Task SignOut(HttpContext httpContext)
        {
            await httpContext.SignOutAsync();
        }

        private IEnumerable<Claim> GetUserClaims(IdentitySqlUser? user)
        {
            List<Claim> claims = new List<Claim>();
            claims.Add(new Claim("UserID", user.Id.ToString()));
            claims.Add(new Claim("Password", user.Name)); //Not a good idea
            claims.Add(new Claim("Admin", user.Admin.ToString())); //Not a good idea;
            return claims;
        }
    }

    public interface IUserManager
    {
        Task SignIn(HttpContext httpContext, UserRequest user, bool isPersistent = false);
        Task SignOut(HttpContext httpContext);
    }
}
