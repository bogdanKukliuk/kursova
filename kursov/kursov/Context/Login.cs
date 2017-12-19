using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace kursov.Context
{
    public class Login
    {
        public Login() { }
        [Key]
        public int ID { get; set; }
        [Required, MaxLength(length: 228)]
        public string Email { get; set; }
        [Required, MaxLength(length: 228)]
        public string Password { get; set; }
        [Required]
        public int Mony { get; set; }
        public ICollection<Role> Role { get; set; }
        public Bin Bin { get; set; }
        public ICollection<BrandCar> BrandCar { get; set; }
    }
}
