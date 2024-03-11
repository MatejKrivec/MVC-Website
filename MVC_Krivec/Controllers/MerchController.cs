using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MVC_Krivec.Models;
using System.Net.Http;


namespace MVC_Krivec.Controllers
{
    public class MerchController : Controller
    {
        // GET: MerchController
       // MyDbContext dbContext = new MyDbContext();

        public ActionResult Merchendise()
        {
            var dbContext = new MyDbContext();
            var merch = dbContext.Merch.ToList();
            return View(merch);
 
        }
        public static List<Merch> shoppingCartItems = new List<Merch>();

        [HttpPost]
        public ActionResult Merchendise(Merch item)
        {

            if (shoppingCartItems.Any(i => i.naziv == item.naziv))
            {
                return RedirectToAction("Merchendise");
            }
            else
            {
                shoppingCartItems.Add(item);
            }

            return RedirectToAction("Merchendise");
        }

        [HttpPost]
        public IActionResult RemoveItemFromCart(int itemId)
        {
            // Find the item in the cart
            var item = shoppingCartItems.FirstOrDefault(i => i.Id == itemId);
            if (item == null)
            {
                return BadRequest("Item not found in cart");
            }

            // Remove the item from the cart
            shoppingCartItems.Remove(item);

            // Return to the shopping cart view
            return RedirectToAction("Merchendise");
        }




        public ActionResult Kosarica()
        {
            return View(shoppingCartItems);
        }

        public ActionResult Potrditevnakupa()
        {

            // Get the items quantities and total price from the form
            string itemsQuantities = Request.Form["items-quantities"];
            int totalPrice = 0;

            if (!string.IsNullOrEmpty(Request.Form["totalPrice"]) && int.TryParse(Request.Form["totalPrice"], out int parsedTotalPrice))
            {
                totalPrice = parsedTotalPrice;
            }

            // Add the items quantities and total price to the ViewBag
            ViewBag.ItemsQuantities = itemsQuantities;
            ViewBag.TotalPrice = totalPrice;

            NarocanjeMercha model = new NarocanjeMercha();
            model.naziv = itemsQuantities;
            model.cena = totalPrice;
            model.kraj = "Some City";
            model.posta = 1000;
            model.naslov = "Some Address";
            model.DatumInCas = DateTime.Now;
            model.TK_User = 1;

            return View(model);
        }

        [HttpPost]
        public IActionResult PotrdiNakup(NarocanjeMercha model)
        {

           
            return RedirectToAction("Hvala");
        }

        public IActionResult Hvala()
        {
            return View();
        }

       /* private readonly HttpClient _httpClient;

        public MerchController(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }*/

       /* public async Task<IActionResult> PretekliNakupi()
        {
            var response = await _httpClient.GetAsync("api/NarocanjeMercha");
            response.EnsureSuccessStatusCode();

            var items = await response.Content.ReadAsAsync<NarocanjeMercha>();

            return View(items);
        }*/

        public ActionResult PretekliNakupi()
        {
            return View();
        }




        /////////////////////////////////////////////////////////////

        // GET: MerchController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: MerchController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: MerchController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: MerchController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: MerchController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: MerchController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: MerchController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
