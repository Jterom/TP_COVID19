using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TP_COVID19.ORM
{
    public class Personne
    {

        [Key]
        public int Id { get; set; }

        [MaxLength(20)]
        public string Nom { get; set; }

        [MaxLength(20)]
        public string Prenom { get; set; }
        // "?" veut dire que la valeur nulle est acceptée
        public bool? Sexe { get; set; }

        public bool Statut { get; set; }

        public DateTime DateNaissance { get; set; }

    }
}
