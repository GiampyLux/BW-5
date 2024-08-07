using clinica.DataContext;
using clinica.Models;
using clinica.Models.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace clinica.Controllers
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
            ViewData["Clienti"] = new SelectList(_context.Clienti, "Id", "Nome", vendita.IdCliente);
            ViewData["Prodotti"] = new SelectList(_context.Prodotti, "Id", "Nome", vendita.IdProdotto);
            return View(vendita);
        }

        public IActionResult SearchByCodiceFiscale()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> SearchByCodiceFiscale(string codiceFiscale)
        {
            var cliente = await _context.Clienti
                .Include(c => c.Vendite)
                .ThenInclude(v => v.Prodotto)
                .FirstOrDefaultAsync(c => c.CodiceFiscale == codiceFiscale);

            if (cliente == null)
            {
                return NotFound();
            }

            var prodotti = await _context.Prodotti.ToListAsync();
            var viewModel = new VenditeClienteViewModel
            {
                Vendite = cliente.Vendite.ToList(),
                Prodotti = prodotti
            };

            return View("VenditeCliente", viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AggiungiAlCarrello(AggiungiAlCarrelloViewModel model)
        {
            if (ModelState.IsValid)
            {
                var vendita = new Vendita
                {
                    IdCliente = model.ClienteId,
                    IdProdotto = model.ProdottoId, 
                    NumeroRicetta = model.NumeroRicetta
                };

                try
                {
                    _context.Vendite.Add(vendita);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateException ex)
                {
                    // Aggiungi gestione degli errori specifici qui, se necessario
                    ModelState.AddModelError("", "Errore durante il salvataggio della vendita: " + ex.Message);
                    return View("Error"); // Assicurati di avere una vista di errore appropriata
                }

                return RedirectToAction(nameof(AggiungiAlCarrello), new { clienteId = model.ClienteId });
            }

            // In caso di errore, ripresenta la vista con il modello
            model.Prodotti = _context.Prodotti.ToList();
            model.Vendite = _context.Vendite
                .Where(v => v.IdCliente == model.ClienteId)
                .Include(v => v.Prodotto)
                .ToList();
            return View(model);
        }
    }
}