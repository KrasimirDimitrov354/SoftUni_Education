using System;
using System.Collections.Generic;
using System.Linq;

namespace Stack_QueueExer7
{
    //Truck Tour
    //Suppose there is a circle. There are N petrol pumps on that circle. Petrol pumps are numbered 0 to (N−1), both inclusive.
    //You have two pieces of information corresponding to each of the petrol pumps:
    //  (1) the amount of petrol that particular petrol pump will give.
    //  (2) the distance from that petrol pump to the next petrol pump.
    //
    //Initially you have a tank of infinite capacity carrying no petrol. You can start the tour at any of the petrol pumps.
    //Calculate the first point from where the truck will be able to complete the circle. Consider that the truck will stop at each of the petrol pumps.
    //The truck will move one kilometer for each liter of petrol.
    //
    //Input
    //  •	The first line will contain the value of N.
    //  •	The next N lines will contain a pair of integers:
    //      -   The amount of petrol that petrol pump will give.
    //      -   The distance between that petrol pump and the next petrol pump.
    //Output
    //  •	An integer which will be the smallest index of the petrol pump from which we can start the tour.
    //Constraints
    //  •	1 ≤ N ≤ 1000001
    //  •	1 ≤ Amount of petrol, Distance ≤ 1000000000
    //
    //Examples
    //Input     Output
    //3         1
    //1 5
    //10 3
    //3 4
    //
    //Input     Output
    //8         0
    //10 1
    //10 1
    //10 1
    //6 6
    //6 6
    //6 15
    //10 5
    //6 12

    class PetrolPump
    {
        public PetrolPump(int availablePetrol, int distanceToNextPump, int pumpIndex)
        {
            this.AvailablePetrol = availablePetrol;
            this.DistanceToNextPump = distanceToNextPump;
            this.PumpIndex = pumpIndex;
        }

        public int AvailablePetrol { get; set; }
        public int DistanceToNextPump { get; set; }
        public int PumpIndex { get; set; }
    }

    class Program
    {
        static void Main()
        {
            int pumpsCount = int.Parse(Console.ReadLine());

            Queue<PetrolPump> queueOfPumps = new Queue<PetrolPump>();

            for (int i = 0; i < pumpsCount; i++)
            {
                int[] pumpRaw = Console.ReadLine()
                    .Split()
                    .Select(p => int.Parse(p))
                    .ToArray();

                PetrolPump petrolPump = new PetrolPump(pumpRaw[0], pumpRaw[1], i + 1);
                queueOfPumps.Enqueue(petrolPump);
            }

            bool startingPumpNotFound = true;
            int startingPumpIndex = 0;

            while (startingPumpNotFound)
            {
                //Бензиностанцията, която се взима за начална точка, се изважда от опашката с бензиностанции.
                //Нейната позиция в опашката се запазва в променливата indexOfCurrentPump.
                PetrolPump currentPump = queueOfPumps.Dequeue();

                int currentPetrol = currentPump.AvailablePetrol;
                int currentDistance = currentPump.DistanceToNextPump;

                //Ако наличният бензин в БЗНС (бензиностанцията) е по-малък в сравнение с разстоянието до следващата бензиностанция,
                //то сегашната БЗНС с добавя в края на опашката и се взима нова начална точка.
                if (currentPetrol < currentDistance)
                {
                    startingPumpIndex = currentPump.PumpIndex;
                    queueOfPumps.Enqueue(currentPump);
                }
                else
                {
                    //От наличният бензин се изважда разстоянието до следващата БЗНС. Числото винаги ще е положително или нула.
                    //Приема се че при резултат нула бензинът е стигнал точно колкото да покрие разстоянието.
                    currentPetrol -= currentDistance;

                    for (int i = queueOfPumps.Count - 1; i >= 0; i--)
                    {
                        PetrolPump pumpToCompare = queueOfPumps.Peek();

                        currentPetrol += pumpToCompare.AvailablePetrol;

                        //Ако сумата от останалият бензин след изминаване на разстоянието и наличният бензин в сегашната БЗНС е по-малък от разстоянието до следващата БЗНС,
                        //то сегашната начална точка с добавя в края на опашката и се взима нова начална точка.
                        //В противен случай, сегашната БЗНС се изважда от опашката и се добавя в края.
                        if (currentPetrol - pumpToCompare.DistanceToNextPump < 0)
                        {
                            startingPumpIndex = pumpToCompare.PumpIndex;
                            queueOfPumps.Enqueue(currentPump);
                            break;
                        }
                        else
                        {                            
                            currentPetrol -= pumpToCompare.DistanceToNextPump;
                            queueOfPumps.Dequeue();
                            queueOfPumps.Enqueue(pumpToCompare);
                        }

                        //i = 0 означава че всички бензиностанции са обходени успешно.
                        if (i == 0)
                        {
                            startingPumpNotFound = false;
                        }
                    }
                }
            }

            Console.WriteLine(startingPumpIndex);
        }
    }
}
