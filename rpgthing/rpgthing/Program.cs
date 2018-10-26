using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rpgthing
{
    class Program
    {
        /*
         * Creates the battlemanager and the two battlers, and uses player input for one of the battlers' name
         */
        static void Main()
        {
            textDumper textDump = new textDumper();

            battler player = new battler(textDump.intro(), 1, "says something hurtful");

            Console.WriteLine("Wanna hear how to play this here game? Y/N");
            switch (Console.ReadLine().ToLower())
            {
                case "y":
                case "yes":
                    textDump.howToPlay();
                    break;
            }

            Console.Clear();

            textDump.firstEncounter(player.getName());

            battler firstEnemy = new battler("", 1, "makes a rude comment");
            firstEnemy.randomName();

            battlemanager firstBattle = new battlemanager(player, firstEnemy);
            player = firstBattle.battle();

            textDump.secondEncounter(player.getName(), firstEnemy.getName());

            battler secondEnemy = new battler("", 1, " says something mean");
            secondEnemy.randomName();

            battlemanager secondBattle = new battlemanager(player, secondEnemy);

            player = secondBattle.battle();

            battlemanager thirdBattle = new battlemanager(player, textDump.oldManBranch(player.getName(), secondEnemy.getName()));
            player = thirdBattle.battle();
        }
    }
}