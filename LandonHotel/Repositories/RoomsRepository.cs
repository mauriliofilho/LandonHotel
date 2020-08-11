using System.Collections.Generic;
using System.Linq;
using LandonHotel.Data;

namespace LandonHotel.Repositories
{
    public class RoomsRepository : IRoomsRepository
    {
        // Stub repository data - this could be replaced by a database connection
        private readonly IList<Room> roomList = new List<Room>
        {
            new Room
            {
                Id = 1,
                Name = "Winchester",
                ArePetsAllowed = true,
                Capacity = 5,
                Rate = 200
            },
            new Room
            {
                Id = 2,
                Name = "Piccadilly",
                ArePetsAllowed = false,
                Capacity = 3,
                Rate = 250
            }
        };

        public IList<Room> GetRooms()
        {
            return roomList;
        }

        public Room GetRoom(int id)
        {
            return roomList.SingleOrDefault(r => r.Id == id);
        }
    }
}