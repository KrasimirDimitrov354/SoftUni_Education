using System;
using PlayersAndMonsters.Knight;
using PlayersAndMonsters.Elf;
using PlayersAndMonsters.Wizard;

namespace PlayersAndMonsters
{
    public class StartUp
    {
        //Players and Monsters
        //Create a class Hero. It should contain the following:
        //  •	A constructor which accepts:
        //      o username – string
        //      o   level – int
        //  •	The properties:
        //      o Username - string
        //      o   Level – int
        //  •	ToString() method that returns "Type: {GetType().Name} Username: {Username} Level: {Level}"
        //
        //Create the following hierarchy of classes that inherit the class Hero:
        //  •	Elf -> MuseElf
        //  •	Wizard -> DarkWizard -> SoulMaster
        //  •	Knight -> DarkKnight -> BladeKnight

        public static void Main()
        {
            BladeKnight blade = new BladeKnight("Blade", 117);
            MuseElf muse = new MuseElf("Muse", 600);
            SoulMaster master = new SoulMaster("Master", 1);

            Console.WriteLine(blade.ToString());
            Console.WriteLine(muse.ToString());
            Console.WriteLine(master.ToString());
        }
    }
}