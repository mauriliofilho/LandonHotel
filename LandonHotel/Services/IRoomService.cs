using System.Collections.Generic;
using LandonHotel.Data;

namespace LandonHotel.Services
{
    public interface IRoomService
    {
        IList<Room> GetAllRooms();
    }
}