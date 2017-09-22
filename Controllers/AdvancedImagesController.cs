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
    public class AdvancedImagesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AdvancedImagesController(ApplicationDbContext context)
        {
            _context = context;    
        }

        // GET: AdvancedImages
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.AdvancedImages.Include(a => a.Advanced);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: AdvancedImages/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var advancedImages = await _context.AdvancedImages
                .Include(a => a.Advanced)
                .SingleOrDefaultAsync(m => m.ImageId == id);
            if (advancedImages == null)
            {
                return NotFound();
            }

            return View(advancedImages);
        }

        // GET: AdvancedImages/Create
        public IActionResult Create()
        {
            ViewData["AdvancedId"] = new SelectList(_context.Advanced, "AdvancedId", "AdvancedId");
            return View();
        }

        // POST: AdvancedImages/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ImageId,Path,AdvancedId")] AdvancedImages advancedImages)
        {
            if (ModelState.IsValid)
            {
                _context.Add(advancedImages);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewData["AdvancedId"] = new SelectList(_context.Advanced, "AdvancedId", "AdvancedId", advancedImages.AdvancedId);
            return View(advancedImages);
        }

        // GET: AdvancedImages/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var advancedImages = await _context.AdvancedImages.SingleOrDefaultAsync(m => m.ImageId == id);
            if (advancedImages == null)
            {
                return NotFound();
            }
            ViewData["AdvancedId"] = new SelectList(_context.Advanced, "AdvancedId", "AdvancedId", advancedImages.AdvancedId);
            return View(advancedImages);
        }

        // POST: AdvancedImages/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ImageId,Path,AdvancedId")] AdvancedImages advancedImages)
        {
            if (id != advancedImages.ImageId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(advancedImages);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AdvancedImagesExists(advancedImages.ImageId))
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
            ViewData["AdvancedId"] = new SelectList(_context.Advanced, "AdvancedId", "AdvancedId", advancedImages.AdvancedId);
            return View(advancedImages);
        }

        // GET: AdvancedImages/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var advancedImages = await _context.AdvancedImages
                .Include(a => a.Advanced)
                .SingleOrDefaultAsync(m => m.ImageId == id);
            if (advancedImages == null)
            {
                return NotFound();
            }

            return View(advancedImages);
        }

        // POST: AdvancedImages/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var advancedImages = await _context.AdvancedImages.SingleOrDefaultAsync(m => m.ImageId == id);
            _context.AdvancedImages.Remove(advancedImages);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool AdvancedImagesExists(int id)
        {
            return _context.AdvancedImages.Any(e => e.ImageId == id);
        }
    }
}
