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
        private IUserManager _userManager;
        public HomeController(IUserManager userManager)
        {
            _userManager = userManager;

        }

        public IActionResult Index()
        {
                return View();
           
        }     

        public IActionResult Privacy()
        {
            return View();
        }

        public  IActionResult Login(UserRequest userRequest)
        {
            return View("Login");
            
        }
        [HttpGet]
        public async  Task<IActionResult> Logout()
        {
            await _userManager.SignOut(this.HttpContext);
           return RedirectToAction("Index", "Home");
        }

        public IActionResult Register()
        {
            return View();
        }

        public async Task<IActionResult> GetTickets()
        {
            if (await _userManager.GetTickets()==null)
            {

                return View("NotFound");
            }
            else
            {
                return View("GetTickets");
            }
        }


        //private async Task Timer()
        //{
        //    while (await timer.WaitForNextTickAsync())
        //    {

        //        Console.WriteLine("tiki tak tiki tak");
        //        if (Task.CompletedTask.IsCompletedSuccessfully)
        //        {
        //            timer.Dispose();
        //            RedirectToAction("Index","Home");
        //        }
        //    }
            
        //}

        

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        
        }
}