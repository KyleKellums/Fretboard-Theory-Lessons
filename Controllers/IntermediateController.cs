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
    public class IntermediateController : Controller
    {
        private readonly ApplicationDbContext _context;

        public IntermediateController(ApplicationDbContext context)
        {
            _context = context;    
        }

        // GET: Intermediate
        public async Task<IActionResult> Index()
        {
            return View(await _context.Intermediate.Include(a => a.Images).ToListAsync());
        }

        // GET: Intermediate/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var intermediate = await _context.Intermediate.Include(a => a.Images)
                .SingleOrDefaultAsync(m => m.IntermediateId == id);
            if (intermediate == null)
            {
                return NotFound();
            }

            return View(intermediate);
        }

        // GET: Intermediate/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Intermediate/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IntermediateId,LessonName")] Intermediate intermediate)
        {
            if (ModelState.IsValid)
            {
                _context.Add(intermediate);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(intermediate);
        }

        // GET: Intermediate/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var intermediate = await _context.Intermediate.SingleOrDefaultAsync(m => m.IntermediateId == id);
            if (intermediate == null)
            {
                return NotFound();
            }
            return View(intermediate);
        }

        // POST: Intermediate/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IntermediateId,LessonName")] Intermediate intermediate)
        {
            if (id != intermediate.IntermediateId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(intermediate);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!IntermediateExists(intermediate.IntermediateId))
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
            return View(intermediate);
        }

        // GET: Intermediate/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var intermediate = await _context.Intermediate
                .SingleOrDefaultAsync(m => m.IntermediateId == id);
            if (intermediate == null)
            {
                return NotFound();
            }

            return View(intermediate);
        }

        // POST: Intermediate/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var intermediate = await _context.Intermediate.SingleOrDefaultAsync(m => m.IntermediateId == id);
            _context.Intermediate.Remove(intermediate);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool IntermediateExists(int id)
        {
            return _context.Intermediate.Any(e => e.IntermediateId == id);
        }
    }
}
