using System.Collections.Generic;
using LandonHotel.Data;
using LandonHotel.Repositories;

namespace LandonHotel.Services
{
    public class RoomService : IRoomService
    {
        private readonly IRoomsRepository _roomRepo;

        public RoomService(IRoomsRepository roomRepo)
        {
            _roomRepo = roomRepo;
        }

        public IList<Room> GetAllRooms()
        {
            return _roomRepo.GetRooms(); 
        }
    }
}
