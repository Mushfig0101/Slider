﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AllSteps.Models
{
    public class Description
    {
        public int Id { get; set; }
        [Required, StringLength(200)]
        public string UpTitle { get; set; }
        [Required, StringLength(2000)] 
        public string DownTitle { get; set; }
     
    }
}
