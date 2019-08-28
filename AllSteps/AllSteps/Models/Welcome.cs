using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AllSteps.Models
{
    public class Welcome
    {
        public int Id { get; set; }
        [Required, StringLength(350)]
        public string Title { get; set; }
        [Required, StringLength(300)]
        public string Info { get; set; }
        [Required, StringLength(255)]
        public string Image { get; set; }

    }
}
