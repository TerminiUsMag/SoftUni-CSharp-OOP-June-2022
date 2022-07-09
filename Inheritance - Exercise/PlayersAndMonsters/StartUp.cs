using System;

namespace PlayersAndMonsters
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            var hero = new Hero("Hero", 1);
            var knight = new Knight("Knight", 1);
            var dk = new DarkKnight("DarkKnight", 1);
            var bk = new BladeKnight("BladeKnight", 1);
            var elf = new Elf("Elf", 1);
            var me = new MuseElf("MuseElf", 1);
            var wizard = new Wizard("Wizard", 1);
            var dw = new DarkWizard("DarkWizard", 1);
            var sm = new SoulMaster("SoulMaster", 1);

            Console.WriteLine(hero);
            Console.WriteLine(knight);
            Console.WriteLine(dk);
            Console.WriteLine(bk);
            Console.WriteLine(elf);
            Console.WriteLine(me);
            Console.WriteLine(wizard);
            Console.WriteLine(dw);
            Console.WriteLine(sm);
            Console.WriteLine("\n\n\n\n");
            Console.WriteLine("Battle between : Dark Knight & Soul Master ");
            while (dk.isDead == false && dw.isDead == false)
            {
                var rand = new Random();
                if (rand.Next(1,101) > 50)
                {
                    dk.Attack(dw);
                }
                else
                {
                    dw.Attack(dk);
                }
            }



        }
    }
}