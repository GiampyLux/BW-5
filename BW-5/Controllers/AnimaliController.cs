using BW_5.Models;
using BW_5.ViewModels;
using BW5.DataContext;
using BW5.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace BW_5.Controllers
{
    [Authorize(Policy = "MedicoOnly")]
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
            var proprietari = await _context.Cliente
                .Select(c => new SelectListItem
                {
                    Value = c.Id.ToString(),
                    Text = c.Nome + " " + c.Cognome
                }).ToListAsync();

            // Aggiunge l'opzione per nessun proprietario
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

            model.Proprietari = await _context.Cliente
                .Select(c => new SelectListItem
                {
                    Value = c.Id.ToString(),
                    Text = c.Nome + " " + c.Cognome
                }).ToListAsync();
            model.Proprietari.Insert(0, new SelectListItem { Text = "Nessun proprietario", Value = "0" });

            return View(model);
        }

    }
}
