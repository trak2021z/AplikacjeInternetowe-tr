using AplikacjaInternetowa3.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AplikacjaInternetowa3.Data
{
    public class DbInitializer
    {
        public static void Initialize(KalendarzContext context)
        {
            context.Database.EnsureCreated();

            // Look for any students.
            if (context.Kategorie.Any())
            {
                return;   // DB has been seeded
            }

            var katgorie = new Kategoria[]
            {
            new Kategoria{Nazwa="Studia"},
            new Kategoria{Nazwa="Praca"},
            new Kategoria{Nazwa="Sport"},
            new Kategoria{Nazwa="Rozrywka"},
            new Kategoria{Nazwa="Zakupy"}           
            };
            foreach (var k in katgorie)
            {
                context.Kategorie.Add(k);
            }
            context.SaveChanges();


            var wydarzenia = new Wydarzenie[]
            {
            new Wydarzenie{Nazwa="test1",Data_wydarzenia=DateTime.Now,Opis="test",KategoriaID=1},
            new Wydarzenie{Nazwa="test2",Data_wydarzenia=DateTime.Now,Opis="test",KategoriaID=2},
            new Wydarzenie{Nazwa="test3",Data_wydarzenia=DateTime.Now,Opis="test",KategoriaID=1},
            new Wydarzenie{Nazwa="test4",Data_wydarzenia=DateTime.Now,Opis="test",KategoriaID=3},
            new Wydarzenie{Nazwa="test5",Data_wydarzenia=DateTime.Now,Opis="test",KategoriaID=1},
            new Wydarzenie{Nazwa="test6",Data_wydarzenia=DateTime.Now,Opis="test",KategoriaID=2},
            new Wydarzenie{Nazwa="test7",Data_wydarzenia=DateTime.Now,Opis="test",KategoriaID=1}
            };
            foreach (var c in wydarzenia)
            {
                context.Wydarzenia.Add(c);
            }
            context.SaveChanges();

          
        }
    }
}
