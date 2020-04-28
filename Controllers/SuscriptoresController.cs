using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using FAIS_PROTOTIPO_.Data;
using FAIS_PROTOTIPO_.Models;

namespace FAIS_PROTOTIPO_.Controllers
{
    public class SuscriptoresController : Controller
    {
        private readonly FaisContext _context;

        public SuscriptoresController(FaisContext context)
        {
            _context = context;
        }

        // GET: Suscriptores
        public async Task<IActionResult> Index()
        {
            return View(await _context.Suscriptor.ToListAsync());
        }

        // GET: Suscriptores/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var suscriptor = await _context.Suscriptor
                .FirstOrDefaultAsync(m => m.Id == id);
            if (suscriptor == null)
            {
                return NotFound();
            }

            return View(suscriptor);
        }

        // GET: Suscriptores/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Suscriptores/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Email")] Suscriptor suscriptor)
        {
            if (ModelState.IsValid)
            {
                _context.Add(suscriptor);
                await _context.SaveChangesAsync();
                //return RedirectToAction(nameof(Index));
                return RedirectToAction("Index", "Home");
            }
            return View(suscriptor);
        }

        // GET: Suscriptores/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var suscriptor = await _context.Suscriptor.FindAsync(id);
            if (suscriptor == null)
            {
                return NotFound();
            }
            return View(suscriptor);
        }

        // POST: Suscriptores/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Email")] Suscriptor suscriptor)
        {
            if (id != suscriptor.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(suscriptor);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SuscriptorExists(suscriptor.Id))
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
            return View(suscriptor);
        }

        // GET: Suscriptores/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var suscriptor = await _context.Suscriptor
                .FirstOrDefaultAsync(m => m.Id == id);
            if (suscriptor == null)
            {
                return NotFound();
            }

            return View(suscriptor);
        }

        // POST: Suscriptores/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var suscriptor = await _context.Suscriptor.FindAsync(id);
            _context.Suscriptor.Remove(suscriptor);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SuscriptorExists(int id)
        {
            return _context.Suscriptor.Any(e => e.Id == id);
        }
    }
}
