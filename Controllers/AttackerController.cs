using IronDomeSim.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Primitives;
using Newtonsoft.Json;

namespace IronDomeSim.Controllers
{
    public class AttackerController : Controller
    {
        private readonly AppDbContext _context;
        public AttackerController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            //ViewBag.asJson = JsonConvert.SerializeObject(_context.Weapons.ToList());
            return View(_context.Weapons.ToList());
        }


    }
}
