using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using WorldOfZuul;

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
            // Console.WriteLine("After a long journey you finally arrived in a small coastal village of Macuse. The guide got sick during the journney and left you at a small dock. There are only few old boats and a couple of local fisherman fishing.  ");

            // {
            //     Console.WriteLine("What do you want to do?");
            //     Console.WriteLine("Talk/Continue");
            //     var res = Console.ReadLine();
            //     switch (res.ToLower())
            //     {
            //         case "talk":
            //             Console.WriteLine("You panicked and said hello fish to the locals.");
            //             say("What did you just say to me you little bitch");
            //             // Console.WriteLine("What do you want to do");
            //             // Console.WriteLine("Run?");


            //             break;
            //         case "continue":
            //             Console.WriteLine("Be on your way");
            //             break;
            //         default:
            //             Console.WriteLine("You have to choose one and write it correctly");
            //             break;
            //     }
            // }

            StorylineManager st = new StorylineManager("Dialogues/DockDialogue.json");
            while (true)
            {
                //spravit cely class na interface a styl s podmienkou aby to fungovalo
                if (st.idiotCount == 0)
                {
                    say(st.text, st.response, st.options); if (st.options == null) { break; }
                }
                else { say(null, null, st.options); }


                //since the readline is happenign here this function runs after the dialogue part is over and also the Game object can be passed here if needed
                var choice = Console.ReadLine();
                switch (choice)
                {
                    case "break": break;
                    default:
                        st.NextLevel(choice);
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
        public void say(string text, string response, string options)
        {//add pretty text, slow rolling or sometjhig

            if (text != null)
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                helper.WriteWithDelay(">> " + text);

                Console.ResetColor();
            }

            {
                if (response != null)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    helper.WriteWithDelay(">> " + response);
                    Console.ResetColor();
                }
                {
                    if (options != null)
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        helper.WriteWithDelay(">> " + options);
                        Console.ResetColor();
                    }

                }

            }




        }
    }
}