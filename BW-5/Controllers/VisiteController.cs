using BW_5.DataContext;
using BW_5.Models;
using BW_5.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace BW_5.Controllers
{
    public class VisiteController : Controller
    {
        private readonly ClinicaDbContext _context;
        public VisiteController(ClinicaDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> AllVisite()
        {
            var visite = await _context.Visite
                .Include(v => v.Animale)
                .Select(v => new VisitaViewModel
                {
                    Id = v.Id,
                    NomeAnimale = v.Animale.Nome,
                    DataVisita = v.DataVisita,
                    Esame = v.Esame,
                    DescrizioneCura = v.DescrizioneCura,
                }).ToListAsync();
            return View(visite);
        }
        //------------------------------------------------
        public async Task<IActionResult> AddVisita()
        {
            var animali = await _context.Animali.ToListAsync();
            ViewBag.Animali = new SelectList(animali, "Id", "Nome");

            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddVisita(VisitaViewModel model)
        {
            if (ModelState.IsValid)
            {
                var animale = await _context.Animali.FindAsync(model.AnimaleId);
                if (animale != null)
                {
                    var visita = new Visita
                    {
                        IdAnimale = animale.Id,
                        DataVisita = model.DataVisita,
                        Esame = model.Esame,
                        DescrizioneCura = model.DescrizioneCura
                    };
                    _context.Visite.Add(visita);
                    await _context.SaveChangesAsync();
                    return RedirectToAction("AllVisite");
                }
                else
                {
                    ModelState.AddModelError("", "Animale non trovato");
                }
            }
            ViewBag.Animali = new SelectList(await _context.Animali.ToListAsync(), "Id", "Nome");
            return View(model);
        }
        //------------------------------------------------
        [HttpGet]
        public async Task<IActionResult> DeleteVisita(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var visita = await _context.Visite
                .Include(v => v.Animale)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (visita == null)
            {
                return NotFound();
            }

            return View(visita);
        }

        [HttpPost, ActionName("DeleteVisita")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteVisita(int id)
        {
            var visita = await _context.Visite.FindAsync(id);
            if (visita != null)
            {
                _context.Visite.Remove(visita);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(AllVisite));
            }
            return NotFound();
        }
    }
}

