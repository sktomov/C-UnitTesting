using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Moq;
using NUnit.Framework;
using TestNinja.Mocking;

namespace UnitTestProject1.Mocking
{
    [TestFixture]
    public class BookingHelperTests
    {
        private Mock<IBookingStorage> _storage;

        [SetUp]
        public void SetUp()
        {
            _storage = new Mock<IBookingStorage>();
        }

        [Test]
        public void OverlappingBookingsExist_CancelledBooking_ReturnsEmptyString()
        {
            var booking = new Booking {Status = "Cancelled"};

            var result = BookingHelper.OverlappingBookingsExist(booking, _storage.Object);

            Assert.That(result, Is.EqualTo(string.Empty));
        }

        [Test]
        public void OverlappingBookingsExist_ActiveBookingWithoutOverlap_ReturnsEmptyString()
        {
            _storage.Setup(s => s.GetAllBookingsWithActiveStatusAndDifferentByGivenId(1))
                .Returns(new List<Booking>
                {
                    new Booking()
                    {
                        Id = 2,
                        Status = "Active",
                        ArrivalDate = DateTime.Now.AddDays(30),
                        DepartureDate = DateTime.Now.AddMonths(2),
                        Reference = "without"
                    }
                }.AsQueryable);

            var booking = new Booking { Status = "Active", Id = 1, Reference = "", ArrivalDate = DateTime.Now, DepartureDate = DateTime.Now.AddDays(2)};

            var result = BookingHelper.OverlappingBookingsExist(booking, _storage.Object);

            Assert.That(result, Is.EqualTo(string.Empty));
        }


        [Test]
        public void OverlappingBookingsExist_ActiveBookingWithOverlapArrivalDate_ReturnsReference()
        {
            _storage.Setup(s => s.GetAllBookingsWithActiveStatusAndDifferentByGivenId(1))
                .Returns(new List<Booking>
                {
                    new Booking()
                    {
                        Id = 2,
                        Status = "Active",
                        ArrivalDate = DateTime.Now.Date,
                        DepartureDate = DateTime.Now.Date.AddDays(1),
                        Reference = "abc"
                    }
                }.AsQueryable);

            var booking = new Booking { Status = "Active", Id = 1, Reference = "", ArrivalDate = DateTime.Now.Date, DepartureDate = DateTime.Now.AddDays(2) };

            var result = BookingHelper.OverlappingBookingsExist(booking, _storage.Object);

            Assert.That(result, Is.EqualTo("abc"));
        }

        [Test]
        public void OverlappingBookingsExist_ActiveBookingWithOverlapDepartureDate_ReturnsReference()
        {
            _storage.Setup(s => s.GetAllBookingsWithActiveStatusAndDifferentByGivenId(1))
                .Returns(new List<Booking>
                {
                    new Booking()
                    {
                        Id = 2,
                        Status = "Active",
                        ArrivalDate = DateTime.Now.Date.AddDays(-1),
                        DepartureDate = DateTime.Now.Date.AddDays(1),
                        Reference = "cba"
                    }
                }.AsQueryable);

            var booking = new Booking { Status = "Active", Id = 1, Reference = "", ArrivalDate = DateTime.Now.Date, DepartureDate = DateTime.Now.AddDays(1) };

            var result = BookingHelper.OverlappingBookingsExist(booking, _storage.Object);

            Assert.That(result, Is.EqualTo("cba"));
        }
    }
}
