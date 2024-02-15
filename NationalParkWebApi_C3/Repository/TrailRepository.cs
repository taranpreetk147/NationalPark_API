using NationalParkWebApi_C3.Models;
using NationalParkWebApi_C3.Repository.IRepository;

namespace NationalParkWebApi_C3.Repository
{
    public class TrailRepository:Repository<Trail>,ITrailRepository
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public TrailRepository(IHttpClientFactory httpClientFactory):base(httpClientFactory)
        {

            _httpClientFactory = httpClientFactory;

        }
    }
}
