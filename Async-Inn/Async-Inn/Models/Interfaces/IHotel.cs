using Async_Inn.Models;
using Microsoft.AspNetCore.Mvc;

namespace Async_Inn.Services
{
    public interface IHotel
    {
        public Task<ActionResult<IEnumerable<Hotel>>> GetHotel();

        public Task<ActionResult<Hotel>> GetHotel(int id);

        public Task<IActionResult> PutHotel(int id, Hotel hotel);

        public Task<ActionResult<Hotel>> PostHotel(Hotel hotel);

        public Task<IActionResult> DeleteHotel(int id);

        public bool HotelExists(int id);
    }
}