using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using HotelWeb.Models;
using Microsoft.AspNetCore.Authorization;

namespace HotelWeb.Controllers
{
    [Authorize]
    public class TipoQuartoController : Controller
    {
        private readonly Context _context;

        public TipoQuartoController(Context context)
        {
            _context = context;
        }

        // GET: TipoQuarto
        public async Task<IActionResult> Index()
        {
            return View(await _context.TipoQuartos.ToListAsync());
        }

        // GET: TipoQuarto/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tipoQuarto = await _context.TipoQuartos
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tipoQuarto == null)
            {
                return NotFound();
            }

            return View(tipoQuarto);
        }

        // GET: TipoQuarto/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TipoQuarto/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Nome,Descricao,Id,CriadoEm")] TipoQuarto tipoQuarto)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tipoQuarto);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tipoQuarto);
        }

        // GET: TipoQuarto/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tipoQuarto = await _context.TipoQuartos.FindAsync(id);
            if (tipoQuarto == null)
            {
                return NotFound();
            }
            return View(tipoQuarto);
        }

        // POST: TipoQuarto/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Nome,Descricao,Id,CriadoEm")] TipoQuarto tipoQuarto)
        {
            if (id != tipoQuarto.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tipoQuarto);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TipoQuartoExists(tipoQuarto.Id))
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
            return View(tipoQuarto);
        }

        // GET: TipoQuarto/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tipoQuarto = await _context.TipoQuartos
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tipoQuarto == null)
            {
                return NotFound();
            }

            return View(tipoQuarto);
        }

        // POST: TipoQuarto/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tipoQuarto = await _context.TipoQuartos.FindAsync(id);
            _context.TipoQuartos.Remove(tipoQuarto);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TipoQuartoExists(int id)
        {
            return _context.TipoQuartos.Any(e => e.Id == id);
        }
    }
}
