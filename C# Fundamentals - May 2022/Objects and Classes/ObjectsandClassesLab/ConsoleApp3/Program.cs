using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp3
{
    class Program
    {
        //Songs
        //Define a class called Song that will hold the following information about some songs:
        //  •	Type List
        //  •	Name
        //  •	Time
        //Input / Constraints
        //  •	On the first line, you will receive the number of songs - N.
        //  •	On the next N lines, you will be receiving data in the following format:  "{typeList}_{name}_{time}"
        //  •	On the last line, you will receive Type List or "all".
        //Output
        //If you receive Type List as an input on the last line, print out only the names of the songs which are from that Type List.
        //If you receive the "all" command, print out the names of all the songs.
        //Examples
        //Input                             Output
        //3                                 DownTown
        //favourite_DownTown_3:14           Kiss
        //favourite_Kiss_4:16               Smooth Criminal
        //favourite_Smooth Criminal_4:01
        //favourite
        //
        //Input                             Output
        //4                                 Andalouse
        //favourite_DownTown_3:14
        //listenLater_Andalouse_3:24
        //favourite_In To The Night_3:58
        //favourite_Live It Up_3:48
        //listenLater
        //
        //Input                             Output
        //2                                 Replay
        //like_Replay_3:15                  Photoshop
        //ban_Photoshop_3:48
        //all

        private class Song
        {
            public string Type { get; set; }
            public string Name { get; set; }
            public string Time { get; set; }

            public void Print(string name)
            {
                Console.WriteLine(name);
            }

        }

        static void Main()
        {
            int songsCount = int.Parse(Console.ReadLine());
            List<Song> songs = new List<Song>();

            for (int i = 0; i < songsCount; i++)
            {
                List<string> songInfo = Console.ReadLine()
                    .Split('_')
                    .ToList();

                string type = songInfo[0];
                string name = songInfo[1];
                string time = songInfo[2];

                Song song = new Song();
                song.Type = type;
                song.Name = name;
                song.Time = time;

                songs.Add(song);
            }

            string command = Console.ReadLine();

            if (command == "all")
            {
                foreach (Song song in songs)
                {
                    song.Print(song.Name);
                }
            }
            else
            {
                foreach (Song song in songs)
                {
                    if (song.Type == command)
                    {
                        song.Print(song.Name);
                    }
                }
            }
        }
    }
}
