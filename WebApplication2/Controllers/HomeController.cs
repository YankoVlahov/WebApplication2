using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WebApplication2.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using WebApplication2.Controllers;
using masterLib;
using WebApplication2.Services;
using MastersApi.Controllers;

namespace WebApplication2.Controllers
{
    public class HomeController : Controller 
    {
       // private readonly ILogger<HomeController> _logger;
        //private IUserService _service;
        private IUserManager _userManager;
        //private readonly IUserService _userservice;
       //private readonly IHttpContextAccessor _httpContextAccessor;
       // private readonly IAccount account ; 

        public HomeController(
            /*ILogger<HomeController> logger,*/
           /*IHttpContextAccessor httpContextAccessor,*/
           IUserManager userManager
           /*IUserService service*/)
        {
            //_logger = logger;
           // dbContext = _dbContext;
           // _userservice = userService;
           // _httpContextAccessor = httpContextAccessor;
            // account = _account;
            //_service = service;
            _userManager = userManager;

        }

        public IActionResult Index()
        {
            
           // var userid = _userservice.GetUserId();
                return View();
           
        }
        

        public IActionResult Privacy()
        {
            return View();
        }

        public  IActionResult Login(UserRequest userRequest)
        {
           // _userManager.SignIn(this.HttpContext, userRequest);
            //return RedirectToAction(null, "Index", null);

            return View("Login");
            
        }

        public IActionResult Logout()
        {
             
            return RedirectToAction("Logout", "Account");


            //return Re("Login");

        }




        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        
        }
}