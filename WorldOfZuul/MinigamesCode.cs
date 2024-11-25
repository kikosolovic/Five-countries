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
        public void Dock(ref int score)
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

        public void testMinigameDelegate(ref int score)
        {
            Console.WriteLine("succesfuly ran a fucntion passed as argument");
        }

        public int photovoltaicMinigame()
        {
            int score = 0;
            Console.WriteLine(@"
Welcome to the first minigame in Haitis' Lab
OBJECTIVE: Choose the best location for a photovoltaic power plant in Haiti.
Your task is to find best spots for Photovoltaic(PV) power plants You will be shown a map of Haiti and you will have to choose the best location for 3 new Photovoltaic power plants.
");
            
            string haitiMapPV = @"
================================================= MAP OF HAITI =================================================

                                                    ██████                                          
                                                   ██▓▓███████           ~SEA~                           
                                              Port-de-Paix ███                                      
                                            ███▓▓██▓▓▓███*▒▒▒█▒                             _______
                                       ██████████████████▒▒▒▒▒▒█▒▒                        _/       \___
                                      ██████▒▒▒▒▒▒█▒▒▒██████▒▒▒▒▒▒▒███   ██ Cap-Haitien  |
                                     ███▒█████████████▒████████▒▒▒▒▒██████▓*▓████▓▓██    |               
                                     ███████▓▓▓▓▓▓▓▓████████████▒▒▒▒▒▒▒████████▓▓▓▓█▒████|           
                                       ███▓██▓██▓▓▓▓▓▓▓█████████▒▒▒▒▒▒▒▒▒▒▒██████████████|           
                                                    █▓▓▓▓████▓████▒▒▒▒▒▒▒▒▒▒██▒▒▒▒██████*| Ouanaminthe    
                                               Gonaives █*██▓▓▓████████▒▒▒▒▒████▒▒▒▒▒▒▒▒██|          
                                                         ███▓▓▓███▒██████▓██████▒▒▒▒▒▒▒█▒█|          
                ~SEA~                                    ▓█▓█▓▓█████████▓▓▓▓▓█████████████|          
                                                         ███▓▓▓▓▓▓▓▓████▓▓▓▓▓▓██████████|           
                                                         ▓▓▓▓▓▓▓▓▓▓███████▓▓▓▓▓████████████|         
                                                        ▓▓▓▓▓▓▓▓▓▓▓███████████*█▓▓▓██▓▓▓████| <- Hinche
                                                          ▓▓▓▓▓▓▓▓▓████▒▒███████▓▓▓▓▓▓▓▓▓███        
                                                        █████████▓▓▓███▒▒█████▓▓▓▓▓▓▓▓▓▓▓█|          
                                                        █▓▓█▒▒█████▓▓███████▓▓▓▓▓▓▓▓▓▓██|            
                                          █▓█▓▓           █▓███▒▒███▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓█▓▓█|            
                                          ▓▓██▓▓▓▓▓▓         ████████████▓▓▓▓▓▓███▓▓▓▓▓██|           
                                           █▓▓▓▓██▓▓▓▓▓█      █▓▓▓██████▓▓▓▓▓▓▓▓█████████|           
                                                ██▓▓▓▓▓▓▓       ▓▓▓█████▓▓▓▓▓▓▓████████▒▒|           
                                                  ██▓▓▓█ Arcahaie *▓▓▓▓▓▓▓▓▓▓███████▒▒▒▒█|           
          ▒▒▒▒██▒* Jeremie                                            █▓▓▓▓▓▓▓▓█▓█▓████|             
         ▒▒▒▒▒▒▒▒████████  ████  █                  Port-au-prince v █▓▓▓▓▓▓▓▓█▒██|                  
        ▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒█▒██████▒             Carrefour -> ▓▓▓*▒▒▒*███▓▓▓▓▓▓███▒██|                
       ▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒███▒▒▒██*Miragoane   ████▒▒▒▒▒▒▒▒██▓█████████|                
       ▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒███▒▒▒▒▒▒▒▒██████████▓▓█████▒▒▒▒▒▒▒▒▒████▒▒▒▒▒▒▒▒▒|              
        ▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒█▒▒▒▒▒▒▒▒▒▒████▒██▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒█|          
         ▒████▒▒▒▒▒▒▒▒▒▒▒▒▒▒█████▒▒▒▒▒▒▒██▒█▒▒▒█████▒▒▒▒▒▒▒▒██████▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒|          
                 ██▒▒▒▒▒▒█████▓███████████▓▓▓███████████████████▓██*████████████████▒▒▒▒▒|           
                    ▒████████* Les Cayes      ███▓█▓▓▓▓█▓▓▓▓███▓█   Jacmel       ███████|            
                      █████                                                         █▓███|           
                       █████  ██▓▓▓                                                  █▓▓█|           
                                                                                         |           
                                                ~SEA~                                     \
                                                                                           |         
                                                                                            \ 
================================================================================================================
            Legend:                                          
            ▒▒▒▒▒▒▒▒▒▒▓▓▓▓▓▓▓▓▓▓██████████                      * - city             
               1200      1500      1800   kWh/kWp/year          | - border with Dominican Republic

            Data from: https://globalsolaratlas.info/download/haiti @ 25.11.2024";
            Console.WriteLine(haitiMapPV);
            Console.WriteLine(@"
            On the map you can see the predicted solar yield in kWh/kWp/year for different regions in Haiti.
            The higher the number, the more solar energy can be produced in that region.
            A bit more knowledge about units here:
                kWh is a unit of how much energy is produced
                kWp is a unit of how much power is teoreticaly produced by the solar panels

            so if we have an PV instalation of 1kWp in a region with 1800kWh/kWp/year, it will produce 1800kWh of energy in a year.
            ");
            Console.WriteLine(@"
            Places to choose from:
            1. Port-de-Paix
            2. Cap-Haitien
            3. Ouanaminthe
            4. Hinche
            5. Arcahaie
            6. Carrefour
            7. Miragoane
            8. Les Cayes
            9. Jacmel
            10. Port-au-prince
            11. Gonaives
            12. Jeremie
            ");

            Console.WriteLine("Choose the best locations for the photovoltaic power plants (type 3 numbers spaced by space '') :");
            string[] answers = Console.ReadLine().Split(' ');
            while( answers.Length != 3){
                answers = Console.ReadLine().Split(' ');
            }
            int[] optimalAnswers = {8, 9, 3, 11, 2, 4};
            
            for(int i =0; i<answers.Length; i++){
                if(optimalAnswers.Contains(Int32.Parse(answers[i]))){
                    score += 1;
                }
            }
            if(score ==3){
                Console.WriteLine("Congrats! You have choosen ones of the best cities available for our new investments!");
            }else if(score > 0){
                Console.WriteLine("Good job! You have choosen some of the best cities available for our new investments!");
            }else{
                Console.WriteLine("You have not choosen the best cities available for our new investments!");
            }
            Console.WriteLine("You have scored: " + score + " points");
            return score;
        }
        public int minigame12()
        {
            int score = 0;
            Console.WriteLine("Welcome to the second minigame in Haitis' Lab");
            Console.WriteLine("You will have to help with designing a new Photovoltaic power plant");
            Console.WriteLine("How many points:");
            score = int.Parse(Console.ReadLine() ?? "0");
            return score;
            score += 2;
            return score;
        }
        public int minigame13()
        {
            int score = 0;
            Console.WriteLine("Welcome to the third minigame in Haitis' Lab");
            Console.WriteLine("You will have to help with designing a new Wind power plant");
            return score;
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
        public void EcoFriendlyHomeMakeover(ref int score)
        {
            CustomFunctions customFunctions = new CustomFunctions();
            customFunctions.UNAmbassadorPreMinigameDialogue("EcoFriendlyHomeMakeover");

            int minigameScore = 0;
            int questionNumber = 1;

            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("\nWelcome to Eco-Friendly Home Makeover in Los Angeles!");
            Console.WriteLine("Make sustainable choices to upgrade your home and reduce your environmental footprint.\n");
            Console.ResetColor();

            // List of questions
            List<Question> questions = new List<Question>
{
    new Question
    {
        Text = "You need a new refrigerator. Which option is the most eco-friendly choice?",
        Options = new Dictionary<char, string>
        {
            { 'A', "A standard refrigerator with a low upfront cost." },
            { 'B', "An ENERGY STAR-certified refrigerator." },
            { 'C', "A second-hand refrigerator from a friend." },
            { 'D', "The largest refrigerator available for more storage." }
        },
        CorrectOption = 'B',
        Explanation = "ENERGY STAR-certified appliances use less energy, saving you money and reducing environmental impact."
    },
    new Question
    {
        Text = "You're redesigning your garden. What should you plant to conserve water?",
        Options = new Dictionary<char, string>
        {
            { 'A', "A lawn with exotic flowers." },
            { 'B', "Native drought-resistant plants." },
            { 'C', "A tropical fruit garden." },
            { 'D', "Water-intensive grass turf." }
        },
        CorrectOption = 'B',
        Explanation = "Native drought-resistant plants require less water and are well-suited to LA's climate."
    },
    new Question
    {
        Text = "How can you best reduce household waste?",
        Options = new Dictionary<char, string>
        {
            { 'A', "Use disposable plates and utensils to avoid washing dishes." },
            { 'B', "Implement a composting system for organic waste." },
            { 'C', "Throw all waste into the general trash bin." },
            { 'D', "Burn waste in the backyard." }
        },
        CorrectOption = 'B',
        Explanation = "Composting reduces landfill waste and provides nutrient-rich soil for gardening."
    },
    new Question
    {
        Text = "Which lighting option is the most energy-efficient for your home?",
        Options = new Dictionary<char, string>
        {
            { 'A', "Incandescent bulbs." },
            { 'B', "Halogen bulbs." },
            { 'C', "Compact Fluorescent Lamps (CFLs)." },
            { 'D', "Light Emitting Diode (LED) bulbs." }
        },
        CorrectOption = 'D',
        Explanation = "LED bulbs are the most energy-efficient and have a longer lifespan than other bulbs."
    },
    new Question
    {
        Text = "To conserve water during showers, you should:",
        Options = new Dictionary<char, string>
        {
            { 'A', "Take longer showers to relax." },
            { 'B', "Install a low-flow showerhead." },
            { 'C', "Keep the water running while not in use." },
            { 'D', "Shower multiple times a day." }
        },
        CorrectOption = 'B',
        Explanation = "Low-flow showerheads reduce water usage without compromising the shower experience."
    }
};

            foreach (var question in questions)
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine($"Question {questionNumber}: {question.Text}\n");
                Console.ResetColor();

                foreach (var option in question.Options)
                {
                    Console.Write($"{option.Key}. ");
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine($"{option.Value}");
                    Console.ResetColor();
                }

                Console.Write("\nType A, B, C, or D: ");
                char playerChoice = GetValidOption();

                if (char.ToUpper(playerChoice) == question.CorrectOption)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("\nCorrect! " + question.Explanation);
                    score += 1;
                    minigameScore += 1;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\nIncorrect.");
                    Console.WriteLine("Correct Answer: " + question.CorrectOption + ". " + question.Options[question.CorrectOption]);
                    Console.WriteLine(question.Explanation);
                }

                Console.ResetColor();
                Console.WriteLine("\nPress Enter to continue...");
                Console.ReadLine();
                questionNumber++;
            }
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("\nUN Ambassador: Let's see how you did.");
            Console.WriteLine($"Your score is: {minigameScore} out of {questions.Count * 10} points.");

            if (score == questions.Count * 10)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Outstanding work! Your choices demonstrate excellent knowledge of sustainable practices.");
                Console.WriteLine("You've set a great example for others to follow in making eco-friendly decisions.");
            }
            else if (score >= (questions.Count * 8))
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Great job! You've made significant eco-friendly improvements to your home.");
                Console.WriteLine("With a bit more effort, you can achieve even greater sustainability.");
            }
            else if (score >= (questions.Count * 5))
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Good effort! Consider exploring more sustainable options to further reduce your environmental impact.");
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("It looks like there are many opportunities for improvement.");
                Console.WriteLine("Remember, every small change can contribute to a healthier planet.");
            }

            Console.ResetColor();
            

        }

        // Class to represent each question
        public class Question
        {
            public string Text { get; set; }
            public Dictionary<char, string> Options { get; set; }
            public char CorrectOption { get; set; }
            public string Explanation { get; set; }
        }

        // Method to get a valid option from the player
        private char GetValidOption()
        {
            while (true)
            {
                string? input = Console.ReadLine();
                if (!string.IsNullOrEmpty(input) && input.Length == 1)
                {
                    char option = char.ToUpper(input[0]);
                    if (option >= 'A' && option <= 'D')
                    {
                        return option;
                    }
                }
                Console.Write("Invalid input. Please enter A, B, C, or D: ");
            }
        }
        public void RecyclingSortingMinigameNYC(ref int score)
        {
            // Trigger the NPC dialogue before the minigame
            CustomFunctions customFunctions = new CustomFunctions();
            customFunctions.UNAmbassadorPreMinigameDialogue("RecyclingSorting");

            // Minigame starts after NPC dialogue
            
            int timeLimit = 30; // Time limit in seconds
            DateTime endTime = DateTime.Now.AddSeconds(timeLimit);

            Console.WriteLine("\nWelcome to the NYC Recycling Sorting Minigame!");
            Console.WriteLine("You have 30 seconds to sort as many items correctly as you can!");
            Console.WriteLine("Type 'recycle', 'compost', or 'trash' for each item.\n");

            string[] items = {
        "plastic bottle", "banana peel", "glass jar", "pizza box with grease",
        "electronics", "paper", "food scraps", "plastic bag", "tin can"
    };

            Random random = new Random();
            int previousInterval = timeLimit; // The previous countdown interval displayed
            string currentInput = string.Empty; // To store the user's current input
            string currentItem = items[random.Next(items.Length)];

            // Initial prompt
            DisplayPrompt(currentItem, currentInput);

            while (true)
            {
                // Calculate remaining total seconds
                int remainingSeconds = (int)(endTime - DateTime.Now).TotalSeconds;

                // Check if time is up
                if (remainingSeconds <= 0)
                {
                    break;
                }

                // Display countdown at every 5-second decrement
                if (remainingSeconds % 5 == 0 && remainingSeconds < previousInterval)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"\nYou have {remainingSeconds} seconds remaining.");
                    Console.ResetColor();

                    // Re-display the prompt for clarity
                    DisplayPrompt(currentItem, currentInput);

                    previousInterval = remainingSeconds;
                }

                // Check for user input (non-blocking)
                if (Console.KeyAvailable)
                {
                    ConsoleKeyInfo keyInfo = Console.ReadKey(intercept: true);

                    if (keyInfo.Key == ConsoleKey.Enter)
                    {
                        string response = currentInput.Trim();
                        // Process the player's response
                        ProcessPlayerResponse(currentItem, response, ref score);

                        // Clear the current input
                        currentInput = string.Empty;

                        // Generate a new item
                        currentItem = items[random.Next(items.Length)];

                        DisplayPrompt(currentItem, currentInput);
                    }
                    else if (keyInfo.Key == ConsoleKey.Backspace)
                    {
                        if (currentInput.Length > 0)
                        {
                            currentInput = currentInput.Substring(0, currentInput.Length - 1);
                            Console.Write("\b \b"); // Move cursor back, replace character with space, move cursor back
                        }
                    }
                    else
                    {
                        currentInput += keyInfo.KeyChar;
                        Console.Write(keyInfo.KeyChar);
                    }
                }

                // Short delay to avoid high CPU usage
                System.Threading.Thread.Sleep(50);
            }

            Console.WriteLine($"\nTime's up! You scored {score} points.");
        }

        // Separate method to process player's response to keep the code organized
        private void ProcessPlayerResponse(string item, string response, ref int score)
        {
            switch (item)
            {
                case "plastic bottle":
                case "glass jar":
                case "tin can":
                    if (response.ToLower() == "recycle")
                    {
                        Console.WriteLine("\nCorrect! This item is recyclable.");
                        score++;
                    }
                    else
                    {
                        Console.WriteLine("\nIncorrect. This item should be recycled.");
                    }
                    break;

                case "banana peel":
                case "food scraps":
                    if (response.ToLower() == "compost")
                    {
                        Console.WriteLine("\nCorrect! This item should be composted.");
                        score++;
                    }
                    else
                    {
                        Console.WriteLine("\nIncorrect. This item should be composted.");
                    }
                    break;

                case "pizza box with grease":
                case "plastic bag":
                case "electronics":
                    if (response.ToLower() == "trash")
                    {
                        Console.WriteLine("\nCorrect! This item belongs in the trash.");
                        score++;
                    }
                    else
                    {
                        Console.WriteLine("\nIncorrect. This item should be trashed.");
                    }
                    break;

                case "paper":
                    if (response.ToLower() == "recycle")
                    {
                        Console.WriteLine("\nCorrect! Paper can be recycled.");
                        score++;
                    }
                    else
                    {
                        Console.WriteLine("\nIncorrect. Paper should be recycled.");
                    }
                    break;

                default:
                    Console.WriteLine("\nInvalid item.");
                    break;
            }
        }

        // Method to display the prompt with conditional brackets around current input
        private void DisplayPrompt(string currentItem, string currentInput)
        {
            Console.WriteLine($"\nItem: {currentItem}");
            if (string.IsNullOrEmpty(currentInput))
            {
                Console.Write("Type 'recycle', 'compost', or 'trash': ");
            }
            else
            {
                // Display the current input within brackets
                Console.Write($"Type 'recycle', 'compost', or 'trash' [{currentInput}]: ");
            }

        }









    }


}
