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
    public class AdvancedController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AdvancedController(ApplicationDbContext context)
        {
            _context = context;    
        }

        // GET: Advanced
        public async Task<IActionResult> Index()
        {
            var lessons = await _context.Advanced.Include(a => a.Images).ToListAsync();

            return View(lessons);
        }

        // GET: Advanced/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var advanced = await _context.Advanced.Include(a => a.Images)
                .SingleOrDefaultAsync(m => m.AdvancedId == id);
            if (advanced == null)
            {
                return NotFound();
            }

            return View(advanced);
        }

        // GET: Advanced/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Advanced/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("AdvancedId,LessonName")] Advanced advanced)
        {
            if (ModelState.IsValid)
            {
                _context.Add(advanced);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(advanced);
        }

        // GET: Advanced/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var advanced = await _context.Advanced.SingleOrDefaultAsync(m => m.AdvancedId == id);
            if (advanced == null)
            {
                return NotFound();
            }
            return View(advanced);
        }

        // POST: Advanced/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("AdvancedId,LessonName")] Advanced advanced)
        {
            if (id != advanced.AdvancedId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(advanced);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AdvancedExists(advanced.AdvancedId))
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
            return View(advanced);
        }

        // GET: Advanced/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var advanced = await _context.Advanced
                .SingleOrDefaultAsync(m => m.AdvancedId == id);
            if (advanced == null)
            {
                return NotFound();
            }

            return View(advanced);
        }

        // POST: Advanced/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var advanced = await _context.Advanced.SingleOrDefaultAsync(m => m.AdvancedId == id);
            _context.Advanced.Remove(advanced);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool AdvancedExists(int id)
        {
            return _context.Advanced.Any(e => e.AdvancedId == id);
        }
    }
}
