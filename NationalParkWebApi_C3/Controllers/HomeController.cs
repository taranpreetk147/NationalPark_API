using Microsoft.AspNetCore.Mvc;
using NationalParkWebApi_C3.Models;
using NationalParkWebApi_C3.Models.ViewModels;
using NationalParkWebApi_C3.Repository.IRepository;
using System.Diagnostics;

namespace NationalParkWebApi_C3.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ITrailRepository _trailRepository;
        private readonly INationalParkRepository _nationalParkRepository;
        private readonly IBookingRepository _bookingRepository;
        public HomeController(ILogger<HomeController> logger,ITrailRepository trailRepository,INationalParkRepository nationalParkRepository,IBookingRepository bookingRepository)
        {
            _logger = logger;
            _trailRepository = trailRepository;
            _nationalParkRepository = nationalParkRepository;
            _bookingRepository = bookingRepository;
        }

        public async Task<IActionResult> Index()
        {
            IndexVM indexVM = new IndexVM()
            {
                NationalParkList = await _nationalParkRepository.GetAllAsync(SD.NationalParkAPIPath),
                TrailList = await _trailRepository.GetAllAsync(SD.TrailAPIPath)
            };
            return View(indexVM);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }       
    }
}