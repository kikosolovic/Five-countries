using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

// all minigames/quests should be created here, and referenced in Init.cs
namespace FiveCountries
{
    class MinigameCode
    {


        // put your code for the minigame here
        // as a new function
        // also add a call to the function in the functions.cs file


        //Template for minigame
        public int minigame()
        {
            int score = 0;

            //here put everything that should happen in the minigame
            //edit the 'score' variable to reflect the score of the player
            // by using for example 'score += 1;' or 'score -= 1;'



            return score;//return score
        }
        public void Dock()
        {
            Console.WriteLine("After a long journey you finally arrived in a small coastal village of Macuse. The guide got sick during the journney and left you at a small dock. There are only few old boats and a couple of local fisherman fishing.  ");

            {
                Console.WriteLine("What do you want to do?");
                Console.WriteLine("Talk/Continue");
                var res = Console.ReadLine();
                switch (res.ToLower())
                {
                    case "talk":
                        Console.WriteLine("You panicked and said hello fish to the locals.");
                        say("What did you just say to me you little bitch");
                        // Console.WriteLine("What do you want to do");
                        // Console.WriteLine("Run?");


                        break;
                    case "continue":
                        Console.WriteLine("Be on your way");
                        break;
                    default:
                        Console.WriteLine("You have to choose one and write it correctly");
                        break;
                }
            }
        }

        public void testMinigameDelegate()
        {
            Console.WriteLine("succesfuly ran a fucntion passed as argument");
        }

        public int minigame11()
        {
            int score = 0;
            Console.WriteLine("Welcome to the first minigame in Haitis' Lab");
            Console.WriteLine("Your task is to find best spots for Photovoltaic power plants");
            score += 1;
            return score;
        }
        public int minigame12()
        {
            int score = 0;
            Console.WriteLine("Welcome to the second minigame in Haitis' Lab");
            Console.WriteLine("You will have to help with designing a new Photovoltaic power plant");
            score += 2;
            return score;
        }
        public int minigame13()
        {
            int score = 0;
            Console.WriteLine("Welcome to the third minigame in Haitis' Lab");
            Console.WriteLine("You will have to help with designing a new Wind power plant");
            return score;
        }

        public int minigame14()
        {
            int score = 0;
            Console.WriteLine("Welcome to the fourth minigame in Haitis' Lab");
            Console.WriteLine("Calculate how big photovoltaic power station is needed for The Farm");
            return score;
        }
        //quick response function, makes the text yellow, meaning that somebody said that
        public void say(string text)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(">> " + text);
            Console.ResetColor();
        }

    }




}