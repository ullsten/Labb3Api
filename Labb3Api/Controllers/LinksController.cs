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
    public class LinksController : Controller
    {
        private readonly Labb3ApiContext _context;

        public LinksController(Labb3ApiContext context)
        {
            _context = context;
        }

        // GET: Links
        public async Task<IActionResult> Index()
        {
            var labb3ApiContext = _context.Links.Include(l => l.Interests).Include(l => l.Persons);
            return View(await labb3ApiContext.ToListAsync());
        }

        // GET: Links/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Links == null)
            {
                return NotFound();
            }

            var link = await _context.Links
                .Include(l => l.Interests)
                .Include(l => l.Persons)
                .FirstOrDefaultAsync(m => m.LinkId == id);
            if (link == null)
            {
                return NotFound();
            }

            return View(link);
        }

        // GET: Links/Create
        public IActionResult Create()
        {
            ViewData["FK_InterestId"] = new SelectList(_context.Interests, "InterestId", "InterestDescription");
            ViewData["FK_PersonId"] = new SelectList(_context.Persons, "PersonId", "FirstName");
            return View();
        }

        // POST: Links/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("LinkId,URL,FK_InterestId,FK_PersonId")] Link link)
        {
            if (ModelState.IsValid)
            {
                _context.Add(link);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["FK_InterestId"] = new SelectList(_context.Interests, "InterestId", "InterestDescription", link.FK_InterestId);
            ViewData["FK_PersonId"] = new SelectList(_context.Persons, "PersonId", "FirstName", link.FK_PersonId);
            return View(link);
        }

        // GET: Links/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Links == null)
            {
                return NotFound();
            }

            var link = await _context.Links.FindAsync(id);
            if (link == null)
            {
                return NotFound();
            }
            ViewData["FK_InterestId"] = new SelectList(_context.Interests, "InterestId", "InterestDescription", link.FK_InterestId);
            ViewData["FK_PersonId"] = new SelectList(_context.Persons, "PersonId", "FirstName", link.FK_PersonId);
            return View(link);
        }

        // POST: Links/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("LinkId,URL,FK_InterestId,FK_PersonId")] Link link)
        {
            if (id != link.LinkId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(link);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LinkExists(link.LinkId))
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
            ViewData["FK_InterestId"] = new SelectList(_context.Interests, "InterestId", "InterestDescription", link.FK_InterestId);
            ViewData["FK_PersonId"] = new SelectList(_context.Persons, "PersonId", "FirstName", link.FK_PersonId);
            return View(link);
        }

        // GET: Links/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Links == null)
            {
                return NotFound();
            }

            var link = await _context.Links
                .Include(l => l.Interests)
                .Include(l => l.Persons)
                .FirstOrDefaultAsync(m => m.LinkId == id);
            if (link == null)
            {
                return NotFound();
            }

            return View(link);
        }

        // POST: Links/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Links == null)
            {
                return Problem("Entity set 'Labb3ApiContext.Links'  is null.");
            }
            var link = await _context.Links.FindAsync(id);
            if (link != null)
            {
                _context.Links.Remove(link);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LinkExists(int id)
        {
          return (_context.Links?.Any(e => e.LinkId == id)).GetValueOrDefault();
        }
    }
}
