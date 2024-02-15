using NationalParkWebApi_C3.Models;
using NationalParkWebApi_C3.Repository.IRepository;

namespace NationalParkWebApi_C3.Repository
{
    public class NationalParkRepository:Repository<NationalPark>,INationalParkRepository
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public NationalParkRepository(IHttpClientFactory httpClientFactory):base(httpClientFactory)
        {

            _httpClientFactory = httpClientFactory;

        }
    }
}
