using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AllSteps.DAL;
using AllSteps.Models;
using Microsoft.AspNetCore.Mvc;

namespace AllSteps.Areas.PoloAdmin.Controllers
{
    [Area("PoloAdmin")]
    public class WhatWeDoController : Controller
    {

        private DBobject _dbPolo;

        public WhatWeDoController(DBobject dBobject)
        {
            _dbPolo = dBobject;
        }


        public IActionResult Index()
        {
            return View(_dbPolo.WhatWeDos);
        }

        public async Task<IActionResult> Detail(int? id)
        {
            if (id == null) return NotFound();
            WhatWeDo skill = await _dbPolo.WhatWeDos.FindAsync(id);
            if (skill == null) return NotFound();
            return View(skill);
        }
         
        public IActionResult Create()
        {
            return View();
        }
        #region Form Sorgu
        //formdan geldiyi ucun formun da 2 methodu oldan post ve get 
        //Post vas-le qebul et-miz ucun [HttpPost] yaziriq

        //Formdan gelen bir model kimi qebul elesek 
        //Modelin Requiored-inde Sorgiunu ypoxlaya bilerik
        //Bun ModelBaining deyilir.

        //[HttpPost]
        // public IActionResult Create(string title, string description)
        // {
        //     return Content($"title{title} description {description}");
        // }
        #endregion

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(WhatWeDo skill)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            await _dbPolo.WhatWeDos.AddAsync(skill);
            await _dbPolo.SaveChangesAsync();
            //return Content($"title {skill.Title}description {skill.Description}");
            return RedirectToAction(nameof(Index));
            //Bu yazilisda ModelBainting-de View mutleq model isteyir.
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();
            WhatWeDo skill = await _dbPolo.WhatWeDos.FindAsync(id);
            if (skill == null) return NotFound();
            return View(skill);
        }


        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeletePost(int? id)
        {
            WhatWeDo skill = await _dbPolo.WhatWeDos.FindAsync(id);
            _dbPolo.WhatWeDos.Remove(skill);
            await _dbPolo.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Update(int? id)
        {
            if (id == null) return NotFound();
            WhatWeDo skill = await _dbPolo.WhatWeDos.FindAsync(id);
            if (skill == null) return NotFound();
            return View(skill);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(int? id, WhatWeDo skill)
        {
           
           // WhatWeDo dbskill = await _dbPolo.WhatWeDos.FindAsync(id);
            if (!ModelState.IsValid)
            {
                return View();
            }

            //dbskill.Title = skill.Title;
            //dbskill.Description = skill.Description;
            //await _dbPolo.SaveChangesAsync();
            _dbPolo.Entry(skill).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            await _dbPolo.SaveChangesAsync();
             return RedirectToAction(nameof(Index));
        }
    }
}