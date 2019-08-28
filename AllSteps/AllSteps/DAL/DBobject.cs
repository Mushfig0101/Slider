using AllSteps.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AllSteps.DAL
{
    public class DBobject:DbContext
    {
        public DBobject(DbContextOptions<DBobject> options):base(options)
        {

        }
        public DbSet<Slider> Sliders { get; set; }
        public DbSet<WhatWeDo> WhatWeDos { get; set; }
        public DbSet<Service> Services{ get; set; }
        public DbSet<OurTeam> OurTeams { get; set; }
        public DbSet<Blog> Blogs { get; set; }
        public DbSet<Welcome> Welcomes { get; set; }
        public DbSet<Description> Descriptions { get; set; }
    }
}
