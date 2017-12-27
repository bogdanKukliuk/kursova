using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace kursov.Context
{
    public class Login
    {
        public Login() { }
        public int ID { get; set; }
        [Required, MaxLength(length: 228)]
        public string Email { get; set; }
        [Required, MaxLength(length: 228)]
        public string Password { get; set; }
        [Required, MaxLength(length: 228)]
        public string Name { get; set; }
        [Required]
        public int Money { get; set; } 
        public ICollection<Role> Role { get; set; }
        public ICollection<Register> Register { get; set; }
    }
}
