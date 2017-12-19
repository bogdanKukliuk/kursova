using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kursov.Context
{
    public class BrandCar
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int NameBrand { get; set; }
        public ICollection<DetailsClass> DetailsClass { get; set; }
        public ICollection<Login> Login { get; set; }
    }
}
