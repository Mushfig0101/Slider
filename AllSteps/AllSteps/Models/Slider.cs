using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AllSteps.Models
{
    public class Slider
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Required"), StringLength(250, ErrorMessage ="Length can't be more than 250")]
        public string Title { get; set; }
        [Required(ErrorMessage = "Required"), StringLength(500, ErrorMessage = "Length can't be more than 500") ]
        public string Description { get; set; }
        [Required (ErrorMessage = "Required"), StringLength(255, ErrorMessage = "Length can't be more than 250")]
        public string Image { get; set; }
        [NotMapped]
        [Required (ErrorMessage ="Required")]
        public IFormFile Photo { get; set; }
        #region IFormFile 
        //Necce ki, Jeyson formatini oxumaq ucun IConfiguration formatindan ist edirdik,
        //Indi de Http-den Frondan(Chrome, Mozilla ve s.) gelen fayllari asp-nin dasa dusmesi ve qebul etmesi ucun 
        //IformFile class-indan ist edirik. Bunun ucun using Microsoft.AspNetCore.Http; clasi using eyleyiirik.
        //Bize lazimdir ki Photo migration olmasin.Data base-de bele bir colm yaranmasin deyene [NotMapped]
        //kullanicagiz. Yeni   public IFormFile Photo { get; set; } bunu modelde olan 
        //deyisiklik kimi sayma, bu sekli frontdan goturmek demekdir. Modelde sekil tipi bize 
        //lazimdir ki, biz onu papkada yarada bilek.


        #endregion


    }
}
