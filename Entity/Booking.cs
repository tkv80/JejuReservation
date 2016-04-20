using System;

namespace JejuReservation.Entity
{
    internal class Booking
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public string Tel { get; set; }
        public int People { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public string Email { get; set; }
    }
}