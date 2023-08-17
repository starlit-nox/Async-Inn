using Async_Inn.Data;
using Async_Inn.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Async_Inn.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoomsController : ControllerBase
    {
        private readonly AsyncInnContext _context;

        public RoomsController(AsyncInnContext context)
        {
            _context = context;
        }

        // GET: api/Rooms
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Room>>> GetRoom()
        {
            if (_context.Room == null)
            {
                return NotFound();
            }
            return await _context.Room
                .Include(r => r.HotelRooms)
                .ThenInclude(hr => hr.Hotel)
                .Include(r => r.RoomAmenities)
                .ThenInclude(ra => ra.Amenity)
                .ToListAsync();
        }

        // GET: api/Rooms/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Room>> GetRoom(int id)
        {
            if (_context.Room == null)
            {
                return NotFound();
            }
            var room = await _context.Room.FindAsync(id);

            if (room == null)
            {
                return NotFound();
            }

            return room;
        }

        // PUT: api/Rooms/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRoom(int id, Room room)
        {
            if (id != room.ID)
            {
                return BadRequest();
            }

            _context.Entry(room).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RoomExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Rooms
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Room>> PostRoom(Room room)
        {
            if (_context.Room == null)
            {
                return Problem("Entity set 'AsyncInnContext.Room'  is null.");
            }
            _context.Room.Add(room);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetRoom", new { id = room.ID }, room);
        }

        [HttpPost]
        [Route("/{roomId}/Amenity/{amenityId}")]
        public async Task<IActionResult> PostAmenityToRoom(int amenityID, int roomID)
        {
            if (_context.RoomAmenity == null)
            {
                return Problem("Entity set 'AsyncInnContext.RoomAmenity' is null");
            }
            var amenity = _context.Amenity.FindAsync(amenityID);
            if (amenity == null)
            {
                return Problem("No Amenity with that ID exists");
            }
            var room = _context.Room.FindAsync(roomID);
            if (room == null)
            {
                return Problem("No Room with that ID exists");
            }
            RoomAmenity newRA = new RoomAmenity();
            try
            {
                newRA = _context.RoomAmenities.Add(new RoomAmenity { AmenityID = amenityID, RoomID = roomID }).Entity;
            }
            catch (Exception e)
            {

            }
            finally
            {
                await _context.SaveChangesAsync();
            }
            return CreatedAtAction("PostAmenityToRoom", newRA.ID, newRA);
        }

        // DELETE: api/Rooms/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRoom(int id)
        {
            if (_context.Room == null)
            {
                return NotFound();
            }
            var room = await _context.Room.FindAsync(id);
            if (room == null)
            {
                return NotFound();
            }

            _context.Room.Remove(room);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool RoomExists(int id)
        {
            return (_context.Room?.Any(e => e.ID == id)).GetValueOrDefault();
        }
    }
}
