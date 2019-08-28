using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AllSteps.Models
{
    public class WhatWeDo
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "This input required for fill"), StringLength(250, ErrorMessage = "Symvol Count than 250")]
        public string Title { get; set; }
        [Required(ErrorMessage ="This input required for fill"), StringLength(800,ErrorMessage ="Symvol Count than 800")]
        public string Description { get; set; }
    }
}
