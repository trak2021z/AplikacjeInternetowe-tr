using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AplikacjaInternetowa3.Data;
using AplikacjaInternetowa3.Models;

namespace AplikacjaInternetowa3.Controllers
{
    public class WydarzeniaController : Controller
    {
        private readonly KalendarzContext _context;

        public WydarzeniaController(KalendarzContext context)
        {
            _context = context;
        }

        // GET: Wydarzenia
        public async Task<IActionResult> Index()
        {
            var kalendarzContext = _context.Wydarzenia.Include(w => w.Kategoria);
            return View(await kalendarzContext.ToListAsync());
        }
        public async Task<IActionResult> KalendarzTygodniami()
        {
            var kalendarzContext = _context.Wydarzenia.Include(w => w.Kategoria);
            return View(await kalendarzContext.ToListAsync());
        }

        // GET: Wydarzenia/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var wydarzenie = await _context.Wydarzenia
                .Include(w => w.Kategoria)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (wydarzenie == null)
            {
                return NotFound();
            }

            return View(wydarzenie);
        }

        // GET: Wydarzenia/Create
        public IActionResult Create()
        {
            ViewData["KategoriaID"] = new SelectList(_context.Kategorie, "Id", "Nazwa");
            return View();
        }

        // POST: Wydarzenia/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nazwa,Data_wydarzenia,Opis,KategoriaID")] Wydarzenie wydarzenie)
        {
            if (ModelState.IsValid)
            {
                _context.Add(wydarzenie);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["KategoriaID"] = new SelectList(_context.Kategorie, "Id", "Nazwa", wydarzenie.KategoriaID);
            return View(wydarzenie);
        }

        // GET: Wydarzenia/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var wydarzenie = await _context.Wydarzenia.FindAsync(id);
            if (wydarzenie == null)
            {
                return NotFound();
            }
            ViewData["KategoriaID"] = new SelectList(_context.Kategorie, "Id", "Nazwa", wydarzenie.KategoriaID);
            return View(wydarzenie);
        }

        // POST: Wydarzenia/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nazwa,Data_wydarzenia,Opis,KategoriaID")] Wydarzenie wydarzenie)
        {
            if (id != wydarzenie.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(wydarzenie);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!WydarzenieExists(wydarzenie.Id))
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
            ViewData["KategoriaID"] = new SelectList(_context.Kategorie, "Id", "Nazwa", wydarzenie.KategoriaID);
            return View(wydarzenie);
        }

        // GET: Wydarzenia/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var wydarzenie = await _context.Wydarzenia
                .Include(w => w.Kategoria)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (wydarzenie == null)
            {
                return NotFound();
            }

            return View(wydarzenie);
        }

        // POST: Wydarzenia/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var wydarzenie = await _context.Wydarzenia.FindAsync(id);
            _context.Wydarzenia.Remove(wydarzenie);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool WydarzenieExists(int id)
        {
            return _context.Wydarzenia.Any(e => e.Id == id);
        }
    }
}
