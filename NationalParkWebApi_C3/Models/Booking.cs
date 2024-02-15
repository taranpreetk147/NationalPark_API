using System.ComponentModel.DataAnnotations;

namespace NationalParkWebApi_C3.Models
{
    public class Booking
    {
        public int id { get; set; }
        [Required]
        public string name { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Phone { get; set; }
        [Required]
        public int Amount { get; set; }
        public DateTime BookingDate { get; set; }
    }
}
