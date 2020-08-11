using System.Collections.Generic;
using LandonHotel.Data;

namespace LandonHotel.Repositories
{
    public interface IBookingsRepository
    {
        IList<Booking> GetBookings(int roomId);
    }
}