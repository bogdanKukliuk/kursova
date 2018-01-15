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
        [Required,MaxLength(length:200)]
        public string NameDetalClass { get; set; }
        public BrendCar BrendCar { get; set; }
    }
}
