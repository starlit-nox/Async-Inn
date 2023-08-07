using Async_Inn.Models;
using Microsoft.EntityFrameworkCore;

namespace Async_Inn.Data
{
    // DbContext for AsyncInn application
    public class AsyncInnContext : DbContext
    {
        // DbSet properties representing the database tables
        public DbSet<Amenity> Amenities;
        public DbSet<RoomAmenity> RoomAmenities;
        public DbSet<Room> Rooms;
        public DbSet<HotelRoom> HotelRooms;
        public DbSet<Hotel> Hotels;

        // Constructor for initializing DbContext with options
        public AsyncInnContext(DbContextOptions<AsyncInnContext> options) : base(options)
        {

        }

        // Method for configuring the database model
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Seed data for information tables
            modelBuilder.Entity<Amenity>().HasData(new Amenity
            { ID = 1, Name = "A/C" });
            modelBuilder.Entity<Room>().HasData(new Room
            { ID = 1, Layout = 0, Name = "Basic Room" },
            new Room
            { ID = 2, Layout = 1, Name = "Basic Single Room" },
            new Room
            { ID = 3, Layout = 2, Name = "Basic Double Room" });
            modelBuilder.Entity<Hotel>().HasData(new Hotel
            {
                ID = 1,
                Address = "123 Sesame St",
                City = "Memphis",
                State = "TN",
                Name = "Elmo's Hotel",
                Phone = "555-555-5555"
            });

            // Seed data for reference tables
            modelBuilder.Entity<RoomAmenity>().HasData(new RoomAmenity
            { ID = 1, AmenityID = 1, RoomID = 1 });
            modelBuilder.Entity<HotelRoom>().HasData(new HotelRoom
            { ID = 1, HotelID = 1, RoomID = 1, Price = 100.99 });
        }

        // DbSet properties for specific models
        public DbSet<Async_Inn.Models.Hotel> Hotel { get; set; } = default!;

        public DbSet<Async_Inn.Models.Amenity> Amenity { get; set; } = default!;

        public DbSet<Async_Inn.Models.Room> Room { get; set; } = default!;
    }
}
