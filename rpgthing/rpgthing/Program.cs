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

            string playerName = textDump.intro();

            //How to play
            Console.WriteLine("Wanna hear how to play this here game? Y/N");
            switch (Console.ReadLine().ToLower())
            {
                case "y":
                case "yes":
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.Write("In this game, you insult people until they get discouraged and go away.\n" +
                                      "How discouraged an enemy is is represented by their HP. (Happy Points)\n" +
                                      "When their HP hits 0, you've won! But when *your* HP hits 0, you've lost.\n\n" +
                                      "Battles in this game are Turn-Based. You decide what you want to do, then your opponent decides what to do.\n\n" +
                                      "Here are your options each turn:\n");
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.Write("[I] - Insult");
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.Write(" - Insults the enemy and reduces their HP. (unless they avoid it)\n");

                    Console.ForegroundColor = ConsoleColor.DarkCyan;
                    Console.Write("[P] - Plug Ears");
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.Write(" - Plugs your ears, reducing insult damage." +
                        "\nThere's also a random chance that your opponent will take damage from the awkawardness of your silence!");

                    Console.ForegroundColor = ConsoleColor.DarkBlue;
                    Console.Write("[S] - Use Sticker");
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.Write(" - Use a sticker, recovering all HP. You start with 3 of them!\n" +
                                      "You can type the letter in brackets, or type out the full choice. But don't enter anything other than these options,"+
                                      "\nor your character will be confused!\n\n" +
                                      "PRESS ENTER WHEN READY!");
                    Console.ReadLine();
                    break;

                default:
                    break;
            }
            Console.Clear();
            //Player creation
            battler player = new battler(playerName, 1, "says something hurtful");
            //first fight (WIP)
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine(player.getName() + "began their journey by leaving their home.\n"+
                player.getName()+" allowed Crooker the usual time to pay someone back: 8 days, 6 hours.\n"+
                "But Crooker had a lot of connections in Grinanbear.\n"+
                "And as "+player.getName() + "was gallantly walking to confront their once friend,\n"+
                "they could feel a pair of eyes glaring into them.\n"+
                "One of Crooker's connections was about to 'connect' to "+player.getName()+".");

            Console.ForegroundColor = ConsoleColor.Black;
            Console.WriteLine("\nPress Enter to continue...");
            ConsoleKeyInfo input = Console.ReadKey();
            switch (input.Key)
            {
                default:

                    battler computer = new battler("", 1, "makes a rude comment");
                    computer.randomName();

                    battlemanager firstFight = new battlemanager(player, computer);
                    firstFight.battle();
                    break;
            }

            Console.WriteLine("Story event too!");
            Console.ReadKey();
        }
    }
}