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
        public void RecyclingSortingMinigameNYC()
        {
            // Trigger the NPC dialogue before the minigame
            CustomFunctions customFunctions = new CustomFunctions();
            customFunctions.UNAmbassadorPreMinigameDialogue("RecyclingSorting");

            // Minigame starts after NPC dialogue
            int score = 0;
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