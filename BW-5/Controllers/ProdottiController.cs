using BW_5.DataContext;
using BW_5.Models;
using BW5.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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
                .Include(p => p.armadio)
                .ToListAsync();
            return View(prodotti);
        }

        // GET: Prodotti/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var prodotto = await _context.Prodotti
                .FirstOrDefaultAsync(m => m.Id == id);

            if (prodotto == null)
            {
                return NotFound();
            }

            return View(prodotto);
        }

        // GET: Prodotti/Create
        public async Task<IActionResult> Create()
        {
            ViewBag.Ditte = await _context.Ditte.ToListAsync();
            ViewBag.Cassetti = await _context.Cassetti.ToListAsync();
            ViewBag.Armadi = await _context.Armadi.ToListAsync();
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Nome,Tipo,IdDitta,Magazzino.Armadio,Magazzino.Cassetto,Utilizzo")] ProdottoVM prodotto)
        {

            var product = new Prodotto
            {
                Nome = prodotto.Nome,
                Tipo = prodotto.Tipo,
                IdDitta = prodotto.IdDitta,
                Utilizzo = prodotto.Utilizzo,
                ArmadioId = prodotto.ArmadioId,
                CassettoId = prodotto.CassettoId
            };
            _context.Prodotti.Add(product);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var prodotto = await _context.Prodotti
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

        private bool ProdottoExists(int id)
        {
            return _context.Prodotti.Any(e => e.Id == id);
        }



        // GET: Prodotti/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            var prodotto = await _context.Prodotti
                .Include(p => p.Ditta)
                .Include(p => p.Cassetto)
                .Include(p => p.armadio)
                .FirstOrDefaultAsync(p => p.Id == id);

            if (prodotto == null)
            {
                return NotFound();
            }

            var viewModel = new ProdottoVM
            {
                Nome = prodotto.Nome,
                Tipo = prodotto.Tipo,
                IdDitta = prodotto.IdDitta,
                ArmadioId = prodotto.ArmadioId,
                CassettoId = prodotto.CassettoId,
                Utilizzo = prodotto.Utilizzo
            };

            return View(viewModel);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var prodotto = await _context.Prodotti.FindAsync(id);
            if (prodotto != null)
            {
                _context.Prodotti.Remove(prodotto);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Index));
        }
    }
}