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
    }
}
