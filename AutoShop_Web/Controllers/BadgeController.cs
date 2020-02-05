using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoShop_Shared.Models;
using AutoShop_Shared.Services;
using Microsoft.AspNetCore.Mvc;

namespace AutoShop_Web.Controllers
{
    public class BadgeController : Controller
    {
        private readonly IBadgeService _badgeService;
        public BadgeController(IBadgeService b)
        {
            _badgeService = b;
        }
        public IActionResult Index()
        {
            List<Badge> badges = _badgeService.GetBadges();
            return View(badges);
        }
    }
}