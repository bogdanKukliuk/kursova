using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kursov.Context
{
    public class DetailsClass
    {
        [Key]
        public int ID { get; set; }
        [Required]
        public int Name { get; set; }
        public ICollection <BrandCar> BrandCar { get; set; }
        public ICollection <Details> Details { get; set; }
    }
}
