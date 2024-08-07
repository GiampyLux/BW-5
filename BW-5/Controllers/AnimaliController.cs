using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BW5.DataContext;
using BW5.Models;

namespace BW5.Controllers
{
    public class AnimaliController : Controller
    {
        private readonly ClinicaDbContext _context;

        public AnimaliController(ClinicaDbContext context)
        {
            _context = context;
        }

        // GET: Animali
        public async Task<IActionResult> Index()
        {
            var animali = await _context.Animali.Include(a => a.Cliente).ToListAsync();
            return View(animali);
        }

        // GET: Animali/Details/5
        public async Task<IActionResult> Details(int? id)
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

        // GET: Animali/Create
        public IActionResult Create()
        {
            ViewBag.Clienti = new SelectList(_context.Cliente, "Id", "Nome");
            return View();
        }

        // POST: Animali/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nome,Razza,Pelo,Nascita,Microchip,IdProprietario,DataRegistrazione")] Animale animale)
        {
            if (ModelState.IsValid)
            {
                animale.DataRegistrazione = DateTime.Now; // Imposta la data di registrazione
                _context.Add(animale);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            else
            {
                // Log degli errori di validazione
                foreach (var error in ModelState.Values.SelectMany(v => v.Errors))
                {
                    Console.WriteLine(error.ErrorMessage);
                }
            }
            ViewBag.Clienti = new SelectList(_context.Cliente, "Id", "Nome", animale.IdProprietario);
            return View(animale);
        }

        // GET: Animali/Edit/5
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
            ViewBag.Clienti = new SelectList(_context.Cliente, "Id", "Nome", animale.IdProprietario);
            return View(animale);
        }

        // POST: Animali/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,DataRegistrazione,Nome,Razza,Pelo,Nascita,Microchip,IdProprietario")] Animale animale)
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
            ViewBag.Clienti = new SelectList(_context.Cliente, "Id", "Nome", animale.IdProprietario);
            return View(animale);
        }

        // GET: Animali/Delete/5
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

        // POST: Animali/Delete/5
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

        private bool AnimaleExists(int id)
        {
            return _context.Animali.Any(e => e.Id == id);
        }
    }
}
