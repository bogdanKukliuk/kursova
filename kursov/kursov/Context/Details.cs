using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kursov.Context
{
    public class Details
    {
        public Details() { }
        [Key]
        public int ID { get; set; }
        [Required,MaxLength(length:200)]
        public string NameDetal { get; set; }
        [Required]
        public int Price { get; set; }
        [Required,MaxLength(length:200)]
        public string Description { get; set; }
        public ICollection <DetailsClass> DetailsClass { get; set; }
        public ICollection <Bin> Bin { get; set; }
    }
}
