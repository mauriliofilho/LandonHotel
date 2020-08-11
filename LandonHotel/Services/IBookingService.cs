using LandonHotel.Data;

namespace LandonHotel.Services
{
    public interface IBookingService
    {
        bool IsBookingValid(int roomId, Booking booking);

        decimal CalculateBookingPrice(Booking booking);
    }
}