using System.Collections.Generic;
using System.Linq;
using LandonHotel.Data;

namespace LandonHotel.Repositories
{
    public class BookingsRepository : IBookingsRepository
    {
        // Stub repository data - this could be replaced by a database connection
        private readonly IList<Booking> bookings = new List<Booking>();

        public IList<Booking> GetBookings(int roomId)
        {
            return bookings.Where(b => b.RoomId == roomId).ToList();
        }
    }
}
