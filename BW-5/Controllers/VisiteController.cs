using BW_5.DataContext;
using BW_5.Models;
using BW_5.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace BW_5.Controllers
{
    public class VisiteController : Controller
    {
        private readonly ClinicaDbContext _context;

        public VisiteController(ClinicaDbContext context)
        {
            _context = context;
        }

        // GET: Visite
        public async Task<IActionResult> Index()
        {
            var visite = await _context.Visite
                .Include(v => v.Animale)
                .ToListAsync();
            return View(visite);
        }

        // GET: Visite/Details/5
        public async Task<IActionResult> Details(int? id)
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

        // GET: Visite/Create
        public IActionResult Create()
        {
            ViewData["AnimaleId"] = new SelectList(_context.Animali, "Id", "Nome");
            return View();
        }

        // POST: Visite/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,DataVisita,Esame,DescrizioneCura,AnimaleId")] Visita visita)
        {
            if (ModelState.IsValid)
            {
                _context.Add(visita);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["AnimaleId"] = new SelectList(_context.Animali, "Id", "Nome", visita.IdAnimale);
            return View(visita);
        }

        // GET: Visite/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var visita = await _context.Visite.FindAsync(id);
            if (visita == null)
            {
                return NotFound();
            }
            ViewData["AnimaleId"] = new SelectList(_context.Animali, "Id", "Nome", visita.IdAnimale);
            return View(visita);
        }

        // POST: Visite/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,DataVisita,Esame,DescrizioneCura,AnimaleId")] Visita visita)
        {
            if (id != visita.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(visita);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VisitaExists(visita.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["AnimaleId"] = new SelectList(_context.Animali, "Id", "Nome", visita.IdAnimale);
            return View(visita);
        }

        // GET: Visite/Delete/5
        public async Task<IActionResult> Delete(int? id)
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

        // POST: Visite/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var visita = await _context.Visite.FindAsync(id);
            _context.Visite.Remove(visita);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        // GET: Visite/Anamnesi/5
        public async Task<IActionResult> Anamnesi(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var visite = await _context.Visite
                .Include(v => v.Animale)
                .Where(v => v.IdAnimale == id)
                .OrderByDescending(v => v.DataVisita)
                .ToListAsync();

            if (visite == null || !visite.Any())
            {
                return NotFound();
            }

            return View(visite);
        }

        private bool VisitaExists(int id)
        {
            return _context.Visite.Any(e => e.Id == id);
        }
    }
}