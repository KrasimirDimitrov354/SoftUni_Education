using System.Collections.Generic;

using BookingApp.Models.Rooms.Contracts;

namespace BookingApp.Repositories.Contracts
{
    public class RoomRepository : IRepository<IRoom>
    {
        private List<IRoom> rooms;

        public RoomRepository()
        {
            rooms = new List<IRoom>();
        }

        public void AddNew(IRoom room)
        {
            rooms.Add(room);
        }

        public IRoom Select(string roomTypeName)
        {
            return rooms.Find(r => r.GetType().Name == roomTypeName);
        }

        public IReadOnlyCollection<IRoom> All()
        {
            return rooms.AsReadOnly();
        }
    }
}
