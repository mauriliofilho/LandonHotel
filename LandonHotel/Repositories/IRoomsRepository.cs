using System.Collections.Generic;
using LandonHotel.Data;

namespace LandonHotel.Repositories
{
    public interface IRoomsRepository
    {
        IList<Room> GetRooms();
        Room GetRoom(int id);
    }
}