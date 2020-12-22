using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TP_COVID19.ORM
{
    public class Vaccination
    {

        [Key]
        public int Id { get; set; }

        [MaxLength(20)]
        public string NomMarque { get; set; }

        [MaxLength(50)]
        public string NomMaladie { get; set; }

        public int NumeroLot { get; set; }


        public DateTime DateAdmission { get; set; }

        public DateTime DateRappel { get; set; }

    }
}
