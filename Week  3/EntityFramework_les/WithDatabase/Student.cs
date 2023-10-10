namespace WithDatabase
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    // Dit is elke rij in een tabel Student
    [Table("Student")]
    public partial class Student
    {
        // De contructor zonder parameters is altijd nodig!
        public Student() { }

        public Student(int id, String naam)
        {
            this.Id = id;
            this.Naam = naam;
        }

        // Dit is een kolom
        // Dit heeft te maken met dat het id een primary key is
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        // Dit is kolom 2
        [Required]      // not null
        [StringLength(50)]  //varchar(50) dus de lengte is 50 dus max lengte van de string is 50
        public string Naam { get; set; }

        // Dit is kolom 3
        // ? omdat de kolom nullable is dus mag de int ook null zijn
        public int? Score { get; set; }
    }
}
