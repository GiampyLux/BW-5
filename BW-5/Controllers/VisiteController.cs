using BW_5.Models;
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

        // Form per la creazione di una visita
        public async Task<IActionResult> CreateVisita()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateVisita(VisitaViewModel model)
        {
            
        }


        // Report di tutte le visita
        public async Task<IActionResult> ReportVisite()
        {
            var visite = await _clinicaDbContext.Visite.Include(v => v.Animale).ToListAsync();
            return View(visite);
        }

        // Dettagli di visita
        public async Task<IActionResult> DettagliVisita(int? id)
        {
            if(id == null)
            {
                return NotFound();
            }

            var visita = await _clinicaDbContext.Visite
                .Include(v=>v.Animale)
                .FirstOrDefaultAsync(m=>m.Id == id);

            if(visita == null)
            {
                return NotFound();
            }
            return View(visita);
        }

        // Elimina la visita + Conferma eliminazione
        //[HttpPost, ActionName("DeleteVendita")]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> DeleteVisita(int? id)
        //{

        //}

    }
}
 