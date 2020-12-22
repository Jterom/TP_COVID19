using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP_COVID19.ORM
{
    class Context : DbContext
    {
        public DbSet<Personne> Personnes { get; set; }
        public DbSet<Vaccination> Vaccinations { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlite("Data Source=Covid.db");
        }
    }
}
