using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NationalPark_API_C3.Models;
using NationalPark_API_C3.Models.DTOs;
using NationalPark_API_C3.Repository;
using NationalPark_API_C3.Repository.IRepository;

namespace NationalPark_API_C3.Controllers
{
    [Route("api/Booking")]
    [ApiController]
    public class BookingController : ControllerBase
    {
        private readonly IBookingRepository _bookingRepository;

        public BookingController(IBookingRepository bookingRepository)
        {
            _bookingRepository = bookingRepository;
        }

        [HttpGet]
        public IActionResult GetBookings()
        {
            var bookings = _bookingRepository.GetBookings();
            return Ok(bookings);
        }

        [HttpGet("{bookingId}")]
        public IActionResult GetBooking(int bookingId)
        {
            var booking = _bookingRepository.GetBooking(bookingId);

            if (booking == null)
            {
                return NotFound(); // Return 404 if the booking is not found
            }

            return Ok(booking);
        }

        [HttpPost]
        public IActionResult CreateBooking([FromBody] Booking booking)
        {
            if (booking == null)
            {
                return BadRequest(); // Return 400 if the provided data is invalid
            }

            if (_bookingRepository.CreateBooking(booking))
            {
                return Ok(booking); // Return the created booking
            }
            else
            {
                return StatusCode(500, "Internal Server Error"); // Return 500 if there's an issue creating the booking
            }
        }

        [HttpPut]
        public IActionResult UpdateBooking([FromBody] Booking booking)
        {
            if (booking == null) return BadRequest(); // Return 400 if the provided data is invalid            
            if (!ModelState.IsValid) return NotFound();
            if (_bookingRepository.UpdateBooking(booking))
            {
                return Ok(booking); // Return the updated booking
            }
            else
            {
                return StatusCode(500, "Internal Server Error"); // Return 500 if there's an issue updating the booking
            }

        }

        [HttpDelete("{bookingId}")]
        public IActionResult DeleteBooking(int bookingId)
        {
            var existingBooking = _bookingRepository.GetBooking(bookingId);

            if (existingBooking == null)
            {
                return NotFound(); // Return 404 if the booking is not found
            }

            if (_bookingRepository.DeleteBooking(existingBooking))
            {
                return NoContent(); // Return 204 (No Content) if the booking is successfully deleted
            }
            else
            {
                return StatusCode(500, "Internal Server Error"); // Return 500 if there's an issue deleting the booking
            }
        }
    }
}
   