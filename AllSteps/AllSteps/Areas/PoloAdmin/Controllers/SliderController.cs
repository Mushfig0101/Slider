using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using AllSteps.DAL;
using AllSteps.Extensions;
using AllSteps.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace AllSteps.Areas.PoloAdmin.Controllers
{
    [Area("PoloAdmin")]
    public class SliderController : Controller
    {
        private IHostingEnvironment _env;//wwwroot Papkani avtomatik tapir.
        private DBobject _dbPolo;
        public SliderController(DBobject dBobject, IHostingEnvironment hostinEnviroment)
        {
            _env = hostinEnviroment;
            _dbPolo = dBobject;

        }
        public IActionResult Index() 
        {
            return View(_dbPolo.Sliders);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult>  Create(Slider slider)
        {
            //{
            //    if (!ModelState.IsValid)
            //    {
            //        return view();
            #region model baining olaa bilmez
            //formdan gelen bir model kimi qebul elesek
            //modelin requiored-inde sorgiunu ypoxlaya bilerik
            //bun modelbaining deyilir.
            //biz burda model baining ist ede bilmeyeceyik. cunki 
            //[notmapped]
            //   [required
            //   (errormessage = "required")]
            // public iformfile photo { get; set; }
            //biz demisik ki, poto migraasiya olunmayacaq.aid deyil.
            //databasya 
            #endregion

            
             if (ModelState["Title"].ValidationState == ModelValidationState.Invalid
                || ModelState["Description"].ValidationState == ModelValidationState.Invalid
                || ModelState["Photo"].ValidationState == ModelValidationState.Invalid)
            {
                //Bu yazi Photo-nun type-ni yoxlamir. Inputun type-ni yoxlamir.
                return View();
             }

            if (!slider.Photo.IsImage())//html platformada \ basa dusulmediyinden @ yaziriq
            {//eslinde \ olmalidir. sonda replace vas-le cevireceyik.
                ModelState.AddModelError("Photo","Content nmust be image");
                // Buyazi    <span asp-validation-for="Description" class="text-danger"></span> isledir.
                return View();
            }
            if (!(slider.Photo.CheckSize(2))) 
                {
                //sekil default olaraq byte olur. kbyte(1024),mbyte(1024)
                ModelState.AddModelError("Photo", "Image must be littlle than 2mb");
                return View();
            }





            string replaced_filename = await slider.Photo.CopyImage(_env.WebRootPath,"pattern");
            #region
            //string path = @"C:\Users\Code\source\repos\AllSteps\AllSteps\AllSteps\wwwroot\img";
            // string path = Path.Combine(_env.WebRootPath,"img");
            // string filename = Path.Combine("pattern", Guid.NewGuid().ToString() + slider.Photo.FileName);
            // string resultPatch = Path.Combine(path, filename);

            // //Her hansi directin(Folder) icinde nese yaratmaq ucun FileStream clasindan ist edeceyik. 
            // using (FileStream fileStream = new FileStream(resultPatch, FileMode.Create))
            // { 
            //     await slider.Photo.CopyToAsync(fileStream);//using(){} tryCathFinally-inin yerine. tryCathFinally de yaza bilerdim
            //     // _dbPolo.Sliders.SaveChangeAsyns(slider);- qarsiligi
            // }
            //string replaced_filename = filename.Replace(@"\", "/");
            #endregion

            #region -ci variant
            //string name = string.Empty;
            //if (filename.Contains(@"pattern\"))
            //{
            //    name = filename.Remove(filename.IndexOf(@"pattern\"), @"pattern\".Length);  
            //}

            ////return Content(name);
            //slider.Image = name;
            #endregion
            slider.Image = replaced_filename;
            await _dbPolo.Sliders.AddAsync(slider);
            await _dbPolo.SaveChangesAsync();

            return RedirectToAction(nameof(Index));


        
        }

        public async Task<IActionResult> Detail(int? id)
        {
            if (id == null) return NotFound();
            Slider slider = await _dbPolo.Sliders.FindAsync(id);
            if (slider == null) return NotFound();
            return View(slider);
        }



    }

}

//[HttpPost] Sadece Yaddas
//[ValidateAntiForgeryToken]
//public async Task<IActionResult> Create(Slider slider)
//{
//    //{
//    //    if (!ModelState.IsValid)
//    //    {
//    //        return view();
//    #region model baining olaa bilmez
//    //formdan gelen bir model kimi qebul elesek
//    //modelin requiored-inde sorgiunu ypoxlaya bilerik
//    //bun modelbaining deyilir.
//    //biz burda model baining ist ede bilmeyeceyik. cunki 
//    //[notmapped]
//    //   [required
//    //   (errormessage = "required")]
//    // public iformfile photo { get; set; }
//    //biz demisik ki, poto migraasiya olunmayacaq.aid deyil.
//    //databasya 
//    #endregion


//    if (ModelState["Title"].ValidationState == ModelValidationState.Invalid
//       || ModelState["Description"].ValidationState == ModelValidationState.Invalid
//       || ModelState["Photo"].ValidationState == ModelValidationState.Invalid)
//    {
//        //Bu yazi Photo-nun type-ni yoxlamir. Inputun type-ni yoxlamir.
//        return View();
//    }

//    if (!slider.Photo.ContentType.Contains(@"image/"))//html platformada \ basa dusulmediyinden @ yaziriq
//    {//eslinde \ olmalidir. sonda replace vas-le cevireceyik.
//        ModelState.AddModelError("Photo", "Content nmust be image");
//        // Buyazi    <span asp-validation-for="Description" class="text-danger"></span> isledir.
//        return View();
//    }
//    if (!(slider.Photo.Length / 1024 / 2024 < 2))
//    {
//        //sekil default olaraq byte olur. kbyte(1024),mbyte(1024)
//        ModelState.AddModelError("Photo", "Image must be littlle than 2mb");
//        return View();
//    }

//    string path = @"C:\Users\Code\source\repos\AllSteps\AllSteps\AllSteps\wwwroot\img";
//    string filename = Path.Combine("pattern", Guid.NewGuid().ToString() + slider.Photo.FileName);
//    string resultPatch = Path.Combine(path, filename);

//    //Her hansi directin(Folder) icinde nese yaratmaq ucun FileStream clasindan ist edeceyik. 
//    using (FileStream fileStream = new FileStream(resultPatch, FileMode.Create))
//    {
//        await slider.Photo.CopyToAsync(fileStream);//using(){} tryCathFinally-inin yerine. tryCathFinally de yaza bilerdim
//                                                   // _dbPolo.Sliders.SaveChangeAsyns(slider);- qarsiligi
//    }
//    //string replaced_filename = filename.Replace(@"\", "/");
//    string name = string.Empty;
//    if (filename.Contains(@"pattern\"))
//    {
//        name = filename.Remove(filename.IndexOf(@"pattern\"), @"pattern\".Length);
//    }

//    //return Content(name);
//    slider.Image = name;
//    await _dbPolo.Sliders.AddAsync(slider);
//    await _dbPolo.SaveChangesAsync();

//    return RedirectToAction(nameof(Index));



//}