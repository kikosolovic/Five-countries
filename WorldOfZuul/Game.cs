using System.Security.Cryptography.X509Certificates;
using WorldOfZuul;

namespace FiveCountries
{
    public class Game : Init
    {

        public Country? currentCountry;
        private Country? previousCountry; //back command for country if needed

        private string currentItem { get; set; }

        public Game()
        {
            //initialize the game
            List<Country> Countries = CreateCountries();
            this.currentCountry = Countries[0];
            CreateRooms(Countries);

            // QuickAssign(Rooms, Countries);
        }

        public void Play()
        {
            Parser parser = new();
            CustomFunctions customFunctions = new();
            MinigameCode minigamesCode = new();
            List<Minigame> minigames = CreateGames();
            int score = 0;

            PrintWelcome();
            PrintHelp();

            bool continuePlaying = true;
            while (continuePlaying)


            // note below
            {

                helper.say(location: currentCountry?.ShortDescription + " " + currentCountry?.currentRoom?.ShortDescription + " >");


                string? input = Console.ReadLine();

                if (string.IsNullOrEmpty(input))
                {
                    Console.WriteLine("Please enter a command.");
                    continue;
                }

                Command? command = parser.GetCommand(input.ToLower().Trim());
                // 


                // 

                if (command == null)
                {
                    Console.WriteLine("I don't know that command: " + command);
                    continue;
                }

                switch (command.Name)
                {
                    case "look":
                        Console.WriteLine(currentCountry?.currentRoom?.LongDescription);
                        customFunctions.PrintMap(currentCountry?.currentRoom?.ShortDescription);
                        break;

                    case "back":
                        if (currentCountry?.previousRoom == null)
                            Console.WriteLine("You can't go back from here!");
                        else
                            // currentRoom = previousRoom;
                            currentCountry.setRoom(currentCountry.previousRoom, currentCountry?.currentRoom);//can only go back once?
                        break;
                    case "travel":
                        if (command.SecondWord == null || command.SecondWord == "" || command.SecondWord == " ")
                        {
                            Console.WriteLine("Travel where?");
                            break;
                        }

                        Travel(command.SecondWord);
                        if (this.currentCountry?.currentRoom?.minigame != null)
                        {
                            this.currentCountry.currentRoom.ExecuteMinigame(ref score);
                        }
                        break;

                    case "north":
                    case "south":
                    case "east":
                    case "west":
                        Move(command.Name);
                        if (this.currentCountry?.currentRoom?.minigame != null)
                        {
                            this.currentCountry.currentRoom.ExecuteMinigame(ref score);
                        }
                        break;
                    case "map":
                        customFunctions.PrintMap(currentCountry?.currentRoom?.ShortDescription);
                        break;
                    case "play":
                        int scoreGot = 0;
                        int gameId = 0;
                        (scoreGot, gameId) = customFunctions.PlayGame(currentCountry, currentCountry.currentRoom, minigames, int.Parse(command?.SecondWord ?? "0"));
                        foreach (var minigame in minigames)
                        {
                            if (minigame.id == gameId)
                            {
                                if (minigame.score - scoreGot > 0)
                                {
                                    score += scoreGot;
                                    minigame.score -= scoreGot;
                                }
                                else
                                {
                                    score += minigame.score;
                                    minigame.score = 0;

                                }
                                break;
                            }
                        }

                        break;
                    case "playagain":
                        this.currentCountry?.currentRoom?.playAgain();
                        this.currentCountry?.currentRoom?.ExecuteMinigame(ref score);
                        break;
                    case "pick":
                        if (command.SecondWord == null || command.SecondWord == "" || command.SecondWord == " ")
                        {
                            helper.say("Pick what?");
                            break;
                        }
                        else
                        {
                            currentItem = command.SecondWord;
                            Console.WriteLine($"You picked {currentItem}");
                            //probably can pick up whatever 
                        }
                        break;
                    case "analyze":
                        if (command.SecondWord == null || command.SecondWord == "" || command.SecondWord == " ")
                        {
                            helper.say("Analyze what?");
                            break;
                        }
                        else
                        {
                            helper.analyze(command.SecondWord);
                            break;
                        }
                    case "configure":
                        if (command.SecondWord == null || command.SecondWord == "" || command.SecondWord == " ")
                        {
                            WeatherControl.stationGame();
                            break;
                        }
                        else
                        {
                            WeatherControl.configure(command.SecondWord);
                            break;
                        }
                    case "weather":
                        if (this.currentCountry?.ShortDescription == "Mozambique")

                        {
                            WeatherControl.GetWeather();

                        }
                        break;


                    case "score":
                        Console.WriteLine($"Your score is: {score}");
                        break;
                    case "quit":
                        continuePlaying = false;
                        break;

                    case "help":
                        PrintHelp();
                        break;
                    case "startminigame":
                        this.currentCountry?.currentRoom?.ExecuteMinigame(ref score);
                        break;

                    default:
                        Console.WriteLine("I don't know what command: " + command.Name + ".");
                        break;
                }
            }

            Console.WriteLine("Thank you for playing Five Countries!");
        } // instead of all cases implement dynamic method invocation

