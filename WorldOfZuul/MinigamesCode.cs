using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using WorldOfZuul;
using FiveCountries;
using System.Collections.ObjectModel;


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

            StorylineManager st = new StorylineManager("Dialogues/DockDialogue.json");
            while (!WeatherControl._10toSweep)
            {
                //spravit cely class na interface a styl s podmienkou aby to fungovalo
                if (st.idiotCount == 0) //idiot count is implemented to prevent displaying the same dialogue multiple times in a row, istead just shows the options 
                {
                    helper.say(st.text, st.response, st.options); if (st.options == null || st.options == "") { break; }
                }
                else { helper.say(options: st.options); }


                //since the readline is happenign here this function runs after the dialogue part is over and also the Game object can be passed here if needed
                var choice = helper.parseinput(Console.ReadLine());
                if (!WeatherControl._10toSweep)
                {

                    switch (choice)
                    {
                        case "stop": break;
                        default:
                            st.NextLevel(choice);
                            break;
                    }


                }
            }
            st = new StorylineManager("Dialogues/CarRide.json");
            while (!WeatherControl._10toSweep)
            {
                //spravit cely class na interface a styl s podmienkou aby to fungovalo
                if (st.idiotCount == 0) //idiot count is implemented to prevent displaying the same dialogue multiple times in a row, istead just shows the options 
                {
                    helper.say(st.text, st.response, st.options); if (st.options == null || st.options == "") { break; }
                }
                else { helper.say(options: st.options); }


                //since the readline is happenign here this function runs after the dialogue part is over and also the Game object can be passed here if needed
                var choice = helper.parseinput(Console.ReadLine());
                if (!WeatherControl._10toSweep)
                {

                    switch (choice)
                    {
                        case "stoptalking": break;
                        default:
                            st.NextLevel(choice);
                            break;
                    }


                }
            }
            Program._game.Move("north");
            Program._game.currentCountry.currentRoom.ExecuteMinigame();

        }
        public void Village()
        {
            // WeatherControl.StartWeather(); neskor
            StorylineManager st = new StorylineManager("Dialogues/OldLady.json");
            var count = -1; //configure so it fits with the dialogue

            while (!WeatherControl._10toSweep)
            {
                if (st.idiotCount == 0) //idiot count is implemented to prevent displaying the same dialogue multiple times in a row, istead just shows the options 
                {
                    helper.say(st.text, st.response, st.options); if (st.options == null || st.options == "") { break; }
                }
                else { helper.say(options: st.options); }

                var choice = helper.parseinput(Console.ReadLine());
                if (!WeatherControl._10toSweep)
                {
                    switch (choice)
                    {
                        case "stoptalking": break;
                        default:
                            st.NextLevel(choice);
                            count += 1;
                            if (count < 3) { WeatherControl.tutorialNext(count); }
                            break;
                    }
                }
            }
            WeatherControl.StartWeather();

        }
        public void Shelter()
        {
            StorylineManager st = new StorylineManager("Dialogues/Shelter.json");
            while (!WeatherControl._10toSweep)
            {
                if (st.idiotCount == 0) //idiot count is implemented to prevent displaying the same dialogue multiple times in a row, istead just shows the options 
                {
                    helper.say(st.text, st.response, st.options); if (st.options == null || st.options == "") { break; }
                }
                else { helper.say(options: st.options); }

                var choice = helper.parseinput(Console.ReadLine());
                if (!WeatherControl._10toSweep)
                {
                    switch (choice)
                    {
                        case "stoptalking": break;
                        default:
                            st.NextLevel(choice);
                            break;

                    }
                }
            }
        }

        public void Hill()
        {
            StorylineManager st = new StorylineManager("Dialogues/Hill.json");
            while (!WeatherControl._10toSweep)
            {
                if (st.idiotCount == 0) //idiot count is implemented to prevent displaying the same dialogue multiple times in a row, istead just shows the options 
                {
                    helper.say(st.text, st.response, st.options); if (st.options == null || st.options == "") { break; }
                }
                else { helper.say(options: st.options); }

                var choice = helper.parseinput(Console.ReadLine());
                if (!WeatherControl._10toSweep)
                {
                    switch (choice)
                    {
                        case "stoptalking": break;
                        default:
                            st.NextLevel(choice);
                            break;
                    }
                }
            }

        }

        public void UNOutpost()
        {
            StorylineManager st = new StorylineManager("Dialogues/IndiaIntro.json");
            while (true)
            {
                if (st.idiotCount == 0)
                {
                    helper.say(st.text, st.response, st.options); if (st.options == null || st.options == "") { break; }
                }
                else { helper.say(options: st.options); }

                var choice = helper.parseinput(Console.ReadLine());

                {
                    switch (choice)
                    {
                        case "stoptalking": break;
                        default:
                            st.NextLevel(choice);
                            break;

                    }
                }
            }
        }

        public void testMinigameDelegate()
        {
            Console.WriteLine("succesfuly ran a function passed as argument");
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

         
         
        public static void tribeHangman(int wrong)
        {
           

            if (wrong == 0)
            {
                Console.WriteLine("\n+---+");
                Console.WriteLine("    |");
                Console.WriteLine("    |");
                Console.WriteLine("    |");
                Console.WriteLine("   ===");
            }
            else if (wrong == 1)
            {
                Console.WriteLine("\n+---+");
                Console.WriteLine("O   |");
                Console.WriteLine("    |");
                Console.WriteLine("    |");
                Console.WriteLine("   ===");
            }
            else if (wrong == 2)
            {
                Console.WriteLine("\n+---+");
                Console.WriteLine("O   |");
                Console.WriteLine("|   |");
                Console.WriteLine("    |");
                Console.WriteLine("   ===");
            }
            else if (wrong == 3)
            {
                Console.WriteLine("\n+---+");
                Console.WriteLine(" O  |");
                Console.WriteLine("/|  |");
                Console.WriteLine("    |");
                Console.WriteLine("   ===");
            }
            else if (wrong == 4)
            {
                Console.WriteLine("\n+---+");
                Console.WriteLine(" O  |");
                Console.WriteLine("/|\\ |");
                Console.WriteLine("    |");
                Console.WriteLine("   ===");
            }
            else if (wrong == 5)
            {
                Console.WriteLine("\n+---+");
                Console.WriteLine(" O  |");
                Console.WriteLine("/|\\ |");
                Console.WriteLine("/   |");
                Console.WriteLine("   ===");
            }
            else if (wrong == 6)
            {
                Console.WriteLine("\n+---+");
                Console.WriteLine(" O   |");
                Console.WriteLine("/|\\  |");
                Console.WriteLine("/ \\  |");
                Console.WriteLine("    ===");
                Console.WriteLine("You lost, try again.");
            }
            
        }

        public static int printWord(List<char> guessedLetters, String randomWord)
        {
            int counter = 0;
            int rightLetters = 0;
            Console.Write("\r\n");
            foreach (char c in randomWord)
            {
                if (guessedLetters.Contains(c))
                {
                    Console.Write(c + " ");
                    rightLetters += 1;
                }
                else
                {
                    Console.Write("  ");
                }
                counter += 1;
            }
            //Console.Write("\r\n");
            return rightLetters;
        }

        private static void printLines(String randomWord)
        {
            Console.Write("\r");
            foreach (char c in randomWord)
            {
                Console.OutputEncoding = System.Text.Encoding.Unicode;
                Console.Write("\u0305 ");
            }
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to hangman you need to guess the word chosen by the tribe leader to pass :)");
            Console.WriteLine("-----------------------------------------");

            Random random = new Random();
            List<string> wordDictionary = new List<string> { "sustainability" };
            int index = random.Next(wordDictionary.Count);
            String randomWord = wordDictionary[index];

            foreach (char x in randomWord)
            {
                Console.Write("_ ");
            }

            int lengthOfWordToGuess = randomWord.Length;
            int amountOfTimesWrong = 0;
            List<char> currentLettersGuessed = new List<char>();
            int currentLettersRight = 0;

            while (amountOfTimesWrong != 6 && currentLettersRight != lengthOfWordToGuess)
            {
                Console.Write("\nLetters guessed so far: ");
                foreach (char letter in currentLettersGuessed)
                {
                    Console.Write(letter + " ");
                }
                
                Console.Write("\nGuess a letter: ");
                char letterGuessed = Console.ReadLine()[0];
                
                if (currentLettersGuessed.Contains(letterGuessed))
                {
                    Console.Write("\r\n You have already guessed this letter");
                    tribeHangman(amountOfTimesWrong);
                    currentLettersRight = printWord(currentLettersGuessed, randomWord);
                    printLines(randomWord);
                }
                else
                {
                   
                    bool right = false;
                    for (int i = 0; i < randomWord.Length; i++) { if (letterGuessed == randomWord[i]) { right = true; } }

                   
                    if (right)

                    {
                        tribeHangman(amountOfTimesWrong);
                       
                        currentLettersGuessed.Add(letterGuessed);
                        currentLettersRight = printWord(currentLettersGuessed, randomWord);
                        Console.Write("\r\n");
                        printLines(randomWord);
                    }
                    
                    else
                    {
                        amountOfTimesWrong += 1;
                        currentLettersGuessed.Add(letterGuessed);

                        tribeHangman(amountOfTimesWrong);
                    
                        currentLettersRight = printWord(currentLettersGuessed, randomWord);
                        Console.Write("\r\n");
                        printLines(randomWord);
                    }
                }
            }
            Console.WriteLine("\r\nGame is over! Thank you for playing :)");
        
    }

            
        
            

        



          

            public void EcoFriendlyHomeMakeover()
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
                    helper.incrementScore(1);
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

            if (helper.getScore() == questions.Count * 10)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Outstanding work! Your choices demonstrate excellent knowledge of sustainable practices.");
                Console.WriteLine("You've set a great example for others to follow in making eco-friendly decisions.");
            }
            else if (helper.getScore() >= (questions.Count * 8))
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Great job! You've made significant eco-friendly improvements to your home.");
                Console.WriteLine("With a bit more effort, you can achieve even greater sustainability.");
            }
            else if (helper.getScore() >= (questions.Count * 5))
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

        private char GetValidOption()
        {
            throw new NotImplementedException();
        }

        internal void RecyclingSortingMinigameNYC()
        {
            throw new NotImplementedException();
        }


    }    // Class to represent each question
        public class Question
        {
            public string Text { get; set; }
            public Dictionary<char, string> Options { get; set; }
            public char CorrectOption { get; set; }
            public string Explanation { get; set; }
        

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
        public void RecyclingSortingMinigameNYC()
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
                        ProcessPlayerResponse(currentItem, response);

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

            Console.WriteLine($"\nTime's up! You scored {helper.getScore()} points.");
        }

        // Separate method to process player's response to keep the code organized
        private void ProcessPlayerResponse(string item, string response)
        {
            switch (item)
            {
                case "plastic bottle":
                case "glass jar":
                case "tin can":
                    if (response.ToLower() == "recycle")
                    {
                        Console.WriteLine("\nCorrect! This item is recyclable.");
                        helper.incrementScore(1);
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
                        helper.incrementScore(1);
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
                        helper.incrementScore(1);
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
                        helper.incrementScore(1);
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
