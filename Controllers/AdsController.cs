using BeMyTeacher.Util;
using Meditatori.Models;
using Meditatori.ro2.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace Meditatori.ro2.Controllers
{
    public class AdsController : Controller
    {
        private readonly SiteDbContext _context;

        public AdsController(SiteDbContext context)
        {
            _context = context;
        }

        // GET: Ads
        public async Task<IActionResult> Index(int? pageNumber)
        {
            var siteDbContext = _context.Ads.Include(a => a.Calification).Include(a => a.Location).Include(a => a.Subject).Include(a => a.EducationLevel);
            //return View(await siteDbContext.ToListAsync());
            int pageSize = 3;
            var viewDataAd = await PaginatedList<Ad>.CreateAsync(siteDbContext.AsNoTracking(), pageNumber ?? 1, pageSize);
            return View(viewDataAd);
        }

        // GET: Ads/Details/5
        [Authorize]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ad = await _context.Ads
                .Include(a => a.Calification)
                .Include(a => a.Location)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (ad == null)
            {
                return NotFound();
            }

            return View(ad);
        }

        // GET: Ads/Create
        [Authorize]
        public IActionResult Create()
        {
            ViewData["CalificationId"] = new SelectList(_context.Set<Calification>(), "Id", "Id");
            ViewData["LocationId"] = new SelectList(_context.Set<Location>(), "Id", "Id");
            return View();
        }

        // POST: Ads/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public async Task<IActionResult> Create([Bind("Id,UserId,LocationId,SubjectId,EducationLevelId,CalificationId,Title,Content,Active,AvailabilityOnline,AvailabilityHome,AvailabilityStudentHome,PricePerSession,SessionLenghtinMinutes,ExpirationDate")] Ad ad)
        {
            if (ModelState.IsValid)
            {
                _context.Add(ad);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CalificationId"] = new SelectList(_context.Set<Calification>(), "Id", "Id", ad.CalificationId);
            ViewData["LocationId"] = new SelectList(_context.Set<Location>(), "Id", "Id", ad.LocationId);
            return View(ad);
        }

        // GET: Ads/Edit/5
        [Authorize]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ad = await _context.Ads.FindAsync(id);
            if (ad == null)
            {
                return NotFound();
            }
            ViewData["CalificationId"] = new SelectList(_context.Set<Calification>(), "Id", "Id", ad.CalificationId);
            ViewData["LocationId"] = new SelectList(_context.Set<Location>(), "Id", "Id", ad.LocationId);
            return View(ad);
        }

        // POST: Ads/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public async Task<IActionResult> Edit(int id, [Bind("Id,UserId,LocationId,SubjectId,EducationLevelId,CalificationId,Title,Content,Active,AvailabilityOnline,AvailabilityHome,AvailabilityStudentHome,PricePerSession,SessionLenghtinMinutes,ExpirationDate")] Ad ad)
        {
            if (id != ad.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(ad);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AdExists(ad.Id))
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
            ViewData["CalificationId"] = new SelectList(_context.Set<Calification>(), "Id", "Id", ad.CalificationId);
            ViewData["LocationId"] = new SelectList(_context.Set<Location>(), "Id", "Id", ad.LocationId);
            return View(ad);
        }

        // GET: Ads/Delete/5
        [Authorize]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ad = await _context.Ads
                .Include(a => a.Calification)
                .Include(a => a.Location)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (ad == null)
            {
                return NotFound();
            }

            return View(ad);
        }

        // POST: Ads/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var ad = await _context.Ads.FindAsync(id);
            _context.Ads.Remove(ad);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AdExists(int id)
        {
            return _context.Ads.Any(e => e.Id == id);
        }
    }
}
