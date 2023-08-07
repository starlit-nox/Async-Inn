using Async_Inn.Data;
using Async_Inn.Models;
using Async_Inn.Services;
using Microsoft.AspNetCore.Mvc;

namespace Async_Inn.Controllers
{
    /*
     * app.get("/", getData);
     * app.post("/", updloadData);
     */
    // https://localhost:1234/api/hotels/
    // https://asyncinn.com/api/hotels
    [Route("api/[controller]")]
    [ApiController]
    public class HotelsController : ControllerBase
    {
        private readonly AsyncInnContext _context;
        private readonly IHotel _hotel;

        public HotelsController(AsyncInnContext context, IHotel hotel)
        {
            _context = context;
            _hotel = hotel;
        }

        // get: api/hotels
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Hotel>>> GetHotel()
        {
            return await _hotel.GetHotel();
        }

        // get: api/hotels/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Hotel>> GetHotel(int id)
        {
            return await _hotel.GetHotel(id);
        }

        // put: api/hotels/5
        // to protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutHotel(int id, Hotel hotel)
        {
            if (id != hotel.ID)
            {
                return BadRequest();
            }
            await _hotel.PutHotel(id, hotel);

            return NoContent();
        }

        // post: api/hotels
        // to protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Hotel>> PostHotel(Hotel hotel)
        {
            await _hotel.PostHotel(hotel);

            return CreatedAtAction("GetHotel", new { id = hotel.ID }, hotel);
        }

        // delete: api/hotels/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteHotel(int id)
        {
            await _hotel.DeleteHotel(id);
            return NoContent();
        }

        private bool HotelExists(int id)
        {
            return _hotel.HotelExists(id);
        }
    }
}
