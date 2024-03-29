﻿using System;

using BookingApp.Utilities.Messages;

namespace BookingApp.Models.Rooms.Contracts
{
    public abstract class Room : IRoom
    {
        private double pricePerNight = 0;

        public Room(int bedCapacity)
        {
            BedCapacity = bedCapacity;
        }

        public int BedCapacity { get; private set; }

        public double PricePerNight
        {
            get { return pricePerNight; }
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException(ExceptionMessages.PricePerNightNegative);
                }

                pricePerNight = value;
            }
        }

        public void SetPrice(double price)
        {
            PricePerNight = price;
        }
    }
}
