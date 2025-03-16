using Crud.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Crud.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly KisiContext _context;

        public HomeController(ILogger<HomeController> logger, KisiContext context)
        {
            _logger = logger;
            _context = context;
        }
        [HttpGet]
        public IActionResult Index()
        {
            ViewBag.KisiListe = _context.Kisiler.ToList();
            return View();
        }
        [HttpPost]
        public IActionResult Index(Kisiler Kisi)
        {
            _context.Add(Kisi);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));

        }
        [HttpGet]
        public IActionResult Kisi_Guncelle(int ID)
        {
            var Guncellenecek_Kisi = _context.Kisiler.Find(ID);

            return View(Guncellenecek_Kisi);
        }
        [HttpPost]
        public IActionResult Kisi_Guncelle(Kisiler Kisi)
        {
            _context.Update(Kisi);
            _context.SaveChanges();

            return RedirectToAction((nameof)Index);
        }


        public async Task<IActionResult> Kisi_Sil(int ID)
        {
            var Silinecek_Kisi = await _context.Kisiler.FindAsync(ID);
            _context.Remove(Silinecek_Kisi);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        public IActionResult Privacy()
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
