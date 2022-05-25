using Microsoft.AspNetCore.Mvc;
using WebApplication2.Models;

namespace MastersApi.Controllers
{
    public interface IAccount
    {
        ActionResult<IdentitySqlUser> Adduser(string username, string password);
        Task<IdentitySqlUser> GetUser(UserRequest userRequest);
    }
}