using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Labb3ApiWeb.Data;
using Labb3ApiWeb.Models;

namespace Labb3ApiWeb.Controllers
{
    public class InterestsController : Controller
    {
        private readonly Labb3ApiContext _context;

        public InterestsController(Labb3ApiContext context)
        {
            _context = context;
        }

        // GET: Interests
        public async Task<IActionResult> Index()
        {
            var labb3ApiContext = _context.Interests.Include(i => i.Persons);
            return View(await labb3ApiContext.ToListAsync());
        }

        // GET: Interests/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Interests == null)
            {
                return NotFound();
            }

            var interest = await _context.Interests
                .Include(i => i.Persons)
                .FirstOrDefaultAsync(m => m.InterestId == id);
            if (interest == null)
            {
                return NotFound();
            }

            return View(interest);
        }

        // GET: Interests/Create
        public IActionResult Create()
        {
            ViewData["FK_PersonId"] = new SelectList(_context.Persons, "PersonId", "FirstName");
            return View();
        }

        // POST: Interests/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("InterestId,InterestTitle,InterestDescription,Created,FK_PersonId")] Interest interest)
        {
            if (ModelState.IsValid)
            {
                _context.Add(interest);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["FK_PersonId"] = new SelectList(_context.Persons, "PersonId", "FirstName", interest.FK_PersonId);
            return View(interest);
        }

        // GET: Interests/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Interests == null)
            {
                return NotFound();
            }

            var interest = await _context.Interests.FindAsync(id);
            if (interest == null)
            {
                return NotFound();
            }
            ViewData["FK_PersonId"] = new SelectList(_context.Persons, "PersonId", "FirstName", interest.FK_PersonId);
            return View(interest);
        }

        // POST: Interests/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("InterestId,InterestTitle,InterestDescription,Created,FK_PersonId")] Interest interest)
        {
            if (id != interest.InterestId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(interest);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!InterestExists(interest.InterestId))
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
            ViewData["FK_PersonId"] = new SelectList(_context.Persons, "PersonId", "FirstName", interest.FK_PersonId);
            return View(interest);
        }

        // GET: Interests/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Interests == null)
            {
                return NotFound();
            }

            var interest = await _context.Interests
                .Include(i => i.Persons)
                .FirstOrDefaultAsync(m => m.InterestId == id);
            if (interest == null)
            {
                return NotFound();
            }

            return View(interest);
        }

        // POST: Interests/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Interests == null)
            {
                return Problem("Entity set 'Labb3ApiContext.Interests'  is null.");
            }
            var interest = await _context.Interests.FindAsync(id);
            if (interest != null)
            {
                _context.Interests.Remove(interest);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool InterestExists(int id)
        {
          return (_context.Interests?.Any(e => e.InterestId == id)).GetValueOrDefault();
        }
    }
}
