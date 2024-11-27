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
        public void Dock(ref int score)
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
            Program._game.currentCountry.currentRoom.ExecuteMinigame(ref score);

        }
        public void Village(ref int score)
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
        public void Shelter(ref int score)
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

        public void Hill(ref int score)
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

        public void UNOutpost(ref int score)
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

        public void testMinigameDelegate(ref int score)
        {
            Console.WriteLine("succesfuly ran a function passed as argument");
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
            // Pre-game Dialogue
            StorylineManager preGameDialogue = new StorylineManager("Dialogues/laDialogue.json");

            while (true)
            {
                helper.say(preGameDialogue.text, preGameDialogue.response, preGameDialogue.options);

                if (string.IsNullOrEmpty(preGameDialogue.options)) break;

                var choice = helper.parseinput(Console.ReadLine());

                try
                {
                    preGameDialogue.NextLevel(choice);
                }
                catch (Exception)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Invalid choice. Please select a valid option.");
                    Console.ResetColor();
                }
            }

            // Contextual Minigame Introduction
            Console.ForegroundColor = ConsoleColor.Cyan;
            helper.WriteWithDelay("\nThe UN Ambassador leads you to a suburban neighborhood in Los Angeles.");
            helper.WriteWithDelay("\n'This city is working hard to make its homes more eco-friendly,' the ambassador explains.");
            helper.WriteWithDelay("\n'Your mission is to help by making sustainable choices in this eco-friendly home makeover challenge.'");
            Console.ResetColor();

            // Questions for the Minigame
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

            int minigameScore = 0;
            int questionNumber = 1;

            foreach (var question in questions)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                helper.WriteWithDelay($"Question {questionNumber}: {question.Text}");
                Console.ResetColor();

                foreach (var option in question.Options)
                {
                    Console.Write($"{option.Key}. ");
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine(option.Value);
                    Console.ResetColor();
                }

                Console.Write("\nEnter your choice (A, B, C, or D): ");
                char playerChoice = GetValidOption();

                if (char.ToUpper(playerChoice) == question.CorrectOption)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Correct! " + question.Explanation);
                    score++;
                    minigameScore++;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"Incorrect. Correct Answer: {question.CorrectOption}. {question.Options[question.CorrectOption]}");
                    Console.WriteLine(question.Explanation);
                }

                Console.ResetColor();
                Console.WriteLine("\nPress Enter to continue...");
                Console.ReadLine();
                questionNumber++;
            }

            // Final Minigame Results
            Console.ForegroundColor = ConsoleColor.Blue;
            helper.WriteWithDelay($"\nGame Over! You scored {score}/{questions.Count}.");
            if (score == questions.Count)
                helper.WriteWithDelay("Outstanding work! Your decisions showcase the best of sustainable practices.");
            else if (score >= questions.Count / 2)
                helper.WriteWithDelay("Good job! Your efforts show promise, but there’s always room for improvement.");
            else
                helper.WriteWithDelay("There’s a lot to learn about sustainability. Keep trying, and you'll get there!");
            Console.ResetColor();

            // Post-game Dialogue
            StorylineManager postGameDialogue = new StorylineManager("Dialogues/postGameLA.json");

            while (true)
            {
                helper.say(postGameDialogue.text, postGameDialogue.response, postGameDialogue.options);

                if (string.IsNullOrEmpty(postGameDialogue.options)) break;

                var choice = helper.parseinput(Console.ReadLine());

                try
                {
                    postGameDialogue.NextLevel(choice);
                }
                catch (Exception)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Invalid choice. Please select a valid option.");
                    Console.ResetColor();
                }
            }

            // Final Dialogue Finisher
            Console.ForegroundColor = ConsoleColor.Yellow;
            helper.WriteWithDelay("\nUN Ambassador: 'Your eco-friendly choices have inspired this city to push even further for sustainability.'");
            helper.WriteWithDelay("A local eco-enthusiast named Mia steps forward. 'Thanks to you, people are already adopting these practices in their homes.'");
            Console.ForegroundColor = ConsoleColor.Cyan;
            helper.WriteWithDelay("\nThe ambassador adds, 'Let’s move on to our next destination. There's still work to be done.'");
            Console.ResetColor();
        }

        // Question Class for Minigames
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
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("Invalid input. Please enter A, B, C, or D: ");
                Console.ResetColor();
            }
        }







        public void RecyclingSortingMinigameNYC(ref int score)
        {
            StorylineManager preGameDialogue = new StorylineManager("Dialogues/nycDialogue.json");

            while (true)
            {
                helper.say(preGameDialogue.text, preGameDialogue.response, preGameDialogue.options);

                if (string.IsNullOrEmpty(preGameDialogue.options)) break;

                var choice = helper.parseinput(Console.ReadLine());

                try
                {
                    preGameDialogue.NextLevel(choice);
                }
                catch (Exception)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Invalid choice. Please select a valid option.");
                    Console.ResetColor();
                }
            }

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\nThe ambassador leads you to a large warehouse filled with bins labeled 'Recycle', 'Compost', and 'Trash'.");
            Console.WriteLine("He turns to you with a determined expression. 'This is where it all starts. Sorting these items correctly can make a huge impact.'");
            Console.WriteLine("'Your task is simple,' he continues. 'Identify each item and decide where it belongs—recycle, compost, or trash.'");
            Console.ResetColor();

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\nHow it works:");
            Console.WriteLine("- You’ll be presented with an item.");
            Console.WriteLine("- Type 'recycle', 'compost', or 'trash' to decide where it goes.");
            Console.WriteLine("- Let’s do this and show the team what proper sorting looks like!\n");
            Console.ResetColor();

            string[] items = {
        "plastic bottle", "banana peel", "glass jar", "pizza box with grease",
        "electronics", "paper", "food scraps", "plastic bag", "tin can",
        "aluminum foil", "egg shells", "styrofoam cup", "cardboard box",
        "used tissue", "coffee grounds", "cereal box", "broken toy"
    };

            Random random = new Random();
            int timeLimit = 15;
            DateTime endTime = DateTime.Now.AddSeconds(timeLimit);

            while (DateTime.Now < endTime)
            {
                string item = items[random.Next(items.Length)];
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.Write($"Item: {item} - Where does it go? (recycle/compost/trash): ");
                Console.ResetColor();

                string response = Console.ReadLine()?.Trim().ToLower();

                if ((item == "plastic bottle" || item == "glass jar" || item == "tin can" ||
                     item == "aluminum foil" || item == "cereal box") && response == "recycle")
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Correct! This item belongs in recycling.");
                    score++;
                }
                else if ((item == "banana peel" || item == "food scraps" || item == "egg shells" ||
                          item == "coffee grounds") && response == "compost")
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Correct! This item should go to compost.");
                    score++;
                }
                else if ((item == "pizza box with grease" || item == "electronics" ||
                          item == "plastic bag" || item == "styrofoam cup" ||
                          item == "used tissue" || item == "broken toy") && response == "trash")
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Correct! This item belongs in the trash.");
                    score++;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Incorrect! Try to sort more carefully.");
                }

                Console.ResetColor();
            }

            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine($"\nTime's up! You sorted {score} items correctly.");
            Console.WriteLine("The ambassador smiles. 'You’ve done well. Every properly sorted item is one less going to waste.'");
            Console.WriteLine("The recycling team applauds your effort, inspired by your work.");
            Console.ResetColor();

            StorylineManager postGameDialogue = new StorylineManager("Dialogues/postGameNYC.json");

            while (true)
            {
                helper.say(postGameDialogue.text, postGameDialogue.response, postGameDialogue.options);

                if (string.IsNullOrEmpty(postGameDialogue.options)) break;

                var choice = helper.parseinput(Console.ReadLine());

                try
                {
                    postGameDialogue.NextLevel(choice);
                }
                catch (Exception)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Invalid choice. Please select a valid option.");
                    Console.ResetColor();
                }
        
            }
            string finalText = "The UN Ambassador steps forward and gives you a friendly pat on the back.";
            helper.say(finalText, "UN Ambassador: 'Your hard work has made a real difference here today. But remember, there’s still more work to do. We’ll need you in the next city to help tackle even bigger challenges.'", null);

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\nYou prepare to move on to the next city, ready to take on new challenges.");
            Console.ResetColor();
        }








        public void CompostingPuzzleMinigameSFA(ref int score)
        {
            // Pre-game Dialogue
            StorylineManager preGameDialogue = new StorylineManager("Dialogues/sfaDialogue.json");

            while (true)
            {
                helper.say(preGameDialogue.text, preGameDialogue.response, preGameDialogue.options);

                if (string.IsNullOrEmpty(preGameDialogue.options)) break;

                var choice = helper.parseinput(Console.ReadLine());

                try
                {
                    preGameDialogue.NextLevel(choice);
                }
                catch (Exception)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Invalid choice. Please select a valid option.");
                    Console.ResetColor();
                }
            }

            // Contextual Minigame Introduction
            Console.ForegroundColor = ConsoleColor.Cyan;
            helper.WriteWithDelay("\nThe UN Ambassador leads you to a bustling composting site in San Francisco, a city known for its dedication to sustainability.");
            helper.WriteWithDelay("\n'This city has set an example for others to follow in composting and waste management,' the ambassador explains.");
            helper.WriteWithDelay("\n'Your task is to sort compostable items into the correct bins. Each item must be categorized into Food Scraps, Garden Waste, or Paper Products.'");
            Console.ResetColor();

            // Define Items and Bin Mapping
            string[] items = {
        "apple core", "banana peel", "grass clippings", "dead leaves", "pizza box",
        "coffee grounds", "tree branches", "paper napkins", "rotten vegetables", "newspaper"
    };

            Dictionary<string, string> binMapping = new Dictionary<string, string>
    {
        { "apple core", "Food Scraps" },
        { "banana peel", "Food Scraps" },
        { "grass clippings", "Garden Waste" },
        { "dead leaves", "Garden Waste" },
        { "pizza box", "Paper Products" },
        { "coffee grounds", "Food Scraps" },
        { "tree branches", "Garden Waste" },
        { "paper napkins", "Paper Products" },
        { "rotten vegetables", "Food Scraps" },
        { "newspaper", "Paper Products" }
    };

            // Number of items to sort in this round
            int totalItems = 7;
            Random random = new Random();

            int minigameScore = 0;
            for (int i = 0; i < totalItems; i++)
            {
                // Pick a random item
                var item = items[random.Next(items.Length)];

                // Ask the player to sort the item
                Console.ForegroundColor = ConsoleColor.Yellow;
                helper.WriteWithDelay($"Item {i + 1}: {item}");
                Console.ResetColor();
                Console.Write("Which bin does this belong to? (Type: Food Scraps, Garden Waste, Paper Products): ");
                string response = Console.ReadLine()?.Trim();

                // Check the player's response
                if (binMapping.TryGetValue(item, out string correctBin))
                {
                    if (string.Equals(response, correctBin, StringComparison.OrdinalIgnoreCase))
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("Correct! You placed it in the right bin.");
                        score++;
                        minigameScore++;
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine($"Incorrect. The correct bin for {item} is {correctBin}.");
                    }

                    Console.WriteLine($"Explanation: {correctBin} is the proper category for {item} to ensure effective composting.");
                    Console.ResetColor();
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Invalid item. Skipping...");
                    Console.ResetColor();
                }

                Console.WriteLine(); // Add spacing between rounds
            }

            // Display the final score
            Console.ForegroundColor = ConsoleColor.Blue;
            helper.WriteWithDelay($"\nGame Over! You sorted {score}/{totalItems} items correctly.");
            if (score == totalItems)
                helper.WriteWithDelay("Excellent! You’re a composting champion!");
            else if (score >= totalItems / 2)
                helper.WriteWithDelay("Good job! A bit more practice, and you'll master composting.");
            else
                helper.WriteWithDelay("Keep practicing to improve your composting skills.");
            Console.ResetColor();

            // Post-game Dialogue
            StorylineManager postGameDialogue = new StorylineManager("Dialogues/postGameSFA.json");

            while (true)
            {
                helper.say(postGameDialogue.text, postGameDialogue.response, postGameDialogue.options);

                if (string.IsNullOrEmpty(postGameDialogue.options)) break;

                var choice = helper.parseinput(Console.ReadLine());

                try
                {
                    postGameDialogue.NextLevel(choice);
                }
                catch (Exception)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Invalid choice. Please select a valid option.");
                    Console.ResetColor();
                }
            }

            // Final Dialogue Finisher
            Console.ForegroundColor = ConsoleColor.Yellow;
            helper.WriteWithDelay("\nUN Ambassador: 'You’ve done an amazing job here in San Francisco. Your dedication to sustainability is inspiring.'");
            helper.WriteWithDelay("A local community leader adds: 'Thanks to your efforts, more people understand the value of composting. We’re ready to make an even bigger impact!'");
            Console.ForegroundColor = ConsoleColor.Cyan;
            helper.WriteWithDelay("\nThe ambassador smiles warmly: 'Well done! Now, let’s move on to the next city and continue making a difference.'");
            Console.ResetColor();
        }












    }


}
