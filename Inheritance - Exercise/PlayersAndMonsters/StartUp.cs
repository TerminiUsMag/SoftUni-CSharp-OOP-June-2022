using System;

namespace PlayersAndMonsters
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            var bladeKnight = new BladeKnight("TerminiUsMag", 99);
            System.Console.WriteLine(bladeKnight);
        }
    }
}