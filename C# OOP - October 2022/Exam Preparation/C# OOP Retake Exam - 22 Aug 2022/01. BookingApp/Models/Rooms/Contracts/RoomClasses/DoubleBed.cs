namespace BookingApp.Models.Rooms.Contracts.RoomClasses
{
    public class DoubleBed : Room
    {
        private const int BED_CAPACITY = 2;

        public DoubleBed() : base(BED_CAPACITY)
        {
        }
    }
}
