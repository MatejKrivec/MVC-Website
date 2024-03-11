using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MVC_Krivec.Models;

namespace MVC_Krivec.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NarocanjeMerchaController : ControllerBase
    {
        MyDbContext _context = new MyDbContext();

        public NarocanjeMerchaController(MyDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<IActionResult> Create(NarocanjeMercha model)
        {
            if (ModelState.IsValid)
            {

                // Save the model to the database
                _context.NarocanjeMercha.Add(model);
                await _context.SaveChangesAsync();

                return RedirectToAction("Hvala");
            }
            else
            {
                return BadRequest(ModelState);
            }
        }

        

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var items = await _context.NarocanjeMercha.ToListAsync();
            return Ok(items);
        }
    }
}
