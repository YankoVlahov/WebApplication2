using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security;
using System.Text;
using System.IO;
using System.Security.Cryptography;
using masterLib;
using WebApplication2.Models;
using WebApplication2.Services;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;

namespace WebApplication2.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AccountController : Controller
    {
        private IUserManager _userManager;
       private IUserService _service;
        
        public AccountController(IUserManager userManager, IUserService service)
        {
            _service = service;
            _userManager = userManager;
        }

        [AllowAnonymous]
        public async Task<IActionResult> GetUser([FromForm] UserRequest userRequest)
        {
            if (userRequest.Name == null || userRequest.Password == null)
            {
                // return NotFound();
                ViewBag.Name("попълнете всички полета");
                return null;
            }
            else
            {
                if (!ModelState.IsValid)
                    return View("Index");
                await _userManager.SignIn(this.HttpContext, userRequest);
                return RedirectToAction("Index", "Home");

            }
        }


        [Authorize]
        [HttpPost]
        public async Task<ActionResult> Adduser([FromForm] UserRequest  userRequest)
        {
            if (userRequest.Name == null || userRequest.Password == null)
            {
                return View("NotFound");
            }
            else
            {
                if (await _service.Adduser(userRequest) == null)
                {
                    return View("ExistData");
                }
                else
                {
                    return View("Found");
                }
                
            }
        }

        [HttpGet]
        public async Task<List<IdentitySqlTicket>> GetTickets()
        {
            return await _userManager.GetTickets();
         
        }
    }
}
