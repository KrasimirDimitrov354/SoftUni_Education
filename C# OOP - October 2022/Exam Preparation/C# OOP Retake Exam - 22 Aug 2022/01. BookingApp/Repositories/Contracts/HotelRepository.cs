using System.Collections.Generic;
using System.Linq;

using BookingApp.Models.Hotels.Contacts;

namespace BookingApp.Repositories.Contracts
{
    public class HotelRepository : IRepository<IHotel>
    {
        private List<IHotel> hotels;

        public HotelRepository()
        {
            hotels = new List<IHotel>();
        }

        public void AddNew(IHotel hotel)
        {
            hotels.Add(hotel);
        }

        public IHotel Select(string hotelName)
        {
            return hotels.FirstOrDefault(h => h.FullName == hotelName);
        }

        public IReadOnlyCollection<IHotel> All()
        {
            return hotels.AsReadOnly();
        }
    }
}
