using System.Security.Cryptography.X509Certificates;
using WorldOfZuul;

namespace FiveCountries
{
    public class Game : Init
    {

        public event EventHandler? CountryChanged;
        private Country? cc;

        private List<Country> Countries;
        public Country? currentCountry
        {
            get => cc;
            set
            {
                if (cc != value)
                {
                    cc = value;
                    OnCountryChanged();
                }
            }
        }




        public Game()
        {
            Countries = CreateCountries()!;
            this.currentCountry = Countries[0]!;
            CreateRooms(Countries);

        }

        public void Play()
        {
            Console.ResetColor();
            Parser parser = new();
            CustomFunctions customFunctions = new();

            Console.ResetColor();
            PrintWelcome();
            PrintHelp();

            bool continuePlaying = true;

            while (continuePlaying)
            {

                helper.say(location: currentCountry?.ShortDescription + " " + currentCountry?.currentRoom?.ShortDescription + " >");


                string input = "";

                {
                    input = Console.ReadLine();
                }

                if (string.IsNullOrEmpty(input))
                {
                    continue;
                }

                Command? command = parser.GetCommand(input.ToLower().Trim());

                if (command == null)
                {
                    Console.WriteLine("I don't know that command: " + command);
                    continue;
                }

                switch (command.Name)
                {

                    case "look":
                        Console.WriteLine(currentCountry?.currentRoom?.LongDescription);
                        break;

                    case "back":
                        if (currentCountry?.previousRoom == null)
                            Console.WriteLine("You can't go back from here!");
                        else
                            currentCountry.setRoom(currentCountry.previousRoom, currentCountry?.currentRoom);
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
                            this.currentCountry.currentRoom.ExecuteMinigame();
                        }
                        break;

                    case "north":
                    case "south":
                    case "east":
                    case "west":
                        Move(command.Name);
                        break;
                    case "map":
                        customFunctions.PrintMap4(currentCountry, currentCountry?.currentRoom?.ShortDescription);
                        break;
                    case "playagain":
                        this.currentCountry?.currentRoom?.playAgain();
                        this.currentCountry?.currentRoom?.ExecuteMinigame();
                        break;
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
                    case "quit":
                        continuePlaying = false;
                        break;
                    case "help":
                        PrintHelp();
                        break;
                    case "plant":
                        if (command.SecondWord == null || command.SecondWord == "" || command.SecondWord == " ")
                        {
                            FieldControl.printMap();
                            helper.say(write: "Plant where? Use the same command with xy coordinates, for example: [plant 16] to plant in the first row and 6th column.");
                            break;
                        }
                        FieldControl.plantMangroves(command.SecondWord);
                        break;
                    case "unplant":
                        if (command.SecondWord == null || command.SecondWord == "" || command.SecondWord == " ")
                        {
                            FieldControl.printMap();
                            helper.say(write: "Unplant where? Use the same command with xy coordinates, for example: [unplant 16] to unplant in the first row and 6th column.");
                            break;
                        }
                        FieldControl.removeMangroves(command.SecondWord);
                        break;
                    case "stats":
                        this.stats();
                        break;
                    default:
                        Console.WriteLine("I don't know what command: " + command.Name + ".");
                        break;
                }
            }

            Console.WriteLine("Thank you for playing Five Countries!");
            Console.WriteLine("These are your stats: ");
            this.stats();
            Console.ResetColor();
        }

        public void Move(string direction)
        {
            if (currentCountry?.currentRoom?.Exits.ContainsKey(direction) == true)
            {
                currentCountry.setRoom(currentCountry.currentRoom?.Exits[direction], currentCountry.currentRoom);
                if (this.currentCountry?.currentRoom?.minigame != null)
                {
                    this.currentCountry.currentRoom.ExecuteMinigame();
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
                Console.Clear();
                helper.loading();
                currentCountry = currentCountry?.Exits[country];

            }
            else
            {
                Console.WriteLine($"You can't go to {country} yet!");
            }
            Console.WriteLine(currentCountry?.currentRoom?.LongDescription);

            if (currentCountry?.ShortDescription == "USA" && currentCountry?.currentRoom != null)
            {
                switch (currentCountry.currentRoom.ShortDescription)
                {
                    case "NYC": // New York City
                        Console.WriteLine("You've arrived here on the invitation of a UN ambassador. He's expecting your arrival!");
                        break;
                    case "LA": // Los Angeles
                        Console.WriteLine("Welcome to Los Angeles! The city of stars is facing its own waste management crisis.");
                        break;
                    case "SF": // San Francisco
                        Console.WriteLine("Hello from San Francisco! We need your help to tackle our food waste and composting issues.");
                        break;
                    case "HOU": // Houston
                        Console.WriteLine("Welcome to Houston! The Gulf's oil spill problem requires urgent attention, and you're here to help.");
                        break;
                    case "CHI": // Chicago
                        Console.WriteLine("Welcome to Chicago! We need your expertise to combat urban air pollution and emissions.");
                        break;
                    default:
                        Console.WriteLine("Welcome! Your environmental mission begins here.");
                        break;
                }


            }

        }
        public void ExplicitMove(string room)
        {
            currentCountry.setRoom(currentCountry.Rooms.Where(r => r.ShortDescription == room).First(), currentCountry.currentRoom);
            if (this.currentCountry?.currentRoom?.minigame != null)
            {
                this.currentCountry.currentRoom.ExecuteMinigame();
            }
        }

        public void OnCountryChanged()
        {
            CountryChanged?.Invoke(this, EventArgs.Empty);

        }
        public void CountryChangedHandler(object sender, EventArgs e)
        {
            if (this.currentCountry?.ShortDescription == "Mozambique")
            {
                WeatherControl.StartWeather();
            }
            else
            {
                WeatherControl.StopWeather();
            }
        }

        private void stats()
        {
            List<string> FinishedOutcomes = new List<string>();
            List<string> UnfinishedOutcomes = new List<string>();
            int totalScore = 0;
            int completedScore = 0;
            this.Countries.ForEach(country => country.Rooms.ForEach(room =>
            {

                if (room.outcome != "")
                {
                    totalScore++;

                    if (room.minigameCompleted == true)
                    {
                        completedScore++;
                        FinishedOutcomes.Add(room.outcome);

                    }
                    else
                    {
                        UnfinishedOutcomes.Add(room.outcome);
                    }
                }

            }));


            Console.WriteLine("You have completed " + completedScore + " out of " + totalScore + " minigames: ");

            Console.ForegroundColor = ConsoleColor.Green;
            foreach (string outcome in FinishedOutcomes)
            {
                Console.WriteLine("You have " + outcome);
            }

            Console.ForegroundColor = ConsoleColor.Red;
            foreach (string outcome in UnfinishedOutcomes)
            {
                Console.WriteLine("You haven't " + outcome);
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
            Console.WriteLine(@"

You've been sent by the United Nations to complete various tasks in the following countries:

            Haiti        Mozambique        India        Brazil        USA

Travel between the countries freely by typing 'travel <name of country>'.

Within the country, explore rooms by typing 'north', 'south', 'east', or 'west'.

Other usefull commands:
    <look> to get the description of your current room
    <map> to print the map
    <stats> to know how many quests you have completed
    <playagain> to repeat the quest
    <help> to print the available commands again
    <quit> to quit the game

Quest specific commands might be revealed once you begin a quest.
During a dialoque you can only choose from the available options or the command 'stoptalking'.
            ");
        }
    }
}
