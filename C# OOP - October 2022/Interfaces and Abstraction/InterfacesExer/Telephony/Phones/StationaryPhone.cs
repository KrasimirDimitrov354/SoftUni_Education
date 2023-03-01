using System;

namespace Telephony
{
    public class StationaryPhone : PhoneValidator, ICallable
    {
        public void InitiateCall(string number)
        {
            if (NumberValidation(number))
            {
                Console.WriteLine($"Dialing... {number}");
            }           
        }
    }
}
