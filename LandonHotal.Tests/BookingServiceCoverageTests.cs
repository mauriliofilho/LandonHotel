using System;
using LandonHotel.Data;
using LandonHotel.Repositories;
using LandonHotel.Services;
using Moq;
using Xunit;

namespace LandonHotel.Tests
{
    public class BookingServiceCoverageTests
    {
        private Mock<IRoomsRepository> roomRepo;
        private Mock<ICouponRepository> couponRepo;

        public BookingServiceCoverageTests()
        {
            roomRepo = new Mock<IRoomsRepository>();
            couponRepo = new Mock<ICouponRepository>();
        }

        public BookingService Subject()
        {
            return new BookingService(roomRepo.Object, couponRepo.Object);
        }

        [Fact]
        public void CalculateBookingPrice_CalculatesCorrectly()
        {
            var service = Subject();

            roomRepo.Setup(r => r.GetRoom(1)).Returns(new Room { Rate = 250 });

            var price = service.CalculateBookingPrice(new Booking { RoomId = 1, CheckInDate = DateTime.Now, CheckOutDate = DateTime.Now.AddDays(2) });

            Assert.Equal(500, price);
        }

        [Fact]
        public void CalculateBookingPrice_CalculatesCorrectly_WithEmptyCouponCode()
        {
            var service = Subject();

            roomRepo.Setup(r => r.GetRoom(1)).Returns(new Room { Rate = 250 });

            var price = service.CalculateBookingPrice(new Booking { RoomId = 1, CheckInDate = DateTime.Now, CheckOutDate = DateTime.Now.AddDays(2), CouponCode = "" });

            Assert.Equal(500, price);
        }

        [Fact]
        public void CalculateBookingPrice_DiscountCuponCode()
        {
            var service = Subject();

            roomRepo.Setup(r => r.GetRoom(1)).Returns(new Room() { Rate = 250 });
            couponRepo.Setup(r => r.GetCoupon("10OFF")).Returns(new Coupon() { PercentageDiscount = 10 });

            var price = service.CalculateBookingPrice(new Booking { RoomId = 1, CheckInDate = DateTime.Now, CheckOutDate = DateTime.Now.AddDays(2), CouponCode = "10OFF"});

            Assert.Equal(450, price);
        }

    }
}
