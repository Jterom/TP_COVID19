using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TP_COVID19.Web.Models
{
    public class Patient
    {
        [Key]
        public int ID { get; set; }
        public string Nom { get; set; }
        public string Prenom { get; set; }
        public bool Statut { get; set; }
        public bool? Sexe { get; set; }
        public DateTime DateNaissance { get; set; }
        public ICollection<Vaccination> Vaccinations { get; set; }
    }
}
