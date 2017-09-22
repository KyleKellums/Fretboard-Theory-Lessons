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
    public class ResourcesImagesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ResourcesImagesController(ApplicationDbContext context)
        {
            _context = context;    
        }

        // GET: ResourcesImages
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.ResourcesImages.Include(r => r.Resources);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: ResourcesImages/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var resourcesImages = await _context.ResourcesImages
                .Include(r => r.Resources)
                .SingleOrDefaultAsync(m => m.ImageId == id);
            if (resourcesImages == null)
            {
                return NotFound();
            }

            return View(resourcesImages);
        }

        // GET: ResourcesImages/Create
        public IActionResult Create()
        {
            ViewData["ResourcesId"] = new SelectList(_context.Resources, "ResourcesId", "ResourcesId");
            return View();
        }

        // POST: ResourcesImages/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ImageId,Path,ResourcesId")] ResourcesImages resourcesImages)
        {
            if (ModelState.IsValid)
            {
                _context.Add(resourcesImages);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewData["ResourcesId"] = new SelectList(_context.Resources, "ResourcesId", "ResourcesId", resourcesImages.ResourcesId);
            return View(resourcesImages);
        }

        // GET: ResourcesImages/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var resourcesImages = await _context.ResourcesImages.SingleOrDefaultAsync(m => m.ImageId == id);
            if (resourcesImages == null)
            {
                return NotFound();
            }
            ViewData["ResourcesId"] = new SelectList(_context.Resources, "ResourcesId", "ResourcesId", resourcesImages.ResourcesId);
            return View(resourcesImages);
        }

        // POST: ResourcesImages/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ImageId,Path,ResourcesId")] ResourcesImages resourcesImages)
        {
            if (id != resourcesImages.ImageId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(resourcesImages);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ResourcesImagesExists(resourcesImages.ImageId))
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
            ViewData["ResourcesId"] = new SelectList(_context.Resources, "ResourcesId", "ResourcesId", resourcesImages.ResourcesId);
            return View(resourcesImages);
        }

        // GET: ResourcesImages/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var resourcesImages = await _context.ResourcesImages
                .Include(r => r.Resources)
                .SingleOrDefaultAsync(m => m.ImageId == id);
            if (resourcesImages == null)
            {
                return NotFound();
            }

            return View(resourcesImages);
        }

        // POST: ResourcesImages/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var resourcesImages = await _context.ResourcesImages.SingleOrDefaultAsync(m => m.ImageId == id);
            _context.ResourcesImages.Remove(resourcesImages);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool ResourcesImagesExists(int id)
        {
            return _context.ResourcesImages.Any(e => e.ImageId == id);
        }
    }
}
