using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP_COVID19.Web.Models;

namespace TP_COVID19.ORM
{

    public class Context : Microsoft.EntityFrameworkCore.DbContext
    {
        public DbSet<Patient> Personnes { get; set; }
        public DbSet<Vaccination> Vaccinations { get; set; }
        public DbSet<Vaccin> Vaccins { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlite("Data Source=Covid.db");
        }
        
    }
}
