using System;

using BookingApp.IO.Contracts;

namespace BookingApp.IO
{
    public class Reader : IReader
    {
        public string ReadLine()
        {
            return Console.ReadLine();
        }
    }
}
