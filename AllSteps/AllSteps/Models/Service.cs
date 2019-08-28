using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AllSteps.Models
{
    public class Service
    {
        public int Id { get; set; }
        [Required, StringLength(255)]
        public string Title { get; set; }
        [Required, StringLength(600)]
        public string Content { get; set; }
        [Required, StringLength(255)]
        public string Icon { get; set; }
    }
}
