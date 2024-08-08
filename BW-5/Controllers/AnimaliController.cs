using BW_5.DataContext;
using BW_5.Models;
using BW_5.Models.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

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
            return View(await _context.Animali.ToListAsync());
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var animale = await _context.Animali
                .FirstOrDefaultAsync(m => m.Id == id);
            if (animale == null)
            {
                return NotFound();
            }

            return View(animale);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nome,Razza,Pelo,Nascita,PossiedeMicrochip,NumeroMicrochip,ProprietarioId")] Animale animale)
        {
            if (ModelState.IsValid)
            {
                _context.Add(animale);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(animale);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var animale = await _context.Animali.FindAsync(id);
            if (animale == null)
            {
                return NotFound();
            }
            return View(animale);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nome,Razza,Pelo,Nascita,PossiedeMicrochip,NumeroMicrochip,ProprietarioId")] Animale animale)
        {
            if (id != animale.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(animale);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AnimaleExists(animale.Id))
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
            return View(animale);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var animale = await _context.Animali
                .FirstOrDefaultAsync(m => m.Id == id);
            if (animale == null)
            {
                return NotFound();
            }

            return View(animale);
        }

        [HttpPost, ActionName("Delete")]
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

        [HttpPost]
        public async Task<IActionResult> SearchByMicrochip(string microchipNumber)
        {
            var animale = await _context.Animali
                .FirstOrDefaultAsync(a => a.NumeroMicrochip == microchipNumber);
            if (animale == null)
            {
                return NotFound();
            }
            return View("Details", animale);
        }

        private bool AnimaleExists(int id)
        {
            return _context.Animali.Any(e => e.Id == id);
        }
    }
}

