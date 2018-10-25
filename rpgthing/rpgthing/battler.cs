using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rpgthing
{
    class battler
    {
        private String name, insult;
        private double level, hp, xp, maxhp;
        private Random rng = new Random();
        private int stickers = 3;
        private String[] adjectives = {"Stinky","Smelly","No-Good","Ramblin'","Evil","Strange","Foul-Smelling",
            "Three-Eyed","Angry","Funny","Questionable" };

        private String[] nouns = {"Creature","Lizard Boy","Bum","Goblin","Floating Head","Toupee","Fungus",
            "Salamander","Feline","Sentient Tree","Crow"};

        /*
        * Constructor for the battler class. Assigns the name, level and hp 
        */
        public battler(String n, double lvl, String insultt)
        {
            name = n;
            level = lvl;
            maxhp = lvl * 10;
            insult = insultt;
            hp = maxhp;
        }

        /*
         * Used to generate random numbers
         * Written with the help of: 
         * https://stackoverflow.com/questions/3602392/round-double-to-two-decimal-places
         * https://stackoverflow.com/questions/1064901/random-number-between-2-double-numbers
         */
        private double randomnumgen(double min, double max)
        {
            double num = rng.NextDouble();
            num *= min + (max - min);
            return Math.Round(num, Convert.ToInt32(2), MidpointRounding.AwayFromZero);
        }

        /*
         * Returns the level + a random amount as damage
         */
        public double attack()
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write(name);

            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.Write(" " + insult + "!\n");

            if (randomnumgen(0, 1) >= .90)
            {
                return 0;
            }
            else
            {
                return randomnumgen(-.1, .3) + level;
            }
        }

        /*
         * Subtracts the parameter 'damage' from the variable hp
         * https://stackoverflow.com/questions/3602392/round-double-to-two-decimal-places
         */
        public void receiveDamage(double dmg)
        {
            hp -= dmg;
            hp = Math.Round(hp, Convert.ToInt32(2), MidpointRounding.AwayFromZero);
        }

        /*
         * Returns the battler's health
         */
        public double getHealth()
        {
            return hp;
        }

        /*
         * Returns the battler's name
         */
        public String getName()
        {
            return name;
        }

        /*
         * Returns the battler's level
         */
        public double getLvl()
        {
            return level;
        }

        /*
         * Sets the battler's health to their max health. Called before every battle and when the player uses a sticker
         */
        public void healthRestore()
        {
            hp = maxhp;
        }

        /*
         * Calls healthRestore if stickers > 0 and increments the variable stickers. Called when the player uses a sticker
         */
        public void useSticker()
        {
            switch (stickers)
            {
                default:
                    stickers--;
                    healthRestore();

                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.Write(name);

                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                    Console.Write(" put a sticker on themself! ");

                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.Write(name);

                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                    Console.Write(" feels much better! HP restored!");
                    break;
     

                case 0:
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.Write(name);

                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write(" is out of stickers!");
                    break;
            }
        }

        /*
         * Randomly generates a name by picking random indexes in adjectives[] and nouns[] via a random object
         */
        public void randomName()
        {
            Random randomm = new Random();
            name = (adjectives[randomm.Next(0, adjectives.Length)] + " " + nouns[randomm.Next(0, nouns.Length)]);
        }

        /*
         * Returns how many stickers the battler has left
         */
        public int getStickers()
        {
            return stickers;
        }

        /*
         * Updates the private variable stickers with parameter newStickers
         */ 
         public void updateStickers(int newStickers)
        {
            stickers = newStickers;
        }

        /*
         * Gives the battler a random amount of expirience after they win a battle
         */
         public void giveXp(int exp)
        {
            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Clear();
            xp += exp;

            Console.Write(name);

            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.Write(" won!\n");

            Console.Write("\n"+name);

            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.Write(" gained " + exp + " exp!\n");
            
            if (xp >= 100)
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.Write("\n"+name.ToUpper());

                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.Write(" LEVELED UP!\n");

                Console.ForegroundColor = ConsoleColor.Black;
                Console.Write("\nLevel: "+level + " --> ");

                level++;
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.Write(level+"\n");

                Console.ForegroundColor = ConsoleColor.Black;
                Console.Write("\nHP: ");

                Console.Write(maxhp+" --> ");

                maxhp = level * 10;
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.Write(maxhp);
            }
            Console.ForegroundColor = ConsoleColor.Black;
            Console.WriteLine("\n\nPress Enter to Continue.");
            Console.ReadKey();
            Console.Clear();
        }
    }
}