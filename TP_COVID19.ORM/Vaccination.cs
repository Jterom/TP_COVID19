using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TP_COVID19.ORM
{
    class Vaccination
    {

        [Key]
        public int Id { get; set; }

        [MaxLength(50)]
        public string Vaccin { get; set; }

        [MaxLength(50)]
        public string Type { get; set; }


        [MaxLength(50)]
        public DateTime Date { get; set; }
        // "?" veut dire que la valeur nulle est acceptée

    }
}
