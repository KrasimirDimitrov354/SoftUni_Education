using System.Collections.Generic;
using System.Linq;

using BookingApp.Models.Bookings.Contracts;

namespace BookingApp.Repositories.Contracts
{
    public class BookingRepository : IRepository<IBooking>
    {
        private List<IBooking> bookings;

        public BookingRepository()
        {
            bookings = new List<IBooking>();
        }

        public void AddNew(IBooking booking)
        {
            bookings.Add(booking);
        }

        public IBooking Select(string bookingNumberToString)
        {
            return bookings.FirstOrDefault(b => b.BookingNumber == int.Parse(bookingNumberToString));
        }

        public IReadOnlyCollection<IBooking> All()
        {
            return bookings.AsReadOnly();
        }
    }
}
