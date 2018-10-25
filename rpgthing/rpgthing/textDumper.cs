using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rpgthing
{
    /*
     * Prints out story stuff, decisions, and other stuff like that
     */
    class textDumper
    {
        /*
         * Constructor for the textDumper class
         */
        public textDumper()
        {

        }

        /*
         * Prints the intro text, and returns a name for the player
         */
        public string intro()
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.SetWindowSize(Console.LargestWindowWidth * 2 / 3, Console.LargestWindowHeight * 2 / 3);
            Console.Title = "????? ? ????? ??? ????? ????";

            //Name prompt
            Console.WriteLine("What is your name...stranger?");

            string name = Console.ReadLine();
            Console.Clear();

            //Intro text dump
            Console.Write("The happy land of Grinanbear has never seen war.\n" +
                "It would be nothing more than a colossal waste of everybody's time, really.\n" +
                "For you see, the bodies that inhabit Grinanbear cannot be damaged by sword or firearm.\n" +
                "Everyone is, simply put: completley invincible.\n" +
                "One should not try to solve a quarrel with a fellow from Grinanbear with violence, for it would be fruitless.\n" +
                "But all was not well in Grinanbear when ");
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write(name);
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write(" was not payed the 20 coins they were owed from their mate Crooker.\n\nPress Enter to begin...");
            Console.ReadKey();

            ConsoleColor[] colors = { ConsoleColor.Black, ConsoleColor.DarkCyan, ConsoleColor.DarkMagenta, ConsoleColor.DarkYellow, ConsoleColor.Red, ConsoleColor.Blue, ConsoleColor.DarkGreen, ConsoleColor.DarkGray, ConsoleColor.Magenta };
            Console.BackgroundColor = ConsoleColor.White;
            Console.Clear();
            Console.Title = "BEING A JERK: THE VIDEO GAME";

            String spacer = "";
            for (int i = 0; i < colors.Length; i++)
            {
                Console.ForegroundColor = colors[i];
                Console.WriteLine(spacer + "BEING A JERK: THE VIDEO GAME\n");
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
            return name;
        }

        /*
         * Prints out the how-to-play info of the game
         */
        public void howToPlay()
        {
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
                              "You can type the letter in brackets, or type out the full choice. But don't enter anything other than these options," +
                              "\nor your character will be confused!\n\n" +
                              "PRESS ENTER WHEN READY!");
            Console.ReadKey();
        }

        /*
         * Prints out the story before the first fight
         */
        public void firstEncounter(string name)
        {
            Console.ForegroundColor = ConsoleColor.Black;
            Console.WriteLine("{0} began their journey by leaving their home.\n" +
                 "{0} allowed Crooker the usual time to pay someone back: 8 days, 6 hours.\n" +
                "But Crooker had a lot of connections in Grinanbear.\n" +
                "And as {0} was gallantly walking to confront their once friend,\n" +
                "they could feel a pair of eyes glaring into them.\n" +
                "One of Crooker's connections was about to 'connect' to {0}.", name);

            Console.WriteLine("\nPress Enter to continue...");
            Console.ReadKey();
        }

        /*
         * Prints out the story before the second fight 
         */
        public void secondEncounter(string name, string enemyName)
        {
            Console.ForegroundColor = ConsoleColor.Black;
            Console.WriteLine("After watching the {1} slink away, {0} confidantly resumed his journey.\n" +
                "But what {0} didn't notice was where {1} was slinking away to.\n" +
                "After several hours of walking, the {1} was a distant memory for {0}.\n" +
                "But that memory was forcefully recalled when {0} met {1}'s friend...\n", name, enemyName);

            Console.WriteLine("\nPress Enter to continue...");
            Console.ReadKey();
        }

        /*
         * Handles the Old Man branching path. Returns a battler for the third encounter
         */
        public battler oldManBranch(string name, string enemyName)
        {
            Console.ForegroundColor = ConsoleColor.Black;
            Console.WriteLine("After making quick work of the {1}, {0} moved on, into the countryside.\n" +
                "After trudging through miles and miles of corn, {0} came upon a fork." +
                "To the left, a winding and dark pathway that ended very close to Crooker's.\n" +
                "To the right, a sunny and peaceful dirt road that lead to an out-of-the-way farm.\n" +
                "The left would surely yield more battles, but would get {0} right where they needed to go.\n" +
                "The right is a much more peaceful path, but it might take just a bit longer to get to Crooker.\n"
                "\n\nWhich way will {0} go?!\n", name, enemyName);

            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("[L] - Left (Dark Path)\n");

            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write("[R] - Right (Peaceful Farm)");

            battler enemy;

            switch (Console.ReadLine().ToLower())
            {
                case "left":
                case "l":
                case "dark path":
                case "path":
                    enemy = darkPath(name);
                    break;
                case "right":
                case "r":
                case "peaceful farm":
                case "farm":
                    enemy = farm(name);
                    break;

                default:
                    Console.ForegroundColor = ConsoleColor.DarkMagenta;
                    Console.WriteLine("{0} couldn't make a choice and decided to flip a coin!", name);
                    Random coinflipper = new Random();
                    int coinToss = coinflipper.Next(0, 101);

                    if (coinToss <= 49)
                    {
                        Console.WriteLine("Heads! Time to the farm!\n");
                        Console.ForegroundColor = ConsoleColor.Black;

                        Console.WriteLine("Press Enter to continue");
                        Console.ReadKey();
                        goto case "farm";
                    }
                    else
                    {
                        Console.WriteLine("Tails! Tails means trail!");
                        Console.ForegroundColor = ConsoleColor.Black;

                        Console.WriteLine("Press Enter to continue");
                        Console.ReadKey();
                        goto case "path";
                    }
            }
            return enemy;
        }

        /*
         * Called if the player chooses to go to the farm
         */ 
         public battler farm(string name)
        {
            Console.BackgroundColor = ConsoleColor.DarkYellow;
            Console.ForegroundColor = ConsoleColor.Blue;

            Console.Clear();

            Console.Write("After strolling down the dirt road to the farm, {0} spotted a wooden cabin with an old man with a straw hat out front.\n"+
                "As {0} approached, the old man smiled warmly.\n"+
                "The old man offers {0} supper and a room for the night on one teeny condition.\n"+
                "The old man simply wanted someone to listen to a story the old man had been itching to tell for a while.\n"+
                "{0} agrees, looking forward to the food and room much more than the story.\n", name);

            Console.ForegroundColor = ConsoleColor.Black;
            Console.WriteLine("\nPress Enter to hear the old man's story.");
            Console.ReadKey();
        }
    }
}