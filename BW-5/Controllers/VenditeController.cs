using BW_5.DataContext;
using BW_5.Models;
using BW_5.Models.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BW_5.Controllers
{
    public class VenditeController : Controller
    {
        private readonly ClinicaDbContext _context;

        public VenditeController(ClinicaDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var vendite = await _context.Vendite
                .Include(v => v.Cliente)
                .Include(v => v.Prodotto)
                .ToListAsync();
            return View(vendite);
        }

        public IActionResult Create()
        {
            ViewData["Clienti"] = new SelectList(_context.Clienti, "Id", "Nome");
            ViewData["Prodotti"] = new SelectList(_context.Prodotti, "Id", "Nome");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdCliente,IdProdotto,NumeroRicetta")] Vendita vendita)
        {
            if (ModelState.IsValid)
            {
                _context.Add(vendita);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Clienti"] = new SelectList(_context.Clienti, "Id", "Nome", vendita.ClienteId);
            ViewData["Prodotti"] = new SelectList(_context.Prodotti, "Id", "Nome", vendita.ProdottoId);
            return View(vendita);
        }

        public IActionResult SearchByCodiceFiscale()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AggiungiAlCarrello(AggiungiAlCarrelloViewModel model)
        {
            if (ModelState.IsValid)
            {
                var vendita = new Vendita
                {
                    ClienteId = model.ClienteId,
                    ProdottoId = model.ProdottoId,
                    NumeroRicetta = model.NumeroRicetta
                };

                try
                {
                    _context.Vendite.Add(vendita);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateException ex)
                {
                    // Log dell'errore e gestione dell'errore
                    return StatusCode(500, "Errore durante il salvataggio della vendita: " + ex.Message);
                }

                var vendite = await _context.Vendite
                    .Where(v => v.ClienteId == model.ClienteId)
                    .Include(v => v.Prodotto)
                    .ToListAsync();

                return PartialView("_VenditeEsistentiPartial", vendite);
            }

            return StatusCode(400, "Dati del modello non validi");
        }


    }
}
