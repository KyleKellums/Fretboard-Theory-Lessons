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
    public class IntermediateImagesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public IntermediateImagesController(ApplicationDbContext context)
        {
            _context = context;    
        }

        // GET: IntermediateImages
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.IntermediateImages.Include(i => i.Intermediate);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: IntermediateImages/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var intermediateImages = await _context.IntermediateImages
                .Include(i => i.Intermediate)
                .SingleOrDefaultAsync(m => m.ImageId == id);
            if (intermediateImages == null)
            {
                return NotFound();
            }

            return View(intermediateImages);
        }

        // GET: IntermediateImages/Create
        public IActionResult Create()
        {
            ViewData["IntermediateId"] = new SelectList(_context.Intermediate, "IntermediateId", "IntermediateId");
            return View();
        }

        // POST: IntermediateImages/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ImageId,Path,IntermediateId")] IntermediateImages intermediateImages)
        {
            if (ModelState.IsValid)
            {
                _context.Add(intermediateImages);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewData["IntermediateId"] = new SelectList(_context.Intermediate, "IntermediateId", "IntermediateId", intermediateImages.IntermediateId);
            return View(intermediateImages);
        }

        // GET: IntermediateImages/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var intermediateImages = await _context.IntermediateImages.SingleOrDefaultAsync(m => m.ImageId == id);
            if (intermediateImages == null)
            {
                return NotFound();
            }
            ViewData["IntermediateId"] = new SelectList(_context.Intermediate, "IntermediateId", "IntermediateId", intermediateImages.IntermediateId);
            return View(intermediateImages);
        }

        // POST: IntermediateImages/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ImageId,Path,IntermediateId")] IntermediateImages intermediateImages)
        {
            if (id != intermediateImages.ImageId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(intermediateImages);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!IntermediateImagesExists(intermediateImages.ImageId))
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
            ViewData["IntermediateId"] = new SelectList(_context.Intermediate, "IntermediateId", "IntermediateId", intermediateImages.IntermediateId);
            return View(intermediateImages);
        }

        // GET: IntermediateImages/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var intermediateImages = await _context.IntermediateImages
                .Include(i => i.Intermediate)
                .SingleOrDefaultAsync(m => m.ImageId == id);
            if (intermediateImages == null)
            {
                return NotFound();
            }

            return View(intermediateImages);
        }

        // POST: IntermediateImages/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var intermediateImages = await _context.IntermediateImages.SingleOrDefaultAsync(m => m.ImageId == id);
            _context.IntermediateImages.Remove(intermediateImages);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool IntermediateImagesExists(int id)
        {
            return _context.IntermediateImages.Any(e => e.ImageId == id);
        }
    }
}
