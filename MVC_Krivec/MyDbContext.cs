using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;
using MVC_Krivec.Models;

namespace MVC_Krivec
{
    public class MyDbContext : DbContext
    {
        public DbSet<Uporabnik_z_Gesli> UporabnikDSR { get; set; }
        public DbSet<Bend> Bend { get; set; }
        public DbSet<Clan> Clan { get; set; }
        public DbSet<Turneje> Turneja { get; set; }

        public DbSet<Merch> Merch { get; set; }
        public DbSet<NarocanjeMercha> NarocanjeMercha { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=DSR_Baza;Trusted_Connection=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Merch>().HasData(
                new Merch { Id = 1, naziv = "Slipknot T-shirt", cena = 15 },
                new Merch { Id = 2, naziv = "ACDC Mug", cena = 10 },
                new Merch { Id = 3, naziv = "Joker Out Hoodie", cena = 20 }
            );
            modelBuilder.Entity<Uporabnik_z_Gesli>().HasData(
                new Uporabnik_z_Gesli
                {
                    Id = 1,
                    Ime = "Janez",
                    Priimek = "Novak",
                    RojstniDan = new DateTime(1990, 1, 1),
                    EMSO = "1234567890123",
                    starost = 31,
                    KrajRojstva = "Ljubljana",
                    naslov = "Slovenska cesta 1",
                    PostnaST = 1000,
                    Posta = "Ljubljana",
                    Drzava = "Slovenia",
                    Email = "janez.novak@example.com",
                    Role = "Admin",
                    Geslo = "Password1!",
                    ConfirmPassword = "Password1!"
                },
                new Uporabnik_z_Gesli
                {
                    Id = 2,
                    Ime = "Ana",
                    Priimek = "Kovač",
                    RojstniDan = new DateTime(1995, 5, 10),
                    EMSO = "9876543210987",
                    starost = 26,
                    KrajRojstva = "Maribor",
                    naslov = "Trg Leona Štuklja 1",
                    PostnaST = 2000,
                    Posta = "Maribor",
                    Drzava = "Slovenia",
                    Email = "ana.kovac@example.com",
                    Role = "Admin",
                    Geslo = "Password2!",
                    ConfirmPassword = "Password2!"
                }


            );
        }
    }
}
