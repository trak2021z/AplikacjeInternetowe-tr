using AplikacjaInternetowa3.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AplikacjaInternetowa3.Data
{
    public class KalendarzContext : DbContext
    {
        public KalendarzContext(DbContextOptions<KalendarzContext> options) : base(options)
        {
            this.ChangeTracker.LazyLoadingEnabled = false;        
        }
        public DbSet<Wydarzenie> Wydarzenia { get; set; }
        public DbSet<Kategoria> Kategorie { get; set; }
       
    }
}
