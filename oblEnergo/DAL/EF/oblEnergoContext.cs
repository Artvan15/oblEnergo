using System;
using System.Collections.Generic;
using System.Text;
using DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace DAL.EF
{
    public class oblEnergoContext
        :DbContext
    {
        public DbSet<Region> Regions { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<Street> Streets { get; set; }
        public DbSet<Building> Buildings { get; set; }
        public DbSet<Appartment> Appartments { get; set; }

        public oblEnergoContext(DbContextOptions options)
            : base(options)
        {

        }
    }
}
