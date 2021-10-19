using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using project.Models;

    public class FlavorsContext : DbContext
    {
        public FlavorsContext (DbContextOptions<FlavorsContext> options)
            : base(options)
        {
        }

        public DbSet<project.Models.Flavors> Flavors { get; set; }
    }
