using Async_Inn.Models;
using Microsoft.EntityFrameworkCore;

namespace Async_Inn.Data
{
    public class AsyncInnContext : DbContext
    {
        public DbSet<Amenity> Amenities;
        public DbSet<RoomAmenity> RoomAmenities;
        public DbSet<Room> Rooms;
        public DbSet<HotelRoom> HotelRooms;
        public DbSet<Hotel> Hotels;

        public AsyncInnContext(DbContextOptions<AsyncInnContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            // this is adding data to the function to add / retrieve it
            modelBuilder.Entity<Amenity>().HasData(new Amenity
            { ID = 1, Name = "A/C" });

            modelBuilder.Entity<Room>().HasData(new Room
            { ID = 1, Layout = 0, Name = "Basic Room" });

            modelBuilder.Entity<Hotel>().HasData(new Hotel
            { ID = 1, Address = "123 Seasame St", City = "Memphis", State = "TN", Name = "Elmo's Hotel", Phone = " 111-111-1111" });



            //lookup table
            modelBuilder.Entity<RoomAmenity>().HasData(new RoomAmenity
            { ID = 1, AmenityID = 1, RoomID = 1 });
            modelBuilder.Entity<HotelRoom>().HasData(new HotelRoom { ID = 1, HotelID = 1, Price = 100.99 });
        }
        public DbSet<Async_Inn.Models.Hotel> Hotel { get; set; } = default!;
        public DbSet<Async_Inn.Models.Room> Room { get; set; } = default!;
        public DbSet<Async_Inn.Models.Amenity> Amenity { get; set; } = default!;
        public object RoomAmenity { get; internal set; }
    }
}
