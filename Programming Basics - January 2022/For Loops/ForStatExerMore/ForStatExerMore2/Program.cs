using System;

namespace ForStatExerMore2
{
    class Program
    {
        static void Main(string[] args)
        {
            int surveyDays = int.Parse(Console.ReadLine());

            int doctorsAvailable = 7;
            int patientsAccepted = 0;
            int patientsTransferred = 0;

            for (int i = 1; i <= surveyDays; i++)
            {
                int patientsArriving = int.Parse(Console.ReadLine());
                int currentDay = i;

                if ((currentDay % 3 == 0) && (patientsTransferred > patientsAccepted))
                {
                    doctorsAvailable++;
                }

                if (patientsArriving <= doctorsAvailable)
                {
                    patientsAccepted += patientsArriving;
                }
                else
                {
                    patientsAccepted += doctorsAvailable;
                    patientsTransferred += patientsArriving - doctorsAvailable;
                }
            }

            Console.WriteLine($"Treated patients: {patientsAccepted}.");
            Console.WriteLine($"Untreated patients: {patientsTransferred}.");
        }
    }
}
