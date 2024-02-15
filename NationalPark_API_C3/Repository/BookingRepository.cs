using NationalPark_API_C3.Data;
using NationalPark_API_C3.Models;
using NationalPark_API_C3.Repository.IRepository;

namespace NationalPark_API_C3.Repository
{
    public class BookingRepository : IBookingRepository
    {
        private readonly ApplicationDbContext _context;
        public BookingRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public bool Booking(int bookingId)
        {
           return _context.Bookings.Any(t=>t.Id == bookingId);
        }

        public bool CreateBooking(Booking booking)
        {
            _context.Bookings.Add(booking);
            return Save();
        }

        public bool DeleteBooking(Booking booking)
        {
            _context.Bookings.Remove(booking);
            return Save();
        }

        public Booking GetBooking(int bookingId)
        {
           return _context.Bookings.Find(bookingId);
        }

        public ICollection<Booking> GetBookings()
        {
            return _context.Bookings.ToList();
        }

        public bool Save()
        {
            return _context.SaveChanges() == 1 ? true : false;
        }

        public bool UpdateBooking(Booking booking)
        {
            _context.Bookings.Update(booking);
            return Save();
        }
    }
}
