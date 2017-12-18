using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kursov.Context
{
    public class Bin
    {
        [ForeignKey("Login")]
        public int ID { get; set; }
        [Required,MaxLength(length:200)]
        public string NymeProdukt { get; set; }
        [Required]
        public int Price { get; set; }
        public Details details { get; set; }
        public Login Login { get; set; }
    }
}
