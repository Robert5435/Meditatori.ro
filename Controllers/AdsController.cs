using AutoMapper;
using BeMyTeacher.Util;
using BeMyTeacher.ViewModels;
using Meditatori.Models;
using Meditatori.ro2.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Meditatori.ro2.Controllers
{
    public class AdsController : Controller
    {
        private readonly SiteDbContext _context;
        private readonly IMapper _mapper;

        public AdsController(SiteDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        //GET: Ads
        public async Task<IActionResult> Index(int? pageNumber, string searchStringSubject)
        {
            int pageSize = 5;

            ViewData["CurrentFilter"] = searchStringSubject;

            if (searchStringSubject != null)
            {
                pageNumber = 1;
            }

            var ads = _context.Ads.Include(a => a.Calification).Include(a => a.Location).Include(a => a.Subject).Include(a => a.EducationLevel).ToList();
            var importedSubjects = _context.Subjects;

            //var ads = _context.Ads.ToList();


            if (!String.IsNullOrEmpty(searchStringSubject))
            {
                ads = ads.Where(a => a.Subject.Name.Contains(searchStringSubject)).ToList();
            }

            List<SubjectViewModel> modelSubjects = new List<SubjectViewModel>();
            foreach (var subject in importedSubjects)
            {
                var subjectVM = _mapper.Map<SubjectViewModel>(subject);
                modelSubjects.Add(subjectVM);
            }


            List<AdViewModel> modelAds = new List<AdViewModel>();
            foreach (var ad in ads)
            {
                var adModel = _mapper.Map<AdViewModel>(ad);
                modelAds.Add(adModel);
            }
            
            var viewDataAd = await PaginatedList<AdViewModel>.CreateAsync(modelAds.AsQueryable().AsNoTracking() , pageNumber ?? 1, pageSize);
            var searchVM = new SearchAdViewModel()
            {
                Subjects = modelSubjects,
                Ads = viewDataAd
            };
            return View(searchVM);
        }

        // Post:Index
        [HttpPost]
        public async Task<IActionResult> Index([Bind("Id,Name")]SubjectViewModel subject)
        {
            if (ModelState.IsValid)
            {
                var subjects = subject.Name;
            }
            return RedirectToAction(nameof(Index));
        }





        // GET: Ads/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ad = await _context.Ads
                .Include(a => a.Calification)
                .Include(a => a.Location)
                .Include(a => a.Subject)
                .Include(a => a.EducationLevel)
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
            AdCreateViewModel adCreateVM = new AdCreateViewModel();

            adCreateVM.EducationLevels = _context.EducationLevels.OrderBy(educationLevel => educationLevel.name)
                .Select(educationLevel => new SelectListItem
                {
                    Value = educationLevel.Id.ToString(),
                    Text = educationLevel.name
                }).ToList();


            adCreateVM.Subjects = _context.Subjects.OrderBy(educationLevel => educationLevel.Name)
                .Select(educationLevel => new SelectListItem
                {
                    Value = educationLevel.Id.ToString(),
                    Text = educationLevel.Name
                }).ToList();


            adCreateVM.Califications = _context.Califications.OrderBy(educationLevel => educationLevel.name)
                .Select(educationLevel => new SelectListItem
                {
                    Value = educationLevel.Id.ToString(),
                    Text = educationLevel.name
                }).ToList();


            adCreateVM.Locations = _context.Locations.OrderBy(educationLevel => educationLevel.name)
                .Select(educationLevel => new SelectListItem
                {
                    Value = educationLevel.Id.ToString(),
                    Text = educationLevel.name
                }).ToList();

            //ViewData["CalificationId"] = new SelectList(_context.Set<Calification>(), "Id", "Id");
            //ViewData["LocationId"] = new SelectList(_context.Set<Location>(), "Id", "Id");
            return View(adCreateVM);
        }

        // POST: Ads/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public async Task<IActionResult> Create([Bind("SubjectId,EducationLevelId,CalificationId,Title,Content,Active,AvailabilityOnline,AvailabilityHome,AvailabilityStudentHome,PricePerSession,SessionLenghtinMinutes,ExpirationDate")] AdCreateViewModel ad)
        {
            if (ModelState.IsValid)
            {
                Ad adToBeAdded = new Ad();

                adToBeAdded.UserId = 1;
                adToBeAdded.ExpirationDate = DateTime.Now.AddDays(30);
                adToBeAdded.Title = ad.Title;
                adToBeAdded.Content = ad.Content;
                adToBeAdded.AvailabilityHome = ad.AvailabilityHome;
                adToBeAdded.AvailabilityOnline = ad.AvailabilityOnline;
                adToBeAdded.AvailabilityStudentHome = ad.AvailabilityStudentHome;
                adToBeAdded.EducationLevelId = ad.EducationLevelId;
                adToBeAdded.SubjectId = ad.SubjectId;
                adToBeAdded.CalificationId = ad.CalificationId;
                adToBeAdded.LocationId = ad.LocationId;
                adToBeAdded.PricePerSession = ad.PricePerSession;
                adToBeAdded.SessionLenghtinMinutes = ad.SessionLenghtinMinutes;


                _context.Add(adToBeAdded);
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
