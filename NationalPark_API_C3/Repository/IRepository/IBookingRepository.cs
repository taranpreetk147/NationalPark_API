using NationalPark_API_C3.Models;

namespace NationalPark_API_C3.Repository.IRepository
{
    public interface IBookingRepository
    {
        ICollection<Booking> GetBookings();
        Booking GetBooking(int bookingId);
        bool Booking(int bookingId);
        bool CreateBooking(Booking booking);
        bool UpdateBooking(Booking booking);
        bool DeleteBooking(Booking booking);
        bool Save();
    }
}
