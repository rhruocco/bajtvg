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
            Console.ForegroundColor = ConsoleColor.White;
            Console.SetWindowSize(Console.LargestWindowWidth*2/3, Console.LargestWindowHeight*2/3);
            Console.Title = "????? ? ????? ??? ????? ????";
            //Name prompt
            Console.WriteLine("What is your name...stranger?");
            String playerName = Console.ReadLine();
            Console.Clear();

            //Intro text dump
            Console.Write("The happy land of Grinanbear has never seen war.\n" +
                "It would be nothing more than a colossal waste of everybody's time, really.\n" +
                "For you see, the bodies that inhabit Grinanbear cannot be damaged by sword or firearm.\n" +
                "Everyone is, simply put: completley invincible.\n" +
                "One should not try to solve a quarrel with a fellow from Grinanbear with violence, for it would be fruitless.\n" +
                "But all was not well in Grinanbear when ");
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write(playerName);
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write(" was not payed the 20 coins they were owed from their mate Crooker.\n\nPress Enter to begin...");
            Console.ReadKey();

            ConsoleColor[] colors = {ConsoleColor.Black, ConsoleColor.DarkCyan, ConsoleColor.DarkMagenta, ConsoleColor.DarkYellow, ConsoleColor.Red, ConsoleColor.Blue, ConsoleColor.DarkGreen, ConsoleColor.DarkGray, ConsoleColor.Magenta};
            Console.BackgroundColor = ConsoleColor.White;
            Console.Clear();
            Console.Title = "BEING A JERK: THE VIDEO GAME";

            String spacer = "";
            for (int i = 0; i < colors.Length; i++)
            {
                Console.ForegroundColor = colors[i];
                Console.WriteLine(spacer+"BEING A JERK: THE VIDEO GAME\n");
                if (i >= colors.Length / 2)
                {
                    spacer += "\b";
                }
                else
                {
                    spacer += " ";
                }
            }

            Console.ForegroundColor = ConsoleColor.Black;
            Console.WriteLine("\nPress Enter to continue!");
            Console.ReadKey();

            Console.Clear();

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
                                      "When their HP hits 0, you've won! But if *your* you lose.\n\n" +
                                      "Battles in this game are Turn-Based. You decide what you want to do, then your opponent decides what to do.\n\n" +
                                      "Here are your options each turn:\n");
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.Write("[I] - Insult");
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.Write(" - Insults the enemy and reduces their HP. (unless they avoid it)\n");

                    Console.ForegroundColor = ConsoleColor.DarkCyan;
                    Console.Write("[P] - Plug Ears");
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.Write(" - Plugs your ears, reducing insult damage by half.\n");

                    Console.ForegroundColor = ConsoleColor.DarkBlue;
                    Console.Write("[S] - Use Sticker");
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.Write("- Use a sticker, recovering all HP. You start with 3 of them!\n" +
                                      "You can type the letter in brackets, or type out the full choice. But don't enter anything other than these options, or your character will be confused!\n\n" +
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