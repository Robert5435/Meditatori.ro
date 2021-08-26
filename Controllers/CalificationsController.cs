using Meditatori.Models;
using Meditatori.ro2.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace Meditatori.ro2.Controllers
{
    public class CalificationsController : Controller
    {
        private readonly SiteDbContext _context;

        public CalificationsController(SiteDbContext context)
        {
            _context = context;
        }

        // GET: Califications
        public async Task<IActionResult> Index()
        {
            return View(await _context.Califications.ToListAsync());
        }

        // GET: Califications/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var calification = await _context.Califications
                .FirstOrDefaultAsync(m => m.Id == id);
            if (calification == null)
            {
                return NotFound();
            }

            return View(calification);
        }

        // GET: Califications/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Califications/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,name")] Calification calification)
        {
            if (ModelState.IsValid)
            {
                _context.Add(calification);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(calification);
        }

        // GET: Califications/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var calification = await _context.Califications.FindAsync(id);
            if (calification == null)
            {
                return NotFound();
            }
            return View(calification);
        }

        // POST: Califications/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,name")] Calification calification)
        {
            if (id != calification.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(calification);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CalificationExists(calification.Id))
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
            return View(calification);
        }

        // GET: Califications/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var calification = await _context.Califications
                .FirstOrDefaultAsync(m => m.Id == id);
            if (calification == null)
            {
                return NotFound();
            }

            return View(calification);
        }

        // POST: Califications/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var calification = await _context.Califications.FindAsync(id);
            _context.Califications.Remove(calification);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CalificationExists(int id)
        {
            return _context.Califications.Any(e => e.Id == id);
        }
    }
}
