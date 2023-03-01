using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

using BookingApp.Core.Contracts;
using BookingApp.Models.Hotels.Contacts;
using BookingApp.Models.Rooms.Contracts;
using BookingApp.Models.Rooms.Contracts.RoomClasses;
using BookingApp.Repositories.Contracts;
using BookingApp.Utilities.Messages;
using BookingApp.Models.Bookings.Contracts;

namespace BookingApp.Core
{
    public class Controller : IController
    {
        private HotelRepository hotels;

        public Controller()
        {
            hotels = new HotelRepository();
        }

        public string AddHotel(string hotelName, int category)
        {
            if (HotelAlreadyExists(hotelName))
            {
                return string.Format(OutputMessages.HotelAlreadyRegistered, hotelName);
            }

            hotels.AddNew(new Hotel(hotelName, category));
            return string.Format(OutputMessages.HotelSuccessfullyRegistered, category, hotelName);
        }

        public string UploadRoomTypes(string hotelName, string roomTypeName)
        {
            if (!HotelAlreadyExists(hotelName))
            {
                return string.Format(OutputMessages.HotelNameInvalid, hotelName);
            }

            if (RoomTypeIsValid(roomTypeName))
            {
                var currentHotel = GetHotel(hotelName);

                if (RoomAlreadyExists(currentHotel, roomTypeName))
                {
                    return OutputMessages.RoomTypeAlreadyCreated;
                }

                switch (roomTypeName)
                {
                    case "Apartment":
                        currentHotel.Rooms.AddNew(new Apartment());
                        break;
                    case "DoubleBed":
                        currentHotel.Rooms.AddNew(new DoubleBed());
                        break;
                    case "Studio":
                        currentHotel.Rooms.AddNew(new Studio());
                        break;
                }

                return string.Format(OutputMessages.RoomTypeAdded, roomTypeName, hotelName);
            }
            else
            {
                throw new ArgumentException(ExceptionMessages.RoomTypeIncorrect);
            }
        }

        public string SetRoomPrices(string hotelName, string roomTypeName, double price)
        {
            if (!HotelAlreadyExists(hotelName))
            {
                return string.Format(OutputMessages.HotelNameInvalid, hotelName);
            }

            if (RoomTypeIsValid(roomTypeName))
            {
                var currentHotel = GetHotel(hotelName);

                if (!RoomAlreadyExists(currentHotel, roomTypeName))
                {
                    return OutputMessages.RoomTypeNotCreated;
                }

                var currentRoom = GetRoom(currentHotel, roomTypeName);

                if (currentRoom.PricePerNight == 0)
                {
                    currentRoom.SetPrice(price);
                    return string.Format(OutputMessages.PriceSetSuccessfully, roomTypeName, hotelName);
                }
                else
                {
                    throw new InvalidOperationException(ExceptionMessages.CannotResetInitialPrice);
                }
            }
            else
            {
                throw new ArgumentException(ExceptionMessages.RoomTypeIncorrect);
            }
        }

        public string BookAvailableRoom(int adults, int children, int duration, int category)
        {
            if (hotels.All().Any(h => h.Category == category))
            {
                if (hotels.All().Any(h => h.Rooms.All()
                .Any(r => r.BedCapacity <= adults + children)))
                {
                    var orderedHotels = hotels.All()
                        .OrderBy(h => h.FullName);

                    var applicableRooms = new List<IRoom>();

                    foreach (var hotel in orderedHotels)
                    {
                        foreach (var room in hotel.Rooms.All())
                        {
                            if (room.PricePerNight != 0)
                            {
                                applicableRooms.Add(room);
                            }
                        }
                    }

                    var orderedRooms = applicableRooms.OrderBy(r => r.BedCapacity);

                    bool noRoomFound = true;

                    foreach (var room in orderedRooms)
                    {
                        if (room.BedCapacity >= adults + children)
                        {
                            noRoomFound = false;

                            var bookedHotel = hotels.All()
                                .First(h => h.Rooms.All()
                                .Any(r => r.Equals(room)));
                            int bookingNumber = bookedHotel.Bookings.All().Count + 1;

                            bookedHotel.Bookings.AddNew(new Booking(room, duration, adults, children, bookingNumber));

                            return string.Format(OutputMessages.BookingSuccessful, bookingNumber, bookedHotel.FullName);
                        }
                    }

                    if (noRoomFound)
                    {
                        return OutputMessages.RoomNotAppropriate;
                    }
                }
                else
                {
                    return OutputMessages.RoomNotAppropriate;
                }
            }
            else
            {
                return string.Format(OutputMessages.CategoryInvalid, category);
            }

            return null;
        }

        public string HotelReport(string hotelName)
        {
            var hotel = GetHotel(hotelName);
            StringBuilder output = new StringBuilder();

            output.AppendLine($"Hotel name: {hotel.FullName}");
            output.AppendLine($"--{hotel.Category} star hotel");
            output.AppendLine($"--Turnover: {hotel.Turnover:F2} $");
            output.AppendLine($"--Bookings:");
            output.AppendLine();

            if (hotel.Bookings.All().Count == 0)
            {
                output.AppendLine("none");
            }
            else
            {
                foreach (var booking in hotel.Bookings.All())
                {
                    output.AppendLine($"Booking number: {booking.BookingNumber}");
                    output.AppendLine($"Room type: {booking.Room.GetType().Name}");
                    output.AppendLine($"Adults: {booking.AdultsCount} Children: {booking.ChildrenCount}");
                    output.AppendLine($"Total amount paid: " +
                        $"{Math.Round(booking.ResidenceDuration * booking.Room.PricePerNight, 2):F2} $");
                    output.AppendLine();
                }
            }

            return output.ToString().TrimEnd();
        }

        private bool HotelAlreadyExists(string hotelName)
        {
            if (hotels.All().Any(h => h.FullName == hotelName))
            {
                return true;
            }

            return false;
        }

        private IHotel GetHotel(string hotelName)
        {
            return hotels.All().First(h => h.FullName == hotelName);
        }

        private bool RoomTypeIsValid(string roomTypeName)
        {
            string[] roomTypes = { "Apartment", "DoubleBed", "Studio" };

            if (roomTypes.Contains(roomTypeName))
            {
                return true;
            }

            return false;
        }

        private bool RoomAlreadyExists(IHotel currentHotel, string roomTypeName)
        {
            if (currentHotel.Rooms.All().Any(r => r.GetType().Name == roomTypeName))
            {
                return true;
            }

            return false;
        }

        private IRoom GetRoom(IHotel currentHotel, string roomTypeName)
        {
            return currentHotel.Rooms.All().First(r => r.GetType().Name == roomTypeName);
        }
    }
}
