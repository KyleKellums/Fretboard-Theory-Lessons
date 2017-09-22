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
    public class FoundationsImagesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public FoundationsImagesController(ApplicationDbContext context)
        {
            _context = context;    
        }

        // GET: FoundationsImages
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.FoundationsImages.Include(f => f.Foundations);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: FoundationsImages/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var foundationsImages = await _context.FoundationsImages
                .Include(f => f.Foundations)
                .SingleOrDefaultAsync(m => m.ImageId == id);
            if (foundationsImages == null)
            {
                return NotFound();
            }

            return View(foundationsImages);
        }

        // GET: FoundationsImages/Create
        public IActionResult Create()
        {
            ViewData["FoundationsId"] = new SelectList(_context.Foundations, "FoundationsId", "FoundationsId");
            return View();
        }

        // POST: FoundationsImages/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ImageId,Path,FoundationsId")] FoundationsImages foundationsImages)
        {
            if (ModelState.IsValid)
            {
                _context.Add(foundationsImages);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewData["FoundationsId"] = new SelectList(_context.Foundations, "FoundationsId", "FoundationsId", foundationsImages.FoundationsId);
            return View(foundationsImages);
        }

        // GET: FoundationsImages/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var foundationsImages = await _context.FoundationsImages.SingleOrDefaultAsync(m => m.ImageId == id);
            if (foundationsImages == null)
            {
                return NotFound();
            }
            ViewData["FoundationsId"] = new SelectList(_context.Foundations, "FoundationsId", "FoundationsId", foundationsImages.FoundationsId);
            return View(foundationsImages);
        }

        // POST: FoundationsImages/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ImageId,Path,FoundationsId")] FoundationsImages foundationsImages)
        {
            if (id != foundationsImages.ImageId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(foundationsImages);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FoundationsImagesExists(foundationsImages.ImageId))
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
            ViewData["FoundationsId"] = new SelectList(_context.Foundations, "FoundationsId", "FoundationsId", foundationsImages.FoundationsId);
            return View(foundationsImages);
        }

        // GET: FoundationsImages/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var foundationsImages = await _context.FoundationsImages
                .Include(f => f.Foundations)
                .SingleOrDefaultAsync(m => m.ImageId == id);
            if (foundationsImages == null)
            {
                return NotFound();
            }

            return View(foundationsImages);
        }

        // POST: FoundationsImages/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var foundationsImages = await _context.FoundationsImages.SingleOrDefaultAsync(m => m.ImageId == id);
            _context.FoundationsImages.Remove(foundationsImages);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool FoundationsImagesExists(int id)
        {
            return _context.FoundationsImages.Any(e => e.ImageId == id);
        }
    }
}
