using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication2.Models;

namespace WebApplication2.Data
{
    public static class DbInitializer
    {
        public static void Initialize(KalendarzContext context)
        {
            context.Database.EnsureCreated();

            // Look for any students.
            if (context.Wydarzenia.Any())
            {
                return;   // DB has been seeded
            }

            var wydarzenia = new Wydarzenie[]
            {
            new Wydarzenie{Nazwa="test1",Data_wydarzenia=DateTime.Now,Opis="test"},
            new Wydarzenie{Nazwa="test2",Data_wydarzenia=DateTime.Now,Opis="test"},
            new Wydarzenie{Nazwa="test3",Data_wydarzenia=DateTime.Now,Opis="test"},
            new Wydarzenie{Nazwa="test4",Data_wydarzenia=DateTime.Now,Opis="test"},
            new Wydarzenie{Nazwa="test5",Data_wydarzenia=DateTime.Now,Opis="test"},
            new Wydarzenie{Nazwa="test6",Data_wydarzenia=DateTime.Now,Opis="test"},
            new Wydarzenie{Nazwa="test7",Data_wydarzenia=DateTime.Now,Opis="test"}          
            };
            foreach (Wydarzenie w in wydarzenia)
            {
                context.Wydarzenia.Add(w);
            }
            context.SaveChanges();

           
        }
    }
}
