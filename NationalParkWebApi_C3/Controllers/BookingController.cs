using Microsoft.AspNetCore.Mvc;
using NationalParkWebApi_C3.Models;
using NationalParkWebApi_C3.Repository.IRepository;
using NuGet.Versioning;

namespace NationalParkWebApi_C3.Controllers
{
    public class BookingController : Controller
    {
        private readonly IBookingRepository _bookingRepository;
        public BookingController(IBookingRepository bookingRepository)
        {
            _bookingRepository = bookingRepository;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> Index(Booking booking, int numberOfChildren, int numberOfAdults)
        {
            int childPrice = 40 * numberOfChildren;
            int adultPrice = 80 * numberOfAdults;
            int totalPrice = childPrice + adultPrice;

            booking.Amount = totalPrice;
            var createdBooking = await _bookingRepository.CreateAsync(SD.BookingAPIPath, booking);
            if (createdBooking != null)
            {
                return RedirectToAction("Success");
            }
            else
            {
                ModelState.AddModelError(string.Empty, "Failed to create booking. Please try again.");
            }
            return View(booking);
        }
        public IActionResult Success()
        {
            return View();
        }

    }
}

