using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AllSteps.DAL;
using AllSteps.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace AllSteps.Controllers
{
    public class HomeController : Controller
    {
        private DBobject _db;
        public HomeController(DBobject dBobject)
        {
            _db = dBobject;
        }
        public IActionResult Index()
        {
            Enumarables enumerables = new Enumarables
            {
                Sliders=_db.Sliders,
                WhatWeDos = _db.WhatWeDos,
                Service = _db.Services,
                OurTeam=_db.OurTeams,
                Blog = _db.Blogs,
                Welcome =_db.Welcomes,  
                Description =_db.Descriptions
            };

            return View(enumerables);
        }
    }
}