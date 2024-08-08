using BW_5.DataContext;
using BW_5.Models;
using BW_5.Models.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace BW_5.Controllers
{
    public class RicoveriController : Controller
    {
        private readonly ClinicaDbContext _context;

        public RicoveriController(ClinicaDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var ricoveri = await _context.Ricoveri
                .Include(r => r.Animale)
                .ToListAsync();
            return View(ricoveri);
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ricovero = await _context.Ricoveri
                .Include(r => r.Animale)
                .FirstOrDefaultAsync(m => m.Id == id);

            if (ricovero == null)
            {
                return NotFound();
            }

            return View(ricovero);
        }

        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.Animali = new SelectList(_context.Animali, "Id", "Nome");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Ricovero ricovero)
        {
            if (ModelState.IsValid)
            {
                _context.Add(ricovero);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewBag.Animali = new SelectList(_context.Animali, "Id", "Nome", ricovero.IdAnimale);
            return View(ricovero);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ricovero = await _context.Ricoveri.FindAsync(id);
            if (ricovero == null)
            {
                return NotFound();
            }
            ViewBag.Animali = new SelectList(_context.Animali, "Id", "Nome", ricovero.IdAnimale);
            return View(ricovero);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,DataInizio,DataFine,Foto,IdAnimale")] Ricovero ricovero)
        {
            if (id != ricovero.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(ricovero);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RicoveroExists(ricovero.Id))
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
            ViewBag.Animali = new SelectList(_context.Animali, "Id", "Nome", ricovero.IdAnimale);
            return View(ricovero);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ricovero = await _context.Ricoveri
                .Include(r => r.Animale)
                .FirstOrDefaultAsync(m => m.Id == id);

            if (ricovero == null)
            {
                return NotFound();
            }

            return View(ricovero);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var ricovero = await _context.Ricoveri.FindAsync(id);
            _context.Ricoveri.Remove(ricovero);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RicoveroExists(int id)
        {
            return _context.Ricoveri.Any(e => e.Id == id);
        }

        // Metodo per ottenere i ricoveri attivi
        public async Task<IActionResult> RicoveriAttivi()
        {
            var ricoveriAttivi = await _context.Ricoveri
                .Include(r => r.Animale)
                .Where(r => r.DataFine == null)
                .ToListAsync();

            return View(ricoveriAttivi);
        }
    }
}
