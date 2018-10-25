using System;

namespace rpgthing
{
    /**
     * Executes a fight between two fighters, one user-controlled
     */
    class battlemanager
    {
        private battler player, foe;
        private String input;
        private Random rng = new Random();
        private String[] missDialogues = {"screws up the delivery","stutters", "forgets what to say",
            "uses a word wrong", "says something unintentionally funny" };
        private String[] entryDialogues = { "draws near", "lurches forward", "is rarin' to fight", "won't back down", "must be stopped", "wants to duel", "will fight tooth and nail" };

        /**
         * Constructor for the battlemanager class. Defines the player controlled battler and their opponent
         */
        public battlemanager(rpgthing.battler p, rpgthing.battler f)
        {
            player = p;
            foe = f;
        }

        /*
         * Called when a battler attacks
         */
        private void hit(battler giver, battler receiver, bool plugging)
        {
            double damage = giver.attack();

            if (plugging)
            {
                damage /= 2;
            }

            receiver.receiveDamage(damage);

            switch (damage)
            {
                case 0:
                    Random randomIndex = new Random();
                    Console.ForegroundColor = ConsoleColor.Magenta;
                    Console.WriteLine("\t"+giver.getName() + " " + missDialogues[randomIndex.Next(0, missDialogues.Length)] + "! Insult failed!\n");
                    break;

                default:
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\t"+receiver.getName() + " is hit for " + damage + " damage!\n");
                    break;
            }
        }

        /*
         * Plays out the battle and returns the winner
         */
        public void battle()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Random rngForEntryDialogue = new Random();

            Console.WriteLine(foe.getName() + " "+entryDialogues[rngForEntryDialogue.Next(0, entryDialogues.Length)]+"!");

            //The fight
            while (player.getHealth() > 0 && foe.getHealth() > 0)
            {
                //Foe info
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("\n" + foe.getName());

                Console.ForegroundColor = ConsoleColor.Black;
                Console.Write("\nHP: ");
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.Write(foe.getHealth());

                Console.ForegroundColor = ConsoleColor.Black;
                Console.Write("   Lvl: ");
                Console.ForegroundColor = ConsoleColor.DarkMagenta;
                Console.Write(foe.getLvl()+"\n\n");

                //Player info
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("\n" + player.getName());

                Console.ForegroundColor = ConsoleColor.Black;
                Console.Write("\nHP: ");
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.Write(player.getHealth());

                Console.ForegroundColor = ConsoleColor.Black;
                Console.Write("   Lvl: ");
                Console.ForegroundColor = ConsoleColor.DarkMagenta;
                Console.Write(player.getLvl()+"\n");

                Console.ForegroundColor = ConsoleColor.Black;
                Console.WriteLine("\n\nWhat Will " + player.getName() + " do?!");

                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("\n[I] - Insult");

                Console.ForegroundColor = ConsoleColor.DarkCyan;
                Console.WriteLine("\n[P] - Plug Ears");

                Console.ForegroundColor = ConsoleColor.DarkBlue;
                Console.Write("\n[S] - Use Sticker ");

                Console.ForegroundColor = ConsoleColor.Black;
                Console.Write("("+player.getStickers() + " left)\n");

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
                        Console.Write(" got confused and curled up in a ball!\n");
                        break;
                }

                //The computer's turn
                if (foe.getHealth() > 0)
                {
                    hit(foe, player, isPlugging);
                }
            }
        }
    }
}