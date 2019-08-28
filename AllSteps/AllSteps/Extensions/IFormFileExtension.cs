using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace AllSteps.Extensions
{
    public static class IFormFileExtension
    {

        public static bool IsImage(this IFormFile formfile)
        { 
            return formfile.ContentType.Contains(@"image/");
 
        }





        public static bool CheckSize(this IFormFile formFile,int maxsize)
        {
            return formFile.Length / 1024 / 2024 < maxsize;
        }


        //public static bool CheckSize( IFormFile formFile)
        //{
        //    if (!(formFile.Length / 1024 / 2024 < 2))
        //    {
        //        return false;
        //    }
        //    return true;
        //    //Bele de yaza bilerdim.
        //    //Amma Muellim deyen kimi yazdim.
        //}

        public async static Task<string> CopyImage(this IFormFile file, string root, string folder )
        {
            string path = Path.Combine(root, "img");
            string filename = Path.Combine(folder, Guid.NewGuid().ToString() + file.FileName);
            string resultPatch = Path.Combine(path, filename);

            //Her hansi directin(Folder) icinde nese yaratmaq ucun FileStream clasindan ist edeceyik. 
            using (FileStream fileStream = new FileStream(resultPatch, FileMode.Create))
            {
                await file.CopyToAsync(fileStream);//using(){} tryCathFinally-inin yerine. tryCathFinally de yaza bilerdim
                // _dbPolo.Sliders.SaveChangeAsyns(slider);- qarsiligi
            }
            string replaced_filename = filename.Replace(@"\", "/");
            return replaced_filename;
        }
    }
    
}


