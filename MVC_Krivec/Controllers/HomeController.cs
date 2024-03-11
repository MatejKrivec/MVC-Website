using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MVC_Krivec.Models;
using System.Diagnostics;
using System.Drawing.Drawing2D;
using System.Reflection;
using WebMatrix.WebData;

namespace MVC_Krivec.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            ViewBag.Ime = HttpContext.Session.GetString("Ime");
            return View();
        }


        MyDbContext dbContext = new MyDbContext();


        public IActionResult Details(string ime)
        {
            var bend = dbContext.Bend.FirstOrDefault(t => t.naziv == ime);

            return RedirectToAction("IzpisPoljubnegaElementa", bend);
        }

        public IActionResult IzpisPoljubnegaElementa(Bend bend)
        {
            return View(bend);
        }

        public IActionResult Details2(string ime)
        {
            var clan = dbContext.Clan.FirstOrDefault(t => t.ime == ime);

            return RedirectToAction("IzpisPoljubnegaElementa2", clan);
        }

        public IActionResult IzpisPoljubnegaElementa2(Clan clan)
        {
            return View(clan);
        }

        public IActionResult Details3(string ime)
        {
            var turneja = dbContext.Turneja.FirstOrDefault(t => t.turneja == ime);
            if (turneja == null)
            {
                return RedirectToAction(nameof(Turneje));
            }

            return View("IzpisPoljubnegaElementa4", turneja);
        }


        public IActionResult IzpisPoljubnegaElementa4(Turneje turneja)
        {
            return View(turneja);
        }

        public IActionResult Privacy()
        {
            return View();
        }
        
        ////////////////////////////////////////////////////////////////////////////////////////////////
        
        private static List<Bend> _bendi = new List<Bend>()
        {
/*
        new Bend("GNR","USA",1990),
        new Bend("RHCP", "USA", 1995),
        new Bend("JokerOut", "Slovenija", 2017)
*/
        };
        public IActionResult Bendi()
        {
            var dbContext = new MyDbContext();
            var bendi = dbContext.Bend.ToList();
            return View(bendi);
        }


        [HttpPost]
        public IActionResult DodajBend(Bend bend)
        {

            using (var db = new MyDbContext())
            {
                db.Bend.Add(bend);
                db.SaveChanges();
            }
            return RedirectToAction("Bendi");
        }


        [HttpPost]
        public IActionResult DeleteBand(string name)
        {

            //var clanToEdit = dbContext.Bend.FirstOrDefault(c => c.naziv == name);
            var bandToDelete = dbContext.Bend.FirstOrDefault(t => t.naziv == name);
            if (bandToDelete != null)
            {
                dbContext.Bend.Remove(bandToDelete);
                dbContext.SaveChanges();
            }
            return Ok();



        }

        public IActionResult EditBand(string naziv)
        {


            var bandToEdit = dbContext.Bend.FirstOrDefault(c => c.naziv == naziv);
            if (bandToEdit == null)
            {
                return RedirectToAction(nameof(Bendi));
            }

            return View(bandToEdit);


        }

        [HttpPost]
        public IActionResult SaveEditedBand(Bend editedBand, string newNaziv)
        {
            var bandToEdit = dbContext.Bend.FirstOrDefault(c => c.naziv == editedBand.naziv);
            if (bandToEdit != null)
            {
                bandToEdit.naziv = newNaziv;
                bandToEdit.drzava = editedBand.drzava;
                bandToEdit.LetoUstanovitve = editedBand.LetoUstanovitve;
                bandToEdit.TurnejaTK = editedBand.TurnejaTK;

                dbContext.SaveChanges();
            }
            return RedirectToAction(nameof(Bendi));
        }

        ////////////////////////////////////////////////////////////////////////////////////////////
        private static List<Clan> _clani = new List<Clan>()
        {
            /*
        new Clan("John","BonJovi",21),
        new Clan("Tomi","Meglič",45),
        new Clan("Bojan", "Cvetičanin", 24)
            */
        };
        public IActionResult Clani()
        {
            var dbContext = new MyDbContext();
            var clan = dbContext.Clan.ToList();
            return View(clan);
        }

        [HttpPost]
        public IActionResult DodajClana(Clan clan)
        {
            using (var db = new MyDbContext())
            {
                db.Clan.Add(clan);
                db.SaveChanges();
            }
            return RedirectToAction("Clani");
        }

        [HttpPost]
        public IActionResult DeleteClan(string name)
        {

            var clanToDelete = dbContext.Clan.FirstOrDefault(t => t.ime == name);
            if (clanToDelete != null)
            {
                dbContext.Clan.Remove(clanToDelete);
                dbContext.SaveChanges();
            }
            return Ok();

        }

        

        public IActionResult EditClan(string naziv)
        {

            var clanToEdit = dbContext.Clan.FirstOrDefault(c => c.ime == naziv);
            if (clanToEdit == null)
            {
                return RedirectToAction(nameof(Bendi));
            }

            return View(clanToEdit);



        }

        [HttpPost]
        public IActionResult SaveEditedClan(Clan editedClan, string newIme)
        {
            var clanToEdit = dbContext.Clan.FirstOrDefault(c => c.ime == editedClan.ime);
            if (clanToEdit != null)
            {
                clanToEdit.ime = newIme;
                clanToEdit.priimek = editedClan.priimek;
                clanToEdit.starost = editedClan.starost;
                clanToEdit.TurnejaTK = editedClan.TurnejaTK;

                dbContext.SaveChanges();
            }
            return RedirectToAction(nameof(Clani));
        }

        ////////////////////////////////////////////////////////////////////////////////////////////
        private static List<Turneje> _turneje = new List<Turneje>()
        {
        new Turneje("Ameriska","BonJovi" , "clani skupine BonJovi"),
        new Turneje("Evropska", "Ramstein", "Clani skupine Ramstein"),
        new Turneje("Slovenska", "Jokerout", "clani skupine JokerOut")
        };

        public IActionResult Turneje()
        {
            var dbContext = new MyDbContext();
            var turneje = dbContext.Turneja.ToList();
            return View(turneje);
        }
   
        [HttpPost]
        public IActionResult DodajTurnejo(Turneje turneje)
        {
            using (var db = new MyDbContext())
            {
                db.Turneja.Add(turneje);
                db.SaveChanges();
            }
            return RedirectToAction("Turneje");
        }

        [HttpPost]
        public IActionResult DeleteTurneja(string name)
        {

            var turnejeToDelete = dbContext.Turneja.FirstOrDefault(t => t.turneja == name);
            if (turnejeToDelete != null)
            {
                dbContext.Turneja.Remove(turnejeToDelete);
                dbContext.SaveChanges();
            }
            return Ok();


        }

        public IActionResult EditTurneja(string naziv)
        {

            var turnejaToEdit = dbContext.Turneja.FirstOrDefault(c => c.turneja == naziv);
            if (turnejaToEdit == null)
            {
                return RedirectToAction(nameof(Turneje));
            }

            return View(turnejaToEdit);


        }

        [HttpPost]
        public IActionResult SaveEditedTurneja(Turneje editedTurneja, string newTurneja)
        {
           // var clanToEdit = dbContext.Turneja.FirstOrDefault(c => c.turneja == editedTurneja.turneja);
            var turnejaToEdit = dbContext.Turneja.FirstOrDefault(c => c.turneja == editedTurneja.turneja);
            if (turnejaToEdit != null)
            {
                turnejaToEdit.turneja = newTurneja;
                turnejaToEdit.clani = editedTurneja.clani;
                turnejaToEdit.bendi = editedTurneja.bendi;

                dbContext.SaveChanges();
            }
            return RedirectToAction(nameof(Turneje));
        }



        ///////////////////////////////////////////////////////////////////////////
     

        public IActionResult Dodaj()
        {
            
           return View();
            
        }








        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

    }
}