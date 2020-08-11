using System;
using LandonHotel.Data;
using LandonHotel.Models;
using LandonHotel.Services;
using Microsoft.AspNetCore.Mvc;

namespace LandonHotel.Controllers
{
    public class BookingController : Controller
    {
        private readonly IRoomService roomService;
        private readonly IBookingService bookingService;

        public BookingController(IRoomService roomService, IBookingService bookingService)
        {
            this.roomService = roomService;
            this.bookingService = bookingService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var model = new BookingViewModel()
            {
                CheckInDate = DateTime.Now,
                CheckOutDate = DateTime.Now.AddDays(1),
                Rooms = roomService.GetAllRooms()
            };
            return View(model);
        }

        [HttpPost]
        public IActionResult Index(BookingViewModel model)
        {
            if (!ModelState.IsValid)
            {
                model.Rooms = roomService.GetAllRooms();
                ViewBag.ErrorMessage = "Booking was not valid";

                return View("Index", model);

            }

            var booking = new Booking()
            {
                CheckInDate = model.CheckInDate,
                CheckOutDate = model.CheckOutDate,
                RoomId = model.RoomId,
                CouponCode= model.CouponCode
            };

            //model.Rooms = roomService.GetAllRooms();
            //ViewBag.ErrorMessage = "Booking was not valid";

            return View("Success", new BookingSuccessViewModel
            {
                Price = bookingService.CalculateBookingPrice(booking)
            });
        }
    }
}
