using System;
using Authorization.Models;

namespace Authorization.Interfaces
{
	public interface IRoomRepository
	{
        public List<Room> GetAllRooms();

        public void Create(Room room);

        public void Delete(int id);
    }
}

