﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WithoutDatabase
{
    class User
    {
        public User()
        {
            Cars = new List<Car>();
        }

        //necessary since both are required
        public User(string voornaam, string achternaam)
        {
            FirstName = voornaam;
            LastName = achternaam;
            Cars = new List<Car>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [Column("Voornaam")]
        [StringLength(200)]
        public string FirstName { get; set; }

        [Required]
        [Column("Achternaam")]
        [StringLength(200)]
        //[NotMapped] -- wordt niet opgeslaan
        public String LastName { get; set; }

        public List<Car> Cars { get; set; }

    }
}
