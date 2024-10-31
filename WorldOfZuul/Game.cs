namespace FiveCountries
{
    public class Game : Init
    {

        private Country? currentCountry;
        private Country? previousCountry; //back command for country if needed

        public Game()
        {
            //initialize the game
            List<Country> Countries = CreateCountries();
            this.currentCountry = Countries[0];
            List<Room> Rooms = CreateRooms();
            QuickAssign(Rooms, Countries);
        }

        public void Play()
        {
            Parser parser = new();
            CustomFunctions customFunctions = new();
            PrintWelcome();

            bool continuePlaying = true;
            while (continuePlaying)


            // note below
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(currentCountry?.ShortDescription);

                Console.ResetColor();
                Console.WriteLine(currentCountry?.currentRoom?.ShortDescription);
                Console.Write("> ");

                string? input = Console.ReadLine();

                if (string.IsNullOrEmpty(input))
                {
                    Console.WriteLine("Please enter a command.");
                    continue;
                }

                Command? command = parser.GetCommand(input.ToLower());
                // 


                // 

                if (command == null)
                {
                    Console.WriteLine("I don't know that command: "+command);
                    continue;
                }

                switch (command.Name)
                {
                    case "look":
                        Console.WriteLine(currentCountry?.currentRoom?.LongDescription);
                        customFunctions.PrintMap2(currentCountry?.currentRoom?.ShortDescription);
                        break;

                    case "back":
                        if (currentCountry?.previousRoom == null)
                            Console.WriteLine("You can't go back from here!");
                        else
                            // currentRoom = previousRoom;
                            currentCountry.setRoom(currentCountry.previousRoom, currentCountry?.currentRoom);//can only go back once?
                        break;
                    case "travel":
                        Travel(command.SecondWord);
                        Console.WriteLine(currentCountry?.LongDescription);
                        break;
                    case "north":
                    case "south":
                    case "east":
                    case "west":
                        Move(command.Name);
                        break;

                    case "quit":
                        continuePlaying = false;
                        break;

                    case "help":
                        PrintHelp();
                        break;

                    default:
                        Console.WriteLine("I don't know what command: "+command.Name+".");
                        break;
                }
            }

            Console.WriteLine("Thank you for playing Five Countries!");
        } // instead of all cases implement dynamic method invocation

        private void Move(string direction)
        {
            if (currentCountry?.currentRoom?.Exits.ContainsKey(direction) == true)
            {
                // previousRoom = currentRoom;
                // currentRoom = currentRoom?.Exits[direction];
                currentCountry.setRoom(currentCountry.currentRoom?.Exits[direction], currentCountry.currentRoom);

            }
            else
            {
                Console.WriteLine($"You can't go {direction}!");
            }
        }
        private void Travel(string country)

        {
            if (currentCountry?.Exits.ContainsKey(country) == true)
            {
                previousCountry = currentCountry;
                currentCountry = currentCountry?.Exits[country];

            }
            else
            {
                Console.WriteLine($"You can't go to {country} yet!");
            }
        }


        private static void PrintWelcome()
        {
            Console.WriteLine("Welcome to Five Countries!");
            Console.WriteLine("Five Countries is a new, incredibly boring adventure game.");
            PrintHelp();
            Console.WriteLine();
        }

        private static void PrintHelp()
        {
            Console.WriteLine("You are lost. You are alone. You wander");
            Console.WriteLine("around the university.");
            Console.WriteLine();
            Console.WriteLine("Navigate by typing 'north', 'south', 'east', or 'west'.");
            Console.WriteLine("Travel between countries by typing 'travel' and the name of the country. ");
            Console.WriteLine("Type 'look' for more details.");
            Console.WriteLine("Type 'back' to go to the previous room.");
            Console.WriteLine("Type 'help' to print this message again.");
            Console.WriteLine("Type 'quit' to exit the game.");
        }
    }
}
