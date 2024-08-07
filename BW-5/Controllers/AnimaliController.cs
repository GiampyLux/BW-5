using BW_5.Models;
using BW_5.ViewModels;
using BW_5.DataContext;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace BW_5.Controllers
{
    public class AnimaliController : Controller
    {
        private readonly ClinicaDbContext _context;
        public AnimaliController(ClinicaDbContext context)
        {
            _context = context; 
        }
        public async Task<IActionResult> Index()
        {
            var animali = await _context.Animali.ToListAsync();
            return View(animali);
        }
        //------------------------------------------------------
        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var proprietari = await _context.Clienti
                .Select(c => new SelectListItem
                {
                    Value = c.Id.ToString(),
                    Text = c.Nome + " " + c.Cognome
                }).ToListAsync();

            proprietari.Insert(0, new SelectListItem { Text = "Nessun proprietario", Value = "0" });

            var model = new AnimaleViewModel
            {
                Proprietari = proprietari
            };

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(AnimaleViewModel model)
        {
            if (ModelState.IsValid)
            {
                if (!model.PossiedeMicrochip)
                {
                    model.NumeroMicrochip = null;
                }

                var animale = new Animale
                {
                    DataRegistrazione = model.DataRegistrazione,
                    Nome = model.Nome,
                    Razza = model.Razza,
                    Pelo = model.Pelo,
                    Nascita = model.Nascita,
                    PossiedeMicrochip = model.PossiedeMicrochip,
                    NumeroMicrochip = model.NumeroMicrochip,
                    IdProprietario = model.IdProprietario == 0 ? null : model.IdProprietario 
                };

                _context.Animali.Add(animale);
                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }

            model.Proprietari = await _context.Clienti
                .Select(c => new SelectListItem
                {
                    Value = c.Id.ToString(),
                    Text = c.Nome + " " + c.Cognome
                }).ToListAsync();
            model.Proprietari.Insert(0, new SelectListItem { Text = "Nessun proprietario", Value = "0" });

            return View(model);
        }
        //------------------------------------------------------
        [HttpGet]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var animale = await _context.Animali
                .Include(a => a.Cliente) 
                .FirstOrDefaultAsync(m => m.Id == id);

            if (animale == null)
            {
                return NotFound();
            }

            return View(animale);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var animale = await _context.Animali.FindAsync(id);
            if (animale != null)
            {
                _context.Animali.Remove(animale);
                await _context.SaveChangesAsync();
            }

            return RedirectToAction(nameof(Index));
        }
        //------------------------------------------------------
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var animale = await _context.Animali
                .Include(a => a.Cliente)
                .Include(a => a.Visite)
                .FirstOrDefaultAsync(m => m.Id == id);

            if (animale == null)
            {
                return NotFound();
            }

            // Recupera il proprietario basato su IdProprietario
            var proprietario = await _context.Clienti.FindAsync(animale.IdProprietario);

            var model = new AnimaleViewModel
            {
                DataRegistrazione = animale.DataRegistrazione,
                Nome = animale.Nome,
                Razza = animale.Razza,
                Pelo = animale.Pelo,
                Nascita = animale.Nascita,
                PossiedeMicrochip = animale.PossiedeMicrochip,
                NumeroMicrochip = animale.NumeroMicrochip,
                IdProprietario = animale.IdProprietario ?? 0,
                Proprietario = proprietario, // Usa il proprietario recuperato
                Anamnesi = animale.Visite.OrderByDescending(v => v.DataVisita).ToList()
            };

            return View(model);
        }



    }
}

