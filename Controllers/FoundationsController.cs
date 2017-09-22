using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Fretboard_Theory_Course.Data;
using Fretboard_Theory_Course.Models;

namespace Fretboard_Theory_Course.Controllers
{
    public class FoundationsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public FoundationsController(ApplicationDbContext context)
        {
            _context = context;    
        }

        // GET: Foundations
        public async Task<IActionResult> Index()
        {
            return View(await _context.Foundations.Include(a => a.Images).ToListAsync());
        }

        // GET: Foundations/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var foundations = await _context.Foundations
                .Include(a => a.Images).SingleOrDefaultAsync(m => m.FoundationsId == id);
            if (foundations == null)
            {
                return NotFound();
            }

            return View(foundations);
        }

        // GET: Foundations/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Foundations/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("FoundationsId,LessonName")] Foundations foundations)
        {
            if (ModelState.IsValid)
            {
                _context.Add(foundations);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(foundations);
        }

        // GET: Foundations/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var foundations = await _context.Foundations.SingleOrDefaultAsync(m => m.FoundationsId == id);
            if (foundations == null)
            {
                return NotFound();
            }
            return View(foundations);
        }

        // POST: Foundations/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("FoundationsId,LessonName")] Foundations foundations)
        {
            if (id != foundations.FoundationsId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(foundations);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FoundationsExists(foundations.FoundationsId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Index");
            }
            return View(foundations);
        }

        // GET: Foundations/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var foundations = await _context.Foundations
                .SingleOrDefaultAsync(m => m.FoundationsId == id);
            if (foundations == null)
            {
                return NotFound();
            }

            return View(foundations);
        }

        // POST: Foundations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var foundations = await _context.Foundations.SingleOrDefaultAsync(m => m.FoundationsId == id);
            _context.Foundations.Remove(foundations);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool FoundationsExists(int id)
        {
            return _context.Foundations.Any(e => e.FoundationsId == id);
        }
    }
}
