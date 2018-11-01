using System;

namespace rpgthing
{
    /*
     * Executes a fight between two fighters, one user-controlled
     */
    class battlemanager
    {
        private battler player, foe;
        private String input;
        private Random rng = new Random();
        private int initStickers;

        private String[] missDialogues = {"screws up the delivery","stutters", "forgets what to say",
            "uses a word wrong", "says something unintentionally funny" };
        private String[] entryDialogues = { "draws near", "lurches forward", "is rarin' to fight", "won't back down", "must be stopped", "wants to duel", "will fight tooth and nail" };

        /*
         * Constructor for the battlemanager class. Defines the player controlled battler and their opponent, as well as the amount of stickers the player has coming into the fight
         */
        public battlemanager(battler p, battler f)
        {
            player = p;
            foe = f;
            initStickers = player.getStickers();
        }

        /*
         * Called if the player loses. Asks the user if they want to retry the fight. Made with:
         * https://stackoverflow.com/questions/5682408/command-to-close-an-application-of-console
         */
        public void retry()
        {
            Console.BackgroundColor = ConsoleColor.Black;
            Console.Clear();

            Console.ForegroundColor = ConsoleColor.Yellow;

            Console.WriteLine(player.getName() + " is too insulted to go on!" +
                "\nWould you like to retry? Y/N");
            String inpt = Console.ReadLine();
            switch (inpt.ToLower())
            {
                case "yes":
                case "y":
                    player.updateStickers(initStickers);
                    battle();
                    break;

                default:
                    Console.WriteLine("Are you sure YOU WANT TO QUIT? Y/N");
                    inpt = Console.ReadLine().ToLower();

                    if (inpt == "n" || inpt == "no")
                    {
                        goto case "yes";
                    }
                    else
                    {
                        Environment.Exit(0);
                    }
                    break;
            }
        }

        /*
         * Prints the battler's name, health and level
         */
         public void printBattler(battler b)
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine(b.getName());

            Console.ForegroundColor = ConsoleColor.Black;
            Console.Write("\nHP: ");

            if (b.getHealth() > 5.5)
            {
                Console.ForegroundColor = ConsoleColor.DarkGreen;
            }
            else if (b.getHealth() < 5.5 && b.getHealth() > 3)
            {
                Console.ForegroundColor = ConsoleColor.DarkYellow;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
            }  
            Console.Write(b.getHealth());

            Console.ForegroundColor = ConsoleColor.Black;
            Console.Write("   Lvl: ");
            Console.ForegroundColor = ConsoleColor.DarkMagenta;

            Console.Write(b.getLvl()+"\n");
        }

        /*
         * Called when a battler attacks
         */
        private void hit(battler giver, battler receiver, bool plugging)
        {
            double damage = giver.attack();
            double silenceDmg = 0;

            if (plugging)
            {
                if (rng.Next(0, 101) < 44)
                {
                    silenceDmg = foe.getLvl() + (rng.NextDouble() * (-.3 + (.4 - -.3)));
                    silenceDmg = Math.Round(silenceDmg, Convert.ToInt32(2), MidpointRounding.AwayFromZero);
                }
                damage /= 2;
            }

            receiver.receiveDamage(damage);

            switch (damage)
            {
                case 0:
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.Write("\t" + giver.getName());

                    Console.ForegroundColor = ConsoleColor.Magenta;
                    Console.Write( " " + missDialogues[rng.Next(0, missDialogues.Length)] + "! Insult failed!");
                    break;

                default:
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.Write("\t" + receiver.getName());

                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write(" takes " + damage + " damage!");

                    if (silenceDmg > 0)
                    {
                        giver.receiveDamage(silenceDmg);

                        Console.ForegroundColor = ConsoleColor.Magenta;
                        Console.Write("\nThe silence is too awkward for ");

                        Console.ForegroundColor = ConsoleColor.Blue;
                        Console.Write(giver.getName());

                        Console.ForegroundColor = ConsoleColor.Magenta;
                        Console.Write("!\n");

                        Console.ForegroundColor = ConsoleColor.Blue;
                        Console.Write("\t" + giver.getName());

                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write(" takes " + silenceDmg + " damage!");
                    }
                    break;
            }
        }

        /*
         * Plays out the battle and returns the modified battler
         */
        public battler battle()
        {
            Console.BackgroundColor = ConsoleColor.Yellow;
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.DarkMagenta;

            foe.healthRestore();
            player.healthRestore();

            Console.WriteLine(foe.getName() + " " + entryDialogues[rng.Next(0, entryDialogues.Length)] + "!\n");

            //The fight
            while (player.getHealth() > 0 && foe.getHealth() > 0)
            {
                //Foe info
                printBattler(foe);
                Console.WriteLine("\n");

                //Player info
                printBattler(player);

                //Input menu
                Console.ForegroundColor = ConsoleColor.Black;
                Console.Write("\n\nWhat Will ");
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.Write(player.getName());

                Console.ForegroundColor = ConsoleColor.Black;
                Console.Write(" do?!\n");

                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("\n[I] - Insult");

                Console.ForegroundColor = ConsoleColor.DarkCyan;
                Console.WriteLine("\n[P] - Plug Ears");

                Console.ForegroundColor = ConsoleColor.DarkBlue;
                Console.Write("\n[S] - Use Sticker ");

                Console.ForegroundColor = ConsoleColor.Black;
                Console.Write("(" + player.getStickers() + " left)\n");

                Boolean isPlugging = false;

                //Player input
                input = Console.ReadLine();
                Console.Clear();
                switch (input.ToLower())
                {
                    case "i":
                    case "insult":
                        hit(player, foe, false);
                        break;

                    case "p":
                    case "plug ears":
                        isPlugging = true;
                        Console.ForegroundColor = ConsoleColor.Blue;
                        Console.Write(player.getName());

                        Console.ForegroundColor = ConsoleColor.DarkMagenta;
                        Console.Write(" is plugging their ears!");
                        break;

                    case "sticker":
                    case "use sticker":
                    case "s":
                        player.useSticker();
                        break;

                    default:
                        Console.ForegroundColor = ConsoleColor.Blue;
                        Console.Write(player.getName());

                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write(" gets confused and assumes the fetal position!");
                        break;
                }

                //The computer's turn
                if (foe.getHealth() > 0)
                {
                    Console.WriteLine("\n");
                    hit(foe, player, isPlugging);
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.WriteLine("\n----------------------------------------------");
                }
            }
            if (player.getHealth() <= 0)
            {
                retry();
            }
            else
            {
                player.giveXp(rng.Next(85, 100));
            }
            return player;
        }
    }
}