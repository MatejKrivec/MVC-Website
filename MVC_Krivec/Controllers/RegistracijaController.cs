using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MVC_Krivec.Models;
using System;
using System.Reflection;
using WebMatrix.WebData;

namespace MVC_Krivec.Controllers
{
    public class RegistracijaController : Controller
    {
        
        public IActionResult Login()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Registracija()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Registracija(Uporabnik_z_Gesli registerModel)
        {

            if (ModelState.IsValid)
            {
                if (emso_verify(registerModel.EMSO, registerModel.RojstniDan) == false)
                {
                    ModelState.AddModelError("EMSO", "Invalid emšo");
                    return View(registerModel);
                }
                else
                {

                    using (var db = new MyDbContext())
                    {
                        db.UporabnikDSR.Add(registerModel);
                        db.SaveChanges();
                    }
                    return RedirectToAction("PodatkiRegistracije", registerModel);
                }
                
            }

            return View(registerModel);
        }

        public bool emso_verify(string emso, DateTime birthDate)
        {
            if ((emso == null) || (!emso.All(c => char.IsDigit(c))))
                return false;

            int emso_sum = 0;
            for (int i = 7; i > 1; i--)
                emso_sum += i * (int.Parse(emso.Substring(7 - i, 1)) + int.Parse(emso.Substring(13 - i, 1)));

            int control_digit = emso_sum % 11 == 0 ? 0 : 11 - (emso_sum % 11);

            if (emso.Substring(12, 1) != control_digit.ToString()) //pregled kontolne stevilke
                return false;

            int year = int.Parse(emso.Substring(4, 3));
            int month = int.Parse(emso.Substring(2, 2));
            int day = int.Parse(emso.Substring(0, 2));

            if (year >= 900)
                year -= 1000;
            else if (year >= 800)
                year -= 800;
            else if (year >= 700)
                year -= 600;
            else if (year >= 600)
                year -= 500;
            else
                year += 2000;

            DateTime emsoBirthDate = new DateTime(year, month, day);
            return emsoBirthDate == birthDate;
        }

        [HttpGet]
        public IActionResult PodatkiRegistracije(Uporabnik_z_Gesli registerModel)
        {
            return View(registerModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginModel model)
        {

            var db = new MyDbContext();
            if (ModelState.IsValid)
            {
                // Check if the user exists in the database
                var user = db.UporabnikDSR.FirstOrDefault(u => u.Email == model.Email && u.Geslo == model.Password);
                if (user != null)
                {
                    // Store the user data and role in session
                    HttpContext.Session.SetString("UserRole", user.Role);
                    HttpContext.Session.SetString("Ime", user.Ime);

                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("", "Invalid email or password.");
                }
            }

            // If we got this far, something failed, redisplay form
            return View(model);
        }



    }
}
