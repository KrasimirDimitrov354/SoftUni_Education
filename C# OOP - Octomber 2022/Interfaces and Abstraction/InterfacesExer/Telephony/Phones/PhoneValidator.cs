using System;
using System.Text.RegularExpressions;

namespace Telephony
{
    public class PhoneValidator
    {
        private const string NUM_PATTERN = @"^[0-9]+$";
        private const string SITE_PATTERN = @"^[^0-9]+$";

        protected bool NumberValidation(string number)
        {
            if (Regex.IsMatch(number, NUM_PATTERN))
            {
                return true;
            }
            else
            {
                Console.WriteLine("Invalid number!");
                return false;
            }
        }

        protected bool SiteValidation(string site)
        {
            if (Regex.IsMatch(site, SITE_PATTERN))
            {
                return true;
            }
            else
            {
                Console.WriteLine("Invalid URL!");
                return false;
            }
        }
    }
}
