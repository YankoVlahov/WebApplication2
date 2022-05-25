using Microsoft.AspNetCore.Mvc;
using WebApplication2.Models;

namespace WebApplication2.Services
{
    public interface IUserService
    {
        string CreateJwt(UserRequest user);
        Task<IdentitySqlUser> GetUser(UserRequest userRequest);
        Task<ActionResult<IdentitySqlUser>> Adduser(UserRequest userRequest);


    }
}