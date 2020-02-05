using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoShop_Shared.Models;
using AutoShop_Shared.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AutoShop_Web.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserService _userService;
       

        public UserController(IUserService u, IBadgeService b)
        {
            _userService = u;
            
        }

        public IActionResult Index()
        {
            
            List<User> users = _userService.GetUsers();
            // ViewData["title"] = "Titre de la page";
            return View(users);
        }


        public ActionResult Detail(string id)
        {
            User user = _userService.GetUser(id, id);

            return View("Detail", user);
        }

        // GET: test/Edit/5
        public ActionResult Edit(string id)
        {
            User user = _userService.GetUser(id, id);

            return View(user);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(string id, IFormCollection collection)
        {
            User user = null;
            if (ModelState.IsValid)
            {
                user = _userService.GetUser(id,id);

            }
            return View(user);

        }
    }
}