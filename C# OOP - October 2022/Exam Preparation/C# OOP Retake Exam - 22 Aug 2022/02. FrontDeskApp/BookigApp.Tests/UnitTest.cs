using System;
using NUnit.Framework;

using FrontDeskApp;

namespace BookigApp.Tests
{
    public class Tests
    {
        private Room defaultValidRoom;
        private Hotel defaultValidHotel;

        [SetUp]
        public void Setup()
        {
            defaultValidRoom = new Room(1, 1);
            defaultValidHotel = new Hotel("default", 1);
        }

        [TestCase(1, 1)]
        public void RoomConstructorShouldCreateObjectWithCorrectInput(int bedCapacity, double pricePerNight)
        {
            Room room = new Room(bedCapacity, pricePerNight);

            Assert.AreEqual(bedCapacity, room.BedCapacity);
            Assert.AreEqual(pricePerNight, room.PricePerNight);
        }

        [TestCase(0, 1)]
        [TestCase(1, 0)]
        public void RoomConstructorShouldThrowWithIncorrectInput(int bedCapacity, double pricePerNight)
        {
            Assert.Throws<ArgumentException>(() => new Room(bedCapacity, pricePerNight),
                "Input parameters should not be zero or negative.");
        }

        [TestCase(111, 111)]
        public void BookingConstructorShouldCreateInstanceWithCorrectInput(int bookingNumber, int residenceDuration)
        {
            Booking booking = new Booking(bookingNumber, defaultValidRoom, residenceDuration);

            Assert.AreEqual(bookingNumber, booking.BookingNumber);
            Assert.AreEqual(defaultValidRoom, booking.Room);
            Assert.AreEqual(residenceDuration, booking.ResidenceDuration);
        }

        [TestCase("default", 1)]
        [TestCase("default", 3)]
        [TestCase("default", 5)]
        public void HotelConstructorShouldCreateInstanceWithCorrentInput(string fullName, int category)
        {
            Hotel hotel = new Hotel(fullName, category);

            Assert.AreEqual(fullName, hotel.FullName);
            Assert.AreEqual(category, hotel.Category);
            Assert.AreEqual(0, hotel.Turnover);
        }

        [TestCase(null, 0)]
        [TestCase(" ", 0)]
        public void HotelConstructorShouldThrowWithNullOrEmptySpaceInputForFullName(string fullName, int category)
        {
            Assert.Throws<ArgumentNullException>(() => new Hotel(fullName, category),
                "Name cannot be null or empty space.");
        }

        [TestCase("default", 0)]
        [TestCase("default", 6)]
        public void HotelConstructorShouldThrowWithOutOfRangeInputForCategory(string fullName, int category)
        {
            Assert.Throws<ArgumentException>(() => new Hotel(fullName, category),
                "Category cannot be lower than one or higher than 5.");
        }

        [Test]
        public void AddMethodShouldAddRoomObjectToHotelRoomCollection()
        {
            Hotel hotel = new Hotel("default", 1);
            hotel.AddRoom(defaultValidRoom);

            Assert.AreEqual(1, hotel.Bookings.Count);
        }

        [TestCase(-1, -1, 0)]
        [TestCase(0, -1, 0)]
        [TestCase(1, -1, 0)]
        [TestCase(1, 0, 0)]
        public void BookRoomMethodShouldThrowWithInvalidInput(int adults, int children, int residenceDuration, double budget = 0)
        {
            Assert.Throws<ArgumentException>(() => defaultValidHotel.BookRoom(adults, children, residenceDuration, budget));
        }

        [Test]
        public void BookRoomShouldNotCreateBookingIfThereAreNotEnoughBeds()
        {
            defaultValidHotel.AddRoom(defaultValidRoom);
            defaultValidHotel.BookRoom(10, 10, 10, 10.0);

            Assert.AreEqual(0, defaultValidHotel.Bookings.Count);
        }

        [Test]
        public void BookRoomShouldNotCreateBookingIfBudgetIsInsufficient()
        {
            defaultValidHotel.AddRoom(defaultValidRoom);
            defaultValidHotel.BookRoom(10, 10, 10, 1.0);

            Assert.AreEqual(0, defaultValidHotel.Bookings.Count);
        }

        [Test]
        public void BookRoomShouldCreateBookingIfConditionsAreMet()
        {
            defaultValidHotel.AddRoom(defaultValidRoom);
            defaultValidHotel.BookRoom(1, 0, 1, 10);

            Assert.AreEqual(1, defaultValidHotel.Bookings.Count);
        }
    }
}