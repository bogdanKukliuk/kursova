using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kursov.Context
{
    public class EFContext : DbContext
    {
        public EFContext() : base("connect")
        { }

        public DbSet<Login> login { get; set; }
        public DbSet<Role> role { get; set; }
        public DbSet<BrandCar> brand { get; set; }
        public DbSet<DetailsClass> detalClass { get; set; }
        public DbSet<Details> detals { get; set; }
    }
}
