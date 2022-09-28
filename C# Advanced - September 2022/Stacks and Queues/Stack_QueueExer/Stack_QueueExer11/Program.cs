using System;
using System.Collections.Generic;
using System.Linq;

namespace Stack_QueueExer11
{
    //Key Revolver
    //Our agent is given a special weapon called the Key Revolver, which has special bullets to open locks.
    //Each bullet can unlock a lock with a size equal to or larger than the size of the bullet. The bullet goes into the keyhole then explodes, destroying it.
    //The agent doesn’t know the size of the locks, so he needs to just shoot at all of them until the safe run out of locks.
    //The intelligence hidden inside is valued differently across different times of the year, so the agent will be told what it’s worth over the radio.
    //One last thing - every bullet fired costs money, which will be deducted from the agent's pay.
    //Good luck, operative.
    //
    //After the agent receives all of his information and gear (input), he starts to shoot the locks front-to-back while going through the bullets back-to-front.
    //If the bullet has a smaller or equal size to the current lock, print "Bang!" then remove the lock.
    //If not, print "Ping!" and leave the lock intact. The bullet is removed in both cases.
    //
    //If the agent runs out of bullets in his gun, print "Reloading!" and then continue shooting. If there aren’t any bullets left, print nothing.
    //The program ends when the agent either runs out of bullets or the safe runs out of locks.
    //
    //Input
    //  •	On the first line of input you will receive the price of each bullet – an integer in the range [0-100].
    //  •	On the second line you will receive the size of the pistol's clip – an integer in the range [1-5000].
    //  •	On the third line you will receive the bullets – a space-separated integer sequence with [1-100] integers.
    //  •	On the fourth line you will receive the locks – a space-separated integer sequence with [1-100] integers.
    //  •	On the fifth line you will receive the value of the intelligence – an integer in the range [1-100000].
    //Output
    //  •	If the agent runs out of bullets before the safe runs out of locks, print:
    //      "Couldn't get through. Locks left: {locksLeft}"
    //  •	If the agent manages to open the safe, print:
    //      "{bulletsLeft} bullets left. Earned ${moneyEarned}"
    //      Make sure to account for the price of the bullets when calculating the money earned.
    //Constraints
    //  •	The input will be within the constraints specified above and will always be valid. There is no need to check it explicitly.
    //  •	There will never be a case where the agent breaks the lock and ends up with а negative balance.
    //
    //Examples
    //Input                 Output                                  Comments
    //50                    Ping!                                   20 shoots lock 15 (ping)
    //2                     Bang!                                   10 shoots lock 15 (bang)
    //11 10 5 11 10 20      Reloading!                              11 shoots lock 13 (bang)
    //15 13 16              Bang!                                   5 shoots lock 16 (bang)
    //1500                  Bang!                                   Bullet cost: 4 * 50 = $200
    //                      Reloading!                              Earned: 1500 – 200 = $1300
    //                      2 bullets left. Earned $1300
    //
    //Input                 Output                                  Comments
    //20                    Bang!                                   5 shoots lock 13 (bang)
    //6                     Ping!                                   10 shoots lock 3 (ping)
    //14 13 12 11 10 5      Ping!                                   11 shoots lock 3 (ping)
    //13 3 11 10            Ping!                                   12 shoots lock 3 (ping)
    //800                   Ping!                                   13 shoots lock 3 (ping)
    //                      Ping!                                   14 shoots lock 3 (ping)
    //                      Couldn't get through. Locks left: 3
    //
    //Input                 Output                                  Comments
    //33                    Bang!                                   10 shoots lock 10 (bang)
    //1                     Reloading!                              11 shoots lock 20 (bang)
    //12 11 10              Bang!                                   12 shoots lock 30 (bang)
    //10 20 30              Reloading!                              Bullet cost: 3 * 33 = $99
    //100                   Bang!                                   Earned: 100 – 99 = $1
    //                      0 bullets left. Earned $1

    class Program
    {
        static void Main()
        {
            int bulletPrice = int.Parse(Console.ReadLine());
            int pistolMagazine = int.Parse(Console.ReadLine());
            int bulletsInMagazine = pistolMagazine;

            Stack<int> stackOfBullets = new Stack<int>(Console.ReadLine()
                .Split()
                .Select(b => int.Parse(b))
                .ToList());

            int originalCountBullets = stackOfBullets.Count;

            Queue<int> queueOfLocks = new Queue<int>(Console.ReadLine()
                .Split()
                .Select(q => int.Parse(q))
                .ToList());

            int intelPrice = int.Parse(Console.ReadLine());

            while (true)
            {
                if (queueOfLocks.Count == 0)
                {
                    int bulletsUsed = originalCountBullets - stackOfBullets.Count;

                    Console.WriteLine($"{stackOfBullets.Count} bullets left. Earned ${intelPrice - (bulletsUsed * bulletPrice)}");
                    break;
                }
                else if (stackOfBullets.Count == 0)
                {
                    Console.WriteLine($"Couldn't get through. Locks left: {queueOfLocks.Count}");
                    break;
                }
                else
                {
                    int currentBullet = stackOfBullets.Pop();
                    int currentLock = queueOfLocks.Peek();

                    if (currentBullet <= currentLock)
                    {
                        Console.WriteLine("Bang!");
                        queueOfLocks.Dequeue();
                    }
                    else
                    {
                        Console.WriteLine("Ping!");
                    }

                    bulletsInMagazine--;

                    if (bulletsInMagazine == 0 && stackOfBullets.Count > 0)
                    {
                        Console.WriteLine("Reloading!");
                        bulletsInMagazine = pistolMagazine;
                    }
                }
            }
        }
    }
}
