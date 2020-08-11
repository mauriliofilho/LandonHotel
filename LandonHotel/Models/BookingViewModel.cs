using System;
using System.Collections.Generic;
using LandonHotel.Data;

namespace LandonHotel.Models
{
    public class BookingViewModel
    {
        public int RoomId { get; set; }
        public string EmailAddress { get; set; }
        public DateTime CheckOutDate { get; set; }
        public DateTime CheckInDate { get; set; }
        public int NumberOfGuests { get; set; }
        public bool BringingPets { get; set; }
        public bool IsSmoking { get; set; }
        public IList<Room> Rooms { get; set; }
        public string CouponCode { get; set; }
    }
}
