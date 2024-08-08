using BW_5.DataContext;
using BW_5.Models;
using BW_5.Models.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BW_5.Controllers
{
    public class ProdottiController : Controller
    {
        private readonly ClinicaDbContext _context;

        public ProdottiController(ClinicaDbContext context)
        {
            _context = context;
        }

        // GET: Prodotti
        public async Task<IActionResult> Index()
        {
            var prodotti = await _context.Prodotti
                .Include(p => p.Ditta)
                .Include(p => p.Armadio)
                .Include(p => p.Cassetto)
                .ToListAsync();

            var viewModelList = prodotti.Select(p => new ProdottoVM
            {
                Prodotto = p,
                Ditte = _context.Ditte.ToList(),
                Cassetti = _context.Cassetti.ToList(),
                Armadi = _context.Armadi.ToList()
            }).ToList();

            return View(viewModelList);
        }

        // GET: Prodotti/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var prodotto = await _context.Prodotti
                .Include(p => p.Ditta)
                .Include(p => p.Armadio)
                .Include(p => p.Cassetto)
                .FirstOrDefaultAsync(m => m.Id == id);

            if (prodotto == null)
            {
                return NotFound();
            }

            var viewModel = new ProdottoVM
            {
                Prodotto = prodotto,
                Ditte = await _context.Ditte.ToListAsync(),
                Cassetti = await _context.Cassetti.ToListAsync(),
                Armadi = await _context.Armadi.ToListAsync()
            };

            return View(viewModel);
        }

        // GET: Prodotti/Create
        public IActionResult Create()
        {
            var viewModel = new ProdottoVM
            {
                Ditte = _context.Ditte.ToList(),
                Cassetti = _context.Cassetti.ToList(),
                Armadi = _context.Armadi.ToList()
            };
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ProdottoVM viewModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(viewModel.Prodotto);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            viewModel.Ditte = await _context.Ditte.ToListAsync();
            viewModel.Cassetti = await _context.Cassetti.ToListAsync();
            viewModel.Armadi = await _context.Armadi.ToListAsync();
            return View(viewModel);
        }

        // GET: Prodotti/Edit/5
        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var prodotto = await _context.Prodotti
                .Include(p => p.Ditta)
                .Include(p => p.Armadio)
                .Include(p => p.Cassetto)
                .FirstOrDefaultAsync(p => p.Id == id);
            if (prodotto == null)
            {
                return NotFound();
            }

            var viewModel = new ProdottoVM
            {
                Prodotto = prodotto,
                Ditte = await _context.Ditte.ToListAsync(),
                Cassetti = await _context.Cassetti.ToListAsync(),
                Armadi = await _context.Armadi.ToListAsync()
            };

            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, ProdottoVM viewModel)
        {
            if (id != viewModel.Prodotto.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(viewModel.Prodotto);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProdottoExists(viewModel.Prodotto.Id))
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

            viewModel.Ditte = await _context.Ditte.ToListAsync();
            viewModel.Cassetti = await _context.Cassetti.ToListAsync();
            viewModel.Armadi = await _context.Armadi.ToListAsync();
            return View(viewModel);
        }

        // GET: Prodotti/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var prodotto = await _context.Prodotti
                .Include(p => p.Ditta)
                .Include(p => p.Cassetto)
                .Include(p => p.Armadio)
                .FirstOrDefaultAsync(p => p.Id == id);

            if (prodotto == null)
            {
                return NotFound();
            }

            var viewModel = new ProdottoVM
            {
                Prodotto = prodotto,
                Ditte = await _context.Ditte.ToListAsync(),
                Cassetti = await _context.Cassetti.ToListAsync(),
                Armadi = await _context.Armadi.ToListAsync()
            };

            return View(viewModel);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var prodotto = await _context.Prodotti.FindAsync(id);
            _context.Prodotti.Remove(prodotto);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProdottoExists(int id)
        {
            return _context.Prodotti.Any(e => e.Id == id);
        }
    }
}
