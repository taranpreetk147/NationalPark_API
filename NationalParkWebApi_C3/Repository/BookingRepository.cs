using NationalParkWebApi_C3.Models;
using NationalParkWebApi_C3.Repository.IRepository;

namespace NationalParkWebApi_C3.Repository
{
    public class BookingRepository:Repository<Booking>,IBookingRepository
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public BookingRepository(IHttpClientFactory httpClientFactory):base(httpClientFactory) 
        {
            _httpClientFactory = httpClientFactory;   
        }
    }
}
