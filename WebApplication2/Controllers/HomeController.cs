using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WebApplication2.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using WebApplication2.Controllers;
using masterLib;
using WebApplication2.Services;
using MastersApi.Controllers;
using Microsoft.AspNetCore.Mvc.Rendering;

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

        public ViewResult ListUSers()
        {
            var users =  _userManager.GetUsers();
            
            if (users != null)
            {
                SelectListItem  listItem = new SelectListItem();
                var items = users.Select(x => new SelectListItem { Text = x.Name });
                
                 ViewBag.users = items;
                return View("ListUSers");
            }
            else
            {
                return View("NotFound");
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