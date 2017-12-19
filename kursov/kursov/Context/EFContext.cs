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

        public DbSet<Login> Login { get; set; }
        public DbSet<Role> Role { get; set; }
        public DbSet<BrandCar> Brand { get; set; }
        public DbSet<DetailsClass> DetalClass { get; set; }
        public DbSet<Details> Detals { get; set; }
        public DbSet<Bin> Bin { get; set; }
    }
}
