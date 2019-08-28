using AllSteps.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AllSteps.ViewModels
{
    public class Enumarables
    {
        public IEnumerable<Slider> Sliders { get; set; }
        public IEnumerable<WhatWeDo> WhatWeDos { get; set; }
        public IEnumerable<Service> Service { get; set; }
        public IEnumerable<OurTeam> OurTeam  { get; set; }
        public IEnumerable<Blog> Blog { get; set; }
        public IEnumerable<Welcome> Welcome { get; set; }
        public IEnumerable<Description> Description { get; set; }
    }
}
