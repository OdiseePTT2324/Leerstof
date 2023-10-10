using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WithoutDatabase
{
    class Car
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Column("Merk")]
        [StringLength(50)]
        public string Merk { get; set; }

        [Column("Model")] 
        [StringLength(50)]
        public string Model { get; set; }

        public List<User> Users { get; set; }
    }
}
