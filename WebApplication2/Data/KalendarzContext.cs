using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication2.Models;

namespace WebApplication2.Data
{
    public class KalendarzContext : DbContext
    {
        public KalendarzContext(DbContextOptions<KalendarzContext> options) : base(options)
        {
        }
        public DbSet<Wydarzenie> Wydarzenia { get; set; }

    }

}
