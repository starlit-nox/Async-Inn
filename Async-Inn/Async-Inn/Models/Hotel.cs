using System.ComponentModel.DataAnnotations;

namespace Async_Inn.Models
{
    public class Hotel
    {
        [Key]
        public int ID { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Address { get; set; }

        [Required]
        public string City { get; set; }

        [Required]
        public string State { get; set; }

        [Required]
        public string Phone { get; set; }

    }
}
