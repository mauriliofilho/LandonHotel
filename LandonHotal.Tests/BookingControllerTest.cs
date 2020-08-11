using System;
using LandonHotel.Controllers;
using LandonHotel.Data;
using LandonHotel.Models;
using LandonHotel.Services;
using Moq;
using Xunit;

namespace LandonHotel.Tests
{
    public class BookingControllerTests
    {
        private Mock<IRoomService> roomService;
        private Mock<IBookingService> bookingService;

        public BookingControllerTests()
        {
            roomService = new Mock<IRoomService>();
            bookingService = new Mock<IBookingService>();
        }

        public BookingController Subject()
        {
            return new BookingController(roomService.Object, bookingService.Object);
        }

        [Fact]
        public void IndexPost_CalculatesPrice_WithCheckInDate()
        {
            var service = Subject();

            //service.Index(new BookingViewModel { CheckInDate = DateTime.MinValue });

            bookingService.Verify(s => s.CalculateBookingPrice(It.Is((Booking b) => b.CheckInDate == DateTime.MinValue)));
        }

        [Fact]
        public void IndexPost_CalculatesPrice_WithCheckOutDate()
        {
            var service = Subject();

            //service.Index(new BookingViewModel { CheckOutDate = DateTime.MaxValue });

            bookingService.Verify(s => s.CalculateBookingPrice(It.Is((Booking b) => b.CheckOutDate == DateTime.MaxValue)));
        }

        [Fact]
        public void IndexPost_CalculatesPrice_WithRoomId()
        {
            var service = Subject();

            //service.Index(new BookingViewModel { RoomId = 404 });

            bookingService.Verify(s => s.CalculateBookingPrice(It.Is((Booking b) => b.RoomId == 404)));
        }
    }
}
