using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace FiveCountries
{
    public class CustomFunctions
    {
        private MinigameCode minigamesCode = new();


        public void PrintMap(string room)
        {
            Console.WriteLine("\n-- -- -- -- --  MAP  -- -- -- -- -- --       ^ N");
            Console.WriteLine("+---------+------------+-------------+       |");
            Console.WriteLine("|         |            |             |  W ---+---> E");
            switch (room)
            {
                case "Pub":
                    //Console.WriteLine("|   Pub       Office       Theatre   |");
                    string[] text = { "|   ", "Pub", "       Outside      Theatre   |       |" };
                    ConsoleColor[] colors = { ConsoleColor.White, ConsoleColor.Green, ConsoleColor.White };
                    PrintStringColorful(text, colors);
                    break;
                case "Outside":
                    //Console.WriteLine("|   Pub       Outside      Theatre   |");
                    string[] text2 = { "|   Pub       ", "Outside", "      Theatre   |       |" };
                    ConsoleColor[] colors2 = { ConsoleColor.White, ConsoleColor.Green, ConsoleColor.White };
                    PrintStringColorful(text2, colors2);
                    break;
                case "Theatre":
                    //Console.WriteLine("|   Pub       Outside      Theatre   |");
                    string[] text3 = { "|   Pub       Outside      ", "Theatre", "   |       |" };
                    ConsoleColor[] colors3 = { ConsoleColor.White, ConsoleColor.Green, ConsoleColor.White };
                    PrintStringColorful(text3, colors3);
                    break;
                default:
                    Console.WriteLine("|   Pub       Outside      Theatre   |       |");
                    break;
            }
            Console.WriteLine("|         |            |             |       |");
            Console.WriteLine("+---------++---   ---+-+----------+--+       S");
            Console.WriteLine("           |         |            |");
            switch (room)
            {
                case "Lab":
                    //Console.WriteLine("           |   Lab       Office   |");
                    string[] text4 = { "           |   ", "Lab", "       Office   |" };
                    ConsoleColor[] colors4 = { ConsoleColor.White, ConsoleColor.Green, ConsoleColor.White };
                    PrintStringColorful(text4, colors4);
                    break;
                case "Office":
                    //Console.WriteLine("           |   Lab       Office   |");
                    string[] text5 = { "           |   Lab       ", "Office", "   |" };
                    ConsoleColor[] colors5 = { ConsoleColor.White, ConsoleColor.Green, ConsoleColor.White };
                    PrintStringColorful(text5, colors5);
                    break;
                default:
                    Console.WriteLine("           |   Lab       Office   |");
                    break;
            }
            Console.WriteLine("           |         |            |");
            Console.WriteLine("           +---------+------------+");
        }


        /// <summary>
        ///     Prints all strings in text[], each in color from colors[] in the same line
        /// </summary>
        /// <param name="text">Array of strings to print</param>
        /// <param name="colors">Array of colors to print</param>
        public void PrintStringColorful(string[] text, ConsoleColor[] colors)
        {
            for (int i = 0; i < text.Length; i++)
            {
                Console.ForegroundColor = colors[i];
                Console.Write(text[i]);
                Console.ResetColor();
            }
            Console.WriteLine();


        }

        public (int, int) PlayGame(Country country, Room room, List<Minigame> minigames, int gameNumber = 0)
        {
            int counter = 1;
            List<Minigame> gamesForHere = new List<Minigame>();

            foreach (var minigame in minigames)// Get all games for this room
            {
                if (minigame.country == country.ShortDescription && minigame.room == room.ShortDescription)
                {
                    gamesForHere.Add(minigame);
                }
            }
            if (gameNumber == 0)
            {
                if (gamesForHere.Count == 0)
                {
                    Console.WriteLine("Sorry, there are no games available in this room.");
                    return (0, 0);
                }
                else
                {
                    Console.WriteLine("Here you can choose from the following games:");
                    foreach (var minigame in gamesForHere)
                    {
                        Console.WriteLine($"{counter}.{minigame.description}, score available: {minigame.score}");
                        counter++;
                    }
                }
                Console.Write("# of the game you want to play: ");
                string? input = Console.ReadLine();
                gameNumber = int.Parse(input);
            }

            if (gameNumber > gamesForHere.Count || gameNumber < 1)
            {
                Console.WriteLine("Invalid game number.");
                return (0, 0);
            }

            //int gameid = gamesForHere[gameNumber-1].id;

            return (gamesForHere[gameNumber - 1].game(), gamesForHere[gameNumber - 1].id);

        }


        public void loading()
        {
            string loadingText = "traveling ";
            Console.Write(loadingText);
            var spinnerChars = new[] { '/', '-', '\\', '|' };

            for (int i = 0; i < 20; i++)
            {
                Console.Write(spinnerChars[i % spinnerChars.Length]);
                Thread.Sleep(100);
                Console.Write('\b');
            }

            Console.SetCursorPosition(0, Console.CursorTop);
            Console.Write(new string(' ', 10));
            Console.SetCursorPosition(0, Console.CursorTop);


        }
        public void UNAmbassadorPreMinigameDialogue(string minigame)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;

            switch (minigame)
            {
                case "RecyclingSorting":
                    TypeLine("UN Ambassador: Before you proceed, let me remind you of the importance of proper recycling.");
                    Console.WriteLine();
                    TypeLine("New York City produces vast amounts of waste every day. Properly sorting recyclables helps us reduce the burden on our landfills and makes our city cleaner.");
                    Console.WriteLine();
                    TypeLine("I hope you�re ready for the recycling sorting challenge. Do your best!");
                    Console.WriteLine();
                    break;

                case "PlasticReduction":
                    TypeLine("UN Ambassador: Plastic pollution is a major issue, especially in cities like Los Angeles.");
                    Console.WriteLine();
                    TypeLine("We need to make critical choices to reduce single-use plastics. Let's see if you can help make the best decisions.");
                    Console.WriteLine();
                    break;

                case "Composting":
                    TypeLine("UN Ambassador: San Francisco aims to achieve zero waste. Composting is one of the biggest initiatives to achieve that goal.");
                    Console.WriteLine();
                    TypeLine("I need you to help manage the compost and keep it balanced. Are you ready?");
                    Console.WriteLine();
                    break;

                case "HazardousWaste":
                    TypeLine("UN Ambassador: Houston's industrial growth comes with the challenge of hazardous waste.");
                    Console.WriteLine();
                    TypeLine("It's important to manage this waste safely. This minigame will put your skills to the test.");
                    Console.WriteLine();
                    break;

                case "Ewaste":
                    TypeLine("UN Ambassador: Chicago faces a big challenge in managing electronic waste effectively.");
                    Console.WriteLine();
                    TypeLine("Sorting and recycling e-waste is crucial to minimize the impact on our environment. Let�s see if you�re up for the task!");
                    Console.WriteLine();
                    break;

                default:
                    TypeLine("UN Ambassador: It's time for a challenge that will help us make a difference!");
                    Console.WriteLine();
                    break;
            }

            Console.ResetColor();
        }

        public void UNAmbassadorDialogue(Room currentRoom)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;

            // Define dialogues for each room
            Dictionary<string, string[]> dialogues = new Dictionary<string, string[]>
    {
        {
            "New York City", new string[]
            {
                "UN Ambassador: Welcome to New York City, we are pleased that you have accepted our invitation.",
                "Our mission is to help resolve critical waste management issues, and we believe you are the right person for this job.",
                "Are you the right one for the job? (yes/no)"
            }
        },
        {
            "Los Angeles", new string[]
            {
                "UN Ambassador: Welcome to Los Angeles. The city has been struggling with its waste management system.",
                "We need to take some effective measures to address the issue of plastic waste in the oceans.",
                "Are you ready to assist? (yes/no)"
            }
        },
        {
            "Chicago", new string[]
            {
                "UN Ambassador: You've made it to Chicago! Here, we face major issues with electronic waste.",
                "We need to find a way to manage and recycle this waste responsibly. Are you up for it? (yes/no)"
            }
        },
        {
            "Houston", new string[]
            {
                "UN Ambassador: Welcome to Houston! This city has been dealing with hazardous waste problems.",
                "We need your expertise to tackle this issue head-on. Can we count on you? (yes/no)"
            }
        },
        {
            "Miami", new string[]
            {
                "UN Ambassador: Miami has been facing difficulties managing organic waste.",
                "Your task will be to create an efficient composting program. Are you prepared to do so? (yes/no)"
            }
        }
    };

            // Check if dialogue exists for the current room
            if (dialogues.ContainsKey(currentRoom.ShortDescription))
            {
                // Get the dialogue for the current room
                string[] dialogueLines = dialogues[currentRoom.ShortDescription];

                // Type out each line with delay
                foreach (string line in dialogueLines)
                {
                    TypeLine(line);
                    Console.WriteLine();  // New line after each sentence
                }

                Console.ResetColor();

                // Get player's response
                string? response = Console.ReadLine();

                // Handle the player's response
                if (response != null)
                {
                    switch (response.ToLower())
                    {
                        case "yes":
                            Console.ForegroundColor = ConsoleColor.Cyan;
                            TypeLine("UN Ambassador: Excellent! We're glad to have you on board. Let's get started.");
                            Console.WriteLine();
                            break;
                        case "no":
                            Console.ForegroundColor = ConsoleColor.Cyan;
                            TypeLine("UN Ambassador: Well, we don't have much choice. The world needs your help. Let's proceed anyway.");
                            Console.WriteLine();
                            break;
                        default:
                            Console.ForegroundColor = ConsoleColor.Cyan;
                            TypeLine("UN Ambassador: I need a clear answer: yes or no.");
                            Console.WriteLine();
                            UNAmbassadorDialogue(currentRoom); // Ask the question again if the response is invalid
                            return;
                    }
                }
                Console.ResetColor();
            }
            else
            {
                Console.WriteLine("No dialogue available for this room.");
            }
        }

        // Helper method to type out a line character by character
        private void TypeLine(string line)
        {
            foreach (char c in line)
            {
                Console.Write(c);
                System.Threading.Thread.Sleep(5); // 5 milliseconds delay between characters
            }
        }



    }



}