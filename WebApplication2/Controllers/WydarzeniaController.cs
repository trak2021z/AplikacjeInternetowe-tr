using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebApplication2.Data;
using WebApplication2.Models;

namespace WebApplication2.Controllers
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
            return View(await _context.Wydarzenia.ToListAsync());
        }

        // GET: Wydarzenia/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var wydarzenie = await _context.Wydarzenia
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
            return View();
        }

        // POST: Wydarzenia/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nazwa,Data_wydarzenia,Opis")] Wydarzenie wydarzenie)
        {
            if (ModelState.IsValid)
            {
                _context.Add(wydarzenie);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
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
            return View(wydarzenie);
        }

        // POST: Wydarzenia/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nazwa,Data_wydarzenia,Opis")] Wydarzenie wydarzenie)
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
