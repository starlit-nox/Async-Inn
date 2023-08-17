using System.ComponentModel.DataAnnotations;

namespace Async_Inn.Models
{
    public class Room
    {
        [Key]
        public int ID { get; set; }

        [Required]
        public string Name { get; set; }

        public int Layout { get; set; }

        public List<HotelRoom> HotelRooms { get; set; }

        public List<RoomAmenity> RoomAmenities { get; set; }
    }
}
