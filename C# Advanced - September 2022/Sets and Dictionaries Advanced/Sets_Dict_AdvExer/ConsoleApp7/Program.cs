using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp7
{
    //The V-Logger
    //Create a program that keeps the information about vloggers and their followers.
    //
    //The input will come as a sequence of strings, where each string will represent a valid command. The commands will be presented in the following format:
    //  •	"{vloggername} joined The V-Logger" – keep the vlogger in your records.
    //          o Vloggernames consist of only one word.
    //          o If the given vloggername already exists, ignore that command.
    //  •	"{vloggername} followed {vloggername}" – The first vlogger followed the second vlogger.
    //          o If any of the given vlogernames does not exist in your collection, ignore that command.
    //          o Vloggers cannot follow themselves.
    //          o Vloggers cannot follow someone they are already a follower of.
    //  •	"Statistics" - Upon receiving this command, you have to print a statistic about the vloggers.
    //
    //Each vlogger has a unique vloggername. Vloggers can follow other vloggers and a vlogger can follow as many other vloggers as he/she wants.
    //A vlogger cannot follow themselves or follow someone he/she is already a follower of.
    //
    //You need to print the total count of vloggers in your collection. Then you have to print the most famous vlogger – the one with the most followers, with his/her followers.
    //If more than one vloggers have the same number of followers, print the one following fewer people.
    //His/her followers should be printed in lexicographical order. In case the vlogger has no followers, print just the first line which is described below.
    //
    //Finally, print the rest of the vloggers ordered by the count of followers in descending order, then by the number of vloggers he/she follows in ascending order.
    //
    //The whole output must be in the following format:
    //  "The V-Logger has a total of {registered vloggers} vloggers in its logs.
    //  1. {mostFamousVlogger} : {followers} followers, {followings} following
    //  *  {follower1}
    //  *  {follower2} … 
    //  {No}. {vlogger} : {followers} followers, {followings} following
    //  {No}. {vlogger} : {followers} followers, {followings} following…"
    //
    //Input
    //  •	The input will come in the format described above.
    //Output
    //  •	On the first line print the total count of vloggers in the format described above.
    //  •	On the second line print the most famous vlogger in the format described above.
    //  •	On the next lines print all of the rest vloggers in the format described above.
    //Constraints
    //  •	There will be no invalid input.
    //  •	There will be no situation where two vloggers have an equal count of followers and equal count of followings.
    //  •	Allowed time/memory: 100ms / 16MB.
    //
    //Examples
    //Input                                     Output
    //EmilConrad joined The V-Logger            The V-Logger has a total of 3 vloggers in its logs.
    //VenomTheDoctor joined The V-Logger        1. VenomTheDoctor : 2 followers, 0 following
    //Saffrona joined The V-Logger              * EmilConrad
    //Saffrona followed EmilConrad              * Saffrona
    //Saffrona followed VenomTheDoctor          2. EmilConrad : 1 followers, 1 following
    //EmilConrad followed VenomTheDoctor        3. Saffrona : 0 followers, 2 following
    //VenomTheDoctor followed VenomTheDoctor
    //Saffrona followed EmilConrad
    //Statistics
    //
    //Input                                     Output
    //JennaMarbles joined The V-Logger          The V-Logger has a total of 5 vloggers in its logs.
    //JennaMarbles followed Zoella              1. AmazingPhil : 2 followers, 0 following
    //AmazingPhil joined The V-Logger           * JennaMarbles
    //JennaMarbles followed AmazingPhil         * Zoella
    //Zoella joined The V-Logger                2. Zoella : 1 followers, 1 following
    //JennaMarbles followed Zoella              3. JennaMarbles : 1 followers, 2 following
    //Zoella followed AmazingPhil               4. PewDiePie : 0 followers, 0 following
    //Christy followed Zoella                   5. JacksGap : 0 followers, 1 following
    //Zoella followed Christy
    //JacksGap joined The V-Logger
    //JacksGap followed JennaMarbles
    //PewDiePie joined The V-Logger
    //Zoella joined The V-Logger
    //Statistics

    class VloggerInfo
    {
        public VloggerInfo(List<string> followers, int followingCount)
        {
            this.Followers = followers;
            this.FollowingCount = followingCount;
        }

        public List<string> Followers { get; set; }
        public int FollowingCount { get; set; }
    }

    class Program
    {
        static void Main()
        {
            Dictionary<string, VloggerInfo> v_Logger = new Dictionary<string, VloggerInfo>();

            string[] command = Console.ReadLine().Split();

            while (command[0] != "Statistics")
            {
                switch (command[1])
                {
                    case "joined":
                        string vloggerName = command[0];

                        if (!v_Logger.ContainsKey(vloggerName))
                        {
                            v_Logger.Add(vloggerName, new VloggerInfo(new List<string>(), 0));
                        }

                        break;
                    case "followed":
                        string beingFollowed = command[2];
                        string follower = command[0];

                        if (beingFollowed != follower)
                        {
                            if (v_Logger.ContainsKey(beingFollowed) && v_Logger.ContainsKey(follower))
                            {
                                if (!v_Logger[beingFollowed].Followers.Contains(follower))
                                {
                                    v_Logger[beingFollowed].Followers.Add(follower);
                                    v_Logger[follower].FollowingCount++;
                                }
                            }
                        }

                        break;
                }

                command = Console.ReadLine().Split();
            }

            v_Logger = v_Logger
                .OrderByDescending(v => v.Value.Followers.Count)
                .ThenBy(v => v.Value.FollowingCount)
                .ToDictionary(v => v.Key, v => v.Value);

            Console.WriteLine($"The V-Logger has a total of {v_Logger.Count} vloggers in its logs.");

            byte counter = 1;

            foreach (var vLogger in v_Logger)
            {
                Console.WriteLine($"{counter}. {vLogger.Key} : {vLogger.Value.Followers.Count} followers, {vLogger.Value.FollowingCount} following");

                if (counter == 1)
                {
                    vLogger.Value.Followers = vLogger.Value.Followers
                    .OrderBy(f => f)
                    .ToList();

                    foreach (string follower in vLogger.Value.Followers)
                    {
                        Console.WriteLine($"*  {follower}");
                    }
                }                

                counter++;
            }
        }
    }
}
