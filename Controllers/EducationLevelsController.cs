using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Meditatori.Models;
using Meditatori.ro2.Data;

namespace Meditatori.ro2.Controllers
{
    public class EducationLevelsController : Controller
    {
        private readonly SiteDbContext _context;

        public EducationLevelsController(SiteDbContext context)
        {
            _context = context;
        }

        // GET: EducationLevels
        public async Task<IActionResult> Index()
        {
            return View(await _context.EducationLevels.ToListAsync());
        }

        // GET: EducationLevels/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var educationLevel = await _context.EducationLevels
                .FirstOrDefaultAsync(m => m.Id == id);
            if (educationLevel == null)
            {
                return NotFound();
            }

            return View(educationLevel);
        }

        // GET: EducationLevels/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: EducationLevels/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,name")] EducationLevel educationLevel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(educationLevel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(educationLevel);
        }

        // GET: EducationLevels/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var educationLevel = await _context.EducationLevels.FindAsync(id);
            if (educationLevel == null)
            {
                return NotFound();
            }
            return View(educationLevel);
        }

        // POST: EducationLevels/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,name")] EducationLevel educationLevel)
        {
            if (id != educationLevel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(educationLevel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EducationLevelExists(educationLevel.Id))
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
            return View(educationLevel);
        }

        // GET: EducationLevels/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var educationLevel = await _context.EducationLevels
                .FirstOrDefaultAsync(m => m.Id == id);
            if (educationLevel == null)
            {
                return NotFound();
            }

            return View(educationLevel);
        }

        // POST: EducationLevels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var educationLevel = await _context.EducationLevels.FindAsync(id);
            _context.EducationLevels.Remove(educationLevel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EducationLevelExists(int id)
        {
            return _context.EducationLevels.Any(e => e.Id == id);
        }
    }
}
