using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WithoutDatabase
{
    public class User
    {
        public User() { alleAutos = new List<Car>(); }
        public User(String voornaam, String achternaam)
        {
            alleAutos = new List<Car>();
            this.Firstname = voornaam;
            this.Lastname = achternaam;
        }

        [Key]        
        public int Id { get; set; }

        [Required]
        [Column("Voornaam")]
        [StringLength(50)]
        public string Firstname { get; set; }

        [NotMapped] // Dit wordt niet bewaard in de database
        public string Lastname { get; set; }

        // 1 op N relatie
        public Car favorieteAuto {  get; set; }

        // N op M relatie
        public List<Car> alleAutos { get; set; }
    }
}
