using Async_Inn.Data;
using Async_Inn.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace Async_Inn.Controllers
{
    public class RoomAmenitiesController : Controller
    {
        private readonly AsyncInnContext _context;

        public RoomAmenitiesController(AsyncInnContext context)
        {
            _context = context;
        }

        // GET: RoomAmenities
        public async Task<IActionResult> Index()
        {
            var asyncInnContext = _context.RoomAmenity_1.Include(r => r.Amenity).Include(r => r.Room);
            return View(await asyncInnContext.ToListAsync());
        }

        // GET: RoomAmenities/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.RoomAmenity_1 == null)
            {
                return NotFound();
            }

            var roomAmenity = await _context.RoomAmenity_1
                .Include(r => r.Amenity)
                .Include(r => r.Room)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (roomAmenity == null)
            {
                return NotFound();
            }

            return View(roomAmenity);
        }

        // GET: RoomAmenities/Create
        public IActionResult Create()
        {
            ViewData["AmenityID"] = new SelectList(_context.Amenity, "ID", "Name");
            ViewData["RoomID"] = new SelectList(_context.Room, "ID", "Name");
            return View();
        }

        // POST: RoomAmenities/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,RoomID,AmenityID")] RoomAmenity roomAmenity)
        {
            if (ModelState.IsValid)
            {
                _context.Add(roomAmenity);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["AmenityID"] = new SelectList(_context.Amenity, "ID", "Name", roomAmenity.AmenityID);
            ViewData["RoomID"] = new SelectList(_context.Room, "ID", "Name", roomAmenity.RoomID);
            return View(roomAmenity);
        }

        // GET: RoomAmenities/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.RoomAmenity_1 == null)
            {
                return NotFound();
            }

            var roomAmenity = await _context.RoomAmenity_1.FindAsync(id);
            if (roomAmenity == null)
            {
                return NotFound();
            }
            ViewData["AmenityID"] = new SelectList(_context.Amenity, "ID", "Name", roomAmenity.AmenityID);
            ViewData["RoomID"] = new SelectList(_context.Room, "ID", "Name", roomAmenity.RoomID);
            return View(roomAmenity);
        }

        // POST: RoomAmenities/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,RoomID,AmenityID")] RoomAmenity roomAmenity)
        {
            if (id != roomAmenity.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(roomAmenity);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RoomAmenityExists(roomAmenity.ID))
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
            ViewData["AmenityID"] = new SelectList(_context.Amenity, "ID", "Name", roomAmenity.AmenityID);
            ViewData["RoomID"] = new SelectList(_context.Room, "ID", "Name", roomAmenity.RoomID);
            return View(roomAmenity);
        }

        // GET: RoomAmenities/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.RoomAmenity_1 == null)
            {
                return NotFound();
            }

            var roomAmenity = await _context.RoomAmenity_1
                .Include(r => r.Amenity)
                .Include(r => r.Room)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (roomAmenity == null)
            {
                return NotFound();
            }

            return View(roomAmenity);
        }

        // POST: RoomAmenities/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.RoomAmenity_1 == null)
            {
                return Problem("Entity set 'AsyncInnContext.RoomAmenity_1'  is null.");
            }
            var roomAmenity = await _context.RoomAmenity_1.FindAsync(id);
            if (roomAmenity != null)
            {
                _context.RoomAmenity_1.Remove(roomAmenity);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RoomAmenityExists(int id)
        {
            return (_context.RoomAmenity_1?.Any(e => e.ID == id)).GetValueOrDefault();
        }
    }
}
