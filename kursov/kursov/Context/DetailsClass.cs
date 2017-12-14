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
        public int IdEngine { get; set; }
        [Required]
        public int IdHull { get; set; }
        [Required]
        public int IdElectronics { get; set; }
        public BrandCar brandCar { get; set; }
    }
}
