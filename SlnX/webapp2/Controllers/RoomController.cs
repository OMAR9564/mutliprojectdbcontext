using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Authorization.Interfaces;
using Authorization.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace webapp2.Controllers
{
    public class RoomController : Controller
    {

        private readonly IRoomRepository _roomRepository;

        public RoomController(IRoomRepository roomRepository)
        {
            _roomRepository = roomRepository;
        }

        [HttpGet]
        public ActionResult Index()
        {
            List<Room> rooms = _roomRepository.GetAllRooms();
            return View();
        }

        [HttpGet]
        public ViewResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Room room)
        {
            if (room != null)
            {
                _roomRepository.Create(room);

            }
            return View();
        }

        public ActionResult Delete(int id)
        {
            if (id > 0)
            {
                _roomRepository.Delete(id);
            }
            return View();
        }

    }
}

