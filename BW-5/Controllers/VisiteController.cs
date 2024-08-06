using BW_5.ViewModels;
using BW5.DataContext;
using BW5.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BW_5.Controllers
{
    public class VisiteController : Controller
    {
        private readonly ClinicaDbContext _clinicaDbContext;
        
        public VisiteController(ClinicaDbContext clinicaDbContext)
        {
            _clinicaDbContext = clinicaDbContext;
        }

        // Form per la creazione di una vendita
        public async Task<IActionResult> CreateVendita()
        {
            var viewModel = new VenditaViewModel
            {
                Clienti = await _clinicaDbContext.Cliente.ToListAsync(),
                Prodotti = await _clinicaDbContext.Prodotti.ToListAsync(),
            };
            return View(viewModel);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateVendita(VenditaViewModel model)
        {
            if(!ModelState.IsValid)
            {
                var vendita = new Vendita
                {
                    IdCliente = model.ClienteId,
                    DataVendita = DateTime.Now,
                    ProdottoId = model.ProdottoId,
                    RicettaMedica = model.RicettaMedica,
                };
                _clinicaDbContext.Vendite.Add(vendita);
                await _clinicaDbContext.SaveChangesAsync();
                return RedirectToAction("ReportVendite");
            }

            model.Clienti=await _clinicaDbContext.Cliente.ToListAsync();
            model.Prodotti=await _clinicaDbContext.Prodotti.ToListAsync();

            return View(model);
        }

        // Report di tutte le vendite
        public async Task<IActionResult> ReportVendite()
        {
            var vendite = await _clinicaDbContext.Vendite.Include(v => v.Prodotto).ToListAsync();
            return View("ReportVendite", vendite);
        }

        // Dettagli di vendita
        public async Task<IActionResult> DettagliVendite(int? id)
        {
            if(id == null)
            {
                return NotFound();
            }

            var vendita = await _clinicaDbContext.Vendite
                .Include(v => v.Prodotto)
                .FirstOrDefaultAsync(m=>m.Id == id);
            if(vendita == null)
            {
                return NotFound();
            }

            return View(vendita);
        }

        // Elimina la vendita + Conferma eliminazione
        [HttpPost, ActionName("DeleteVendita")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteVendita(int? id)
        {

            var vendita = await _clinicaDbContext.Vendite
                .Include(v=>v.Prodotto)
                .FirstOrDefaultAsync(m=>m.Id==id);

            if(vendita == null)
            {
                return NotFound();
            }

            _clinicaDbContext.Vendite.Remove(vendita);
            await _clinicaDbContext.SaveChangesAsync();
            return RedirectToAction("ReportVendite");
        }

    }
}
 