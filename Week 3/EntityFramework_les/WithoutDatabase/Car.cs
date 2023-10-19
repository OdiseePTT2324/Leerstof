using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WithoutDatabase
{
    public class Car
    {
        public Car() { }
        public Car(String merk, String model) {
            this.Merk = merk;
            this.Model = model;
        }


        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public String Merk { get; set; }

        [Required]
        [StringLength(50)]
        public String Model { get; set; }

        public List<User> Gebruikers { get; set; }
    }
}