        public void Move(string direction)
        {
            if (currentCountry?.currentRoom?.Exits.ContainsKey(direction) == true)
            {
                // previousRoom = currentRoom;
                // currentRoom = currentRoom?.Exits[direction];
                currentCountry.setRoom(currentCountry.currentRoom?.Exits[direction], currentCountry.currentRoom);
                if (currentCountry.ShortDescription == "USA")
                {
                    CustomFunctions customFunctions = new CustomFunctions();
                    customFunctions.UNAmbassadorDialogue(currentCountry.currentRoom);
                }
            }
            else
            {
                Console.WriteLine($"You can't go {direction}!");
            }
        }
        public void Travel(string country)

        {
            if (currentCountry?.Exits.ContainsKey(country) == true)
            {
                helper.loading();

                previousCountry = currentCountry;
                currentCountry = currentCountry?.Exits[country];
                helper.say(write: currentCountry?.LongDescription);

            }
            else
            {
                Console.WriteLine($"You can't go to {country} yet!");
            }
            // Print the description of the new location (current room)
            Console.WriteLine(currentCountry?.currentRoom?.LongDescription);

            // Trigger the NPC dialogue if arriving in a room in the USA
            if (currentCountry?.ShortDescription == "USA" && currentCountry?.currentRoom != null)
            {
                Console.WriteLine("You've arrived here on the invitation of a UN ambassador. He's expecting your arrival!");

                // Trigger the NPC dialogue
                CustomFunctions customFunctions = new CustomFunctions();
                customFunctions.UNAmbassadorDialogue(currentCountry.currentRoom);
            }

        }


        private static void PrintWelcome()
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("""
 __      __       .__                                  __           ___________.__               _________                      __         .__              ._.
/  \    /  \ ____ |  |   ____  ____   _____   ____   _/  |_  ____   \_   _____/|__|__  __ ____   \_   ___ \  ____  __ __  _____/  |________|__| ____   _____| |
\   \/\/   // __ \|  | _/ ___\/  _ \ /     \_/ __ \  \   __\/  _ \   |    __)  |  \  \/ // __ \  /    \  \/ /  _ \|  |  \/    \   __\_  __ \  |/ __ \ /  ___/ |
 \        /\  ___/|  |_\  \__(  <_> )  Y Y  \  ___/   |  | (  <_> )  |     \   |  |\   /\  ___/  \     \___(  <_> )  |  /   |  \  |  |  | \/  \  ___/ \___ \ \|
  \__/\  /  \___  >____/\___  >____/|__|_|  /\___  >  |__|  \____/   \___  /   |__| \_/  \___  >  \______  /\____/|____/|___|  /__|  |__|  |__|\___  >____  >__
       \/       \/          \/            \/     \/                      \/                  \/          \/                  \/                    \/     \/ \/
""");
            Console.ResetColor();
            Console.WriteLine();
        }

        private static void PrintHelp()
        {
            Console.WriteLine("You've been sent by the United Nations to complete various tasks in the following countries:");
            Console.WriteLine("Haiti");
            Console.WriteLine("Mozambique");
            Console.WriteLine("India");
            Console.WriteLine("Brazil");
            Console.WriteLine("USA");
            Console.WriteLine("");
            Console.WriteLine("Navigate by typing 'north', 'south', 'east', or 'west'.");
            Console.WriteLine("Travel between countries by typing 'travel' and the name of the country. ");
            Console.WriteLine("Type 'look' for more details.");
            Console.WriteLine("Type 'map' to see the map.");
            Console.WriteLine("Type 'back' to go to the previous room.");
            Console.WriteLine("Type 'help' to print this message again.");
            Console.WriteLine("Type 'quit' to exit the game.");
            Console.WriteLine("Type 'playagain' to repeat the quest.");
            Console.WriteLine("Type 'stoptalking' to stop ongoing conversation.");
        }
    }
}
