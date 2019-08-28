using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AllSteps.Models
{
    public class Blog
    {
        public int Id { get; set; }
        [Required, StringLength(250)]
        public string Image { get; set; }
        [Required, StringLength(250)]
        public string LifeStyle { get; set; }
        [Required, StringLength(250)]
        public string Title { get; set; }
        [Required, StringLength(600)]
        public string Description { get; set; }
    }
}
