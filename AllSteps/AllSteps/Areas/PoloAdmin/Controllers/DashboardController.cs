using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace AllSteps.Areas.PoloAdmin.Controllers
{
    [Area("PoloAdmin")]
    public class DashboardController : Controller
    {
     
        public IActionResult Index()
        {
            return View();
        }
    }
}