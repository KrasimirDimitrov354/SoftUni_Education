using System;
using System.Collections.Generic;
using System.Text;

namespace Vehicles
{
    public interface IVehicle
    {
        void Drive(double distance);
        void Refuel(double quantity);
    }
}
