using HotelWeb.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;


namespace HotelWeb.Controllers {

    [Authorize]
    public class TpoQuartoController : Controller {
        private readonly Context _context;

        public TpoQuartoController(Context context) {
            _context = context;
        }

        // GET: Categoria
        public async Task<IActionResult> Index() {
            return View(await _context.TipoQuartos.ToListAsync());
        }

        // GET: Categoria/Details/5
        public async Task<IActionResult> Details(int? id) {
            if (id == null) {
                return NotFound();
            }

            var tipoQuarto = await _context.TipoQuartos
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tipoQuarto == null) {
                return NotFound();
            }

            return View(tipoQuarto);
        }

        // GET: Categoria/Create
        public IActionResult Create() {
            return View();
        }

        // POST: Categoria/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Nome,Descricao,Id,CriadoEm")] TipoQuarto tipoQuarto) {
            if (ModelState.IsValid) {
                _context.Add(tipoQuarto);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tipoQuarto);
        }

        // GET: Categoria/Edit/5
        public async Task<IActionResult> Edit(int? id) {
            if (id == null) {
                return NotFound();
            }

            var tipoQuarto = await _context.TipoQuartos.FindAsync(id);
            if (tipoQuarto == null) {
                return NotFound();
            }
            return View(tipoQuarto);
        }

        // POST: Categoria/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Nome,Descricao,Id,CriadoEm")] TipoQuarto tipoQuarto) {
            if (id != tipoQuarto.Id) {
                return NotFound();
            }

            if (ModelState.IsValid) {
                try {
                    _context.Update(tipoQuarto);
                    await _context.SaveChangesAsync();
                } catch (DbUpdateConcurrencyException) {
                    if (!TipoQuartoExists(tipoQuarto.Id)) {
                        return NotFound();
                    } else {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(tipoQuarto);
        }

        // GET: Categoria/Delete/5
        public async Task<IActionResult> Delete(int? id) {
            if (id == null) {
                return NotFound();
            }

            var tipoQuarto = await _context.TipoQuartos
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tipoQuarto == null) {
                return NotFound();
            }

            return View(tipoQuarto);
        }

        // POST: tipoQuarto/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id) {
            var tipoQuarto = await _context.TipoQuartos.FindAsync(id);
            _context.TipoQuartos.Remove(tipoQuarto);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TipoQuartoExists(int id) {
            return _context.TipoQuartos.Any(e => e.Id == id);
        }
    }
}
