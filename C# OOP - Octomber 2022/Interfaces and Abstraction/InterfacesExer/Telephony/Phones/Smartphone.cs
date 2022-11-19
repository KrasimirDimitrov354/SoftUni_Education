using System;

namespace Telephony
{
    public class Smartphone : PhoneValidator, ICallable
    {
        public void InitiateCall(string number)
        {
            if (NumberValidation(number))
            {
                Console.WriteLine($"Calling... {number}");
            }         
        }

        public void Browse(string site)
        {
            if (SiteValidation(site))
            {
                Console.WriteLine($"Browsing: {site}!");
            }           
        }
    }
}
