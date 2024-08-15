using Authorization.Data;
using Authorization.Interfaces;
using Authorization.Models;
using Microsoft.EntityFrameworkCore;

namespace Authorization.Repositories
{
    public class RoomRepository : IRoomRepository
    {
        private readonly ApplicationDbContext _myDbContext;

        public RoomRepository(ApplicationDbContext myDbContext)
        {
            _myDbContext = myDbContext;
        }

        public void Create(Room room)
        {
            _myDbContext.Rooms.Add(room);
            _myDbContext.SaveChanges();
        }

        public void Delete(int id)
        {
            Room room = (from roomObj in _myDbContext.Rooms
                         where roomObj.RoomId == id
                         select roomObj).FirstOrDefault();
            _myDbContext.Rooms.Remove(room);
            _myDbContext.SaveChanges();
        }

        public List<Room> GetAllRooms()
        {
            List<Room> rooms = (from roomObj in _myDbContext.Rooms
                                select roomObj).ToList();

            return rooms;
        }
    }
}

