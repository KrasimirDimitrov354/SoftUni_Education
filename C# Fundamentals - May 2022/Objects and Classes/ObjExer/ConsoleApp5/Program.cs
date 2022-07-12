using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp5
{
    //Teamwork Projects
    //It's time for the teamwork projects and you are responsible for gathering the teams. First, you will receive an integer - the count of the teams you will have to register.
    //You will be given a user and a team, separated with "-".  The user is the creator of the team. For every newly created team you should print a message: 
    //  "Team {teamName} has been created by {user}!".
    //Next, you will receive а user with a team, separated with "->", which means that the user wants to join that team.
    //Upon receiving the command: "end of assignment", you should print every team, ordered by the count of its members (descending) and then by name (ascending).
    //For each team, you have to print its members sorted by name (ascending). However, there are several rules:
    //  •	If а user tries to create a team more than once, a message should be displayed: 
    //      -	"Team {teamName} was already created!"
    //  •	A creator of a team cannot create another team – the following message should be thrown: 
    //      -	"{user} cannot create another team!"
    //  •	If а user tries to join a non-existent team, a message should be displayed: 
    //      -	"Team {teamName} does not exist!"
    //  •	A member of a team cannot join another team – the following message should be thrown:
    //      -	"Member {user} cannot join team {team Name}!"
    //  •	In the end, teams with zero members (with only a creator) should disband and you have to print them ordered by name in ascending order.
    //  •   Note that when a user joins a team, you should first check if the team exists and then check if the user is already in a team.
    //  •	 Every valid team should be printed ordered by name (ascending) in the following format:
    //      "{teamName}
    //      - { creator}
    //      -- {member}…"
    //Examples
    //Input		                                                Comments
    //  2                                                       Tony created a team which he attempted to join later and this action resulted in throwing a certain message.
    //  John-PowerPuffsCoders                                   Since nobody else tried to join his team, the team had to disband.
    //  Tony-Tony is the best
    //  Peter->PowerPuffsCoders
    //  Tony->Tony is the best
    //  end of assignment
    //Output
    //  Team PowerPuffsCoders has been created by John!
    //  Team Tony is the best has been created by Tony!
    //  Member Tony cannot join team Tony is the best!
    //  PowerPuffsCoders
    //  - John
    //  -- Peter
    //  Teams to disband:
    //  Tony is the best
    //
    //Input                                                     Comments
    //  3                                                       Tanya has created CloneClub, then she tried to join a non-existent team and the concrete message was displayed.
    //  Tanya-CloneClub
    //  Helena-CloneClub
    //  Tedy-SoftUni
    //  George->softUni
    //  George->SoftUni
    //  Tatyana->Leda
    //  John->SoftUni
    //  Cossima->CloneClub
    //  end of assignment
    //Output
    //  Team CloneClub has been created by Tanya!
    //  Team CloneClub was already created!
    //  Team SoftUni has been created by Tedy!
    //  Team softUni does not exist!
    //  Team Leda does not exist!
    //  SoftUni
    //  - Tedy
    //  -- George
    //  -- John
    //  CloneClub
    //  - Tanya
    //  -- Cossima
    //  Teams to disband:

    class Team
    {
        public Team(string teamName, string teamLeader)
        {
            this.TeamName = teamName;
            this.TeamLeader = teamLeader;
            this.TeamMembers = new List<string>();
        }

        public string TeamName { get; set; }
        public string TeamLeader { get; set; }
        public List<string> TeamMembers { get; set; }
    }

    class Program
    {
        private static bool IsTryingToJoin(string command)
        {
            if (command[0] == '>')
            {
                return true;
            }

            return false;
        }

        private static bool UserNotInTeam(string user, List<Team> teams)
        {
            //Used by functions TryToJoinTeam and TryToCreateTeam

            for (int i = 0; i < teams.Count; i++)
            {
                Team currentTeam = teams[i];

                if (user == currentTeam.TeamLeader)
                {
                    return false;
                }
                else
                {
                    for (int j = 0; j < currentTeam.TeamMembers.Count; j++)
                    {
                        if (user == currentTeam.TeamMembers[j])
                        {
                            return false;
                        }
                    }
                }
            }

            return true;
        }

        private static void TryToJoinTeam(List<Team> teams, string teamName, string user)
        {
            for (int i = 0; i < teams.Count; i++)
            {
                Team currentTeam = teams[i];

                if (currentTeam.TeamName == teamName)
                {
                    bool notInTeam = UserNotInTeam(user, teams);

                    if (notInTeam)
                    {
                        currentTeam.TeamMembers.Add(user);
                    }
                    else
                    {
                        Console.WriteLine($"Member {user} cannot join team {teamName}!");
                    }

                    break;
                }

                if (i == teams.Count - 1) //Can only be reached if no team with the entered name exists
                {
                    Console.WriteLine($"Team {teamName} does not exist!");
                }
            }
        }

        private static bool TeamExists(List<Team> teams, string teamName)
        {
            //Used by function TryToCreateTeam

            for (int i = 0; i < teams.Count; i++)
            {
                string currentTeam = teams[i].TeamName;

                if (currentTeam == teamName)
                {
                    return true;
                }
            }

            return false;
        }

        private static void TryToCreateTeam(List<Team> teams, string teamName, string user)
        {
            bool teamExists = TeamExists(teams, teamName);

            if (teamExists)
            {
                Console.WriteLine($"Team {teamName} was already created!");
            }
            else
            {
                bool notInTeam = UserNotInTeam(user, teams);

                if (notInTeam)
                {
                    Console.WriteLine($"Team {teamName} has been created by {user}!");
                    Team newTeam = new Team(teamName, user);
                    teams.Add(newTeam);                    
                }
                else
                {
                    Console.WriteLine($"{user} cannot create another team!");
                }
            }
        }

        private static List<Team> SortTeams(List<Team> teams)
        {
            //Sorts teams alphabetically, then by count of team members.
            //Then sorts the list with team members alphabetically.

            teams.Sort((team1, team2) => team1.TeamName.CompareTo(team2.TeamName));

            List<Team> sortedTeams = teams.OrderByDescending(t => t.TeamMembers.Count).ToList();

            foreach (Team team in sortedTeams)
            {
                team.TeamMembers = team.TeamMembers.OrderBy(tm => tm).ToList();
            }

            return sortedTeams;
        }

        private static List<Team> SeparateEmptyTeams(List<Team> teams)
        {
            //Remove empty teams and place them in a new List, then sort them alphabetically

            List<Team> emptyTeams = new List<Team>();

            for (int i = 0; i < teams.Count; i++)
            {
                Team currentTeam = teams[i];

                if (currentTeam.TeamMembers.Count == 0)
                {
                    emptyTeams.Add(currentTeam);
                    teams.Remove(currentTeam);
                    i--;
                }
            }

            emptyTeams.Sort((team1, team2) => team1.TeamName.CompareTo(team2.TeamName));
            return emptyTeams;
        }

        private static void PrintTeamInfo(Team team)
        {
            Console.WriteLine(team.TeamName);
            Console.WriteLine($"- {team.TeamLeader}");

            List<string> teamMembers = team.TeamMembers;

            for (int j = 0; j < teamMembers.Count; j++)
            {
                Console.WriteLine($"-- {teamMembers[j]}");
            }
        }

        static void Main()
        {
            int teamsCount = int.Parse(Console.ReadLine());
            List<Team> teams = new List<Team>();

            while (true)
            {
                string input = Console.ReadLine();

                if (input == "end of assignment")
                {
                    List<Team> sortedTeams = SortTeams(teams);

                    for (int i = 0; i < sortedTeams.Count; i++)
                    {
                        Team currentTeam = sortedTeams[i];
                        if (currentTeam.TeamMembers.Count != 0)
                        {
                            PrintTeamInfo(currentTeam);
                        }
                    }

                    Console.WriteLine("Teams to disband:");
                    List<Team> emptyTeams = SeparateEmptyTeams(sortedTeams);

                    for (int i = 0; i < emptyTeams.Count; i++)
                    {
                        Console.WriteLine(emptyTeams[i].TeamName);
                    }

                    break;
                }
                else
                {
                    string[] command = input.Split('-').ToArray();
                    string user = command[0];
                    string teamName = command[1];

                    if (IsTryingToJoin(teamName))
                    {
                        teamName = teamName.Remove(0, 1);
                        TryToJoinTeam(teams, teamName, user);
                    }
                    else
                    {
                        //Task conditions mention nothing about what the initial integer for count of teams is used for.
                        //I assume that it means no more new teams can be created if the count of teams is reached.

                        if (teams.Count < teamsCount)
                        {
                            TryToCreateTeam(teams, teamName, user);
                        }
                    }
                }
            }
        }
    }
}
