using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kursov.Context
{
    public class Register
    {
        [Key]
        public int ID { get; set; }
        [Required,MaxLength(length:200)]
        public string Login { get; set; }
        [Required, MaxLength(length: 200)]
        public string Password { get; set; }
        [Required, MaxLength(length: 200)]
        public string Name { get; set; }
        public ICollection <User> User { get; set; }
    }
}
