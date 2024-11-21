using System;
using System.Collections.Generic;
using System.Data;
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
        MinigameCode minigamesCode = new();


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


        public void PrintMap2(Country Country, string room){

            // get position of the room in the map
            static (int, int) getPos(string[,] map, string room){
                for(int i = 0; i < 11; i++){
                    for(int j = 0; j < 11; j++){
                        if (map[i, j] == room){
                            return (i, j);
                        }
                    }
                }
                return (-1, -1);
            }

            //MAX map size is 11x11AND the furthest room can be in 5 connections
            string[,] map = new string[11,11];
            List<String> roomsAdded = new List<String>();
            Console.WriteLine("\n\n-------MAP------");
            bool first = true;

            foreach (Room room2 in Country.Rooms){
                if (first){
                    map[5, 5] = room2.ShortDescription;
                    roomsAdded.Add(room2.ShortDescription);
                    first = false;
                }
                foreach (var exit in room2.Exits){
                    Console.Write(room2.ShortDescription+" "+exit.Value.ShortDescription+" "+exit.Key+"\n");

                    if (roomsAdded.Contains(exit.Value.ShortDescription)){
                        continue;
                    }
                    //just print map
                    Console.WriteLine("Current map:");
                    for(int i = 0; i < 11; i++){
                        for(int j = 0; j < 11; j++){
                                Console.Write((map[i, j]??"").PadLeft(8));
                                Console.Write(",");
                        }
                        Console.WriteLine();
                    }

                    (int, int) lastRoomPos = getPos(map, room2.ShortDescription);
                    Console.WriteLine(lastRoomPos.Item1+" "+lastRoomPos.Item2);
                    if (lastRoomPos.Item1 == -1){
                        lastRoomPos = getPos(map, exit.Value.ShortDescription);
                        Console.WriteLine(lastRoomPos.Item1+" "+lastRoomPos.Item2);
                        if (lastRoomPos.Item1 == -1){
                            throw new Exception("Rooms not found in map");
                        }
                        break;
                    }
                    (int, int) direction = (0, 0);
                    switch(exit.Key){
                        case "north":
                            direction = (-1, 0);
                            break;
                        case "south":
                            direction = (1, 0);
                            break;
                        case "east":
                            direction = (0, 1);
                            break;
                        case "west":
                            direction = (0, -1);
                            break;
                    }
                    map[lastRoomPos.Item1 + direction.Item1, lastRoomPos.Item2 + direction.Item2] = exit.Value.ShortDescription;
                    break;
                }
            }


            //just print map
            Console.WriteLine("Current map:");
            for(int i = 0; i < 11; i++){
                for(int j = 0; j < 11; j++){
                        Console.Write((map[i, j]??"").PadLeft(8));
                        Console.Write(",");
                }
                Console.WriteLine();
            }

        }


        public void PrintMap3(Country Country, string room){
            static void smallPrintMap(List<List<string>> map){
                Console.WriteLine("----Current map:----");
                foreach (var row in map){
                    foreach (var room in row){
                        Console.Write(room.PadLeft(8));
                        Console.Write(",");
                    }
                    Console.WriteLine();
                }
                Console.WriteLine("--------------------");
            }

            static (int, int) getPos(List<List<string>> map, string room){
                for(int i = 0; i < map.Count; i++){
                    for(int j = 0; j < map[i].Count; j++){
                        if (map[i][j] == room){
                            return (i, j);
                        }
                    }
                }
                return (-1, -1);
            }

            static (int, int) getDimensions(List<List<string>> map){
                return (map.Count, map.Max(x => x.Count));
            }
            static void addRoom(ref List<List<string>> map, string room, string exit, string nextRoom){
                (int, int) roomPos = getPos(map, room);
                (int, int) direction = (0, 0);
                switch(exit){
                    case "north":
                        direction = (-1, 0);
                        break;
                    case "south":
                        direction = (1, 0);
                        break;
                    case "east":
                        direction = (0, 1);
                        break;
                    case "west":
                        direction = (0, -1);
                        break;
                }
                //check it it gets out of bounds
                (int, int) pos = (roomPos.Item1 + direction.Item1, roomPos.Item2 + direction.Item2);
                if (pos.Item1 < 0){
                    (int, int) size = getDimensions(map);
                    map.Insert(0, Enumerable.Repeat("", size.Item1+1).ToList());
                }
                if(pos.Item2 < 0){
                    foreach (var row in map){
                        row.Insert(0, "");
                    }
                }
                if(pos.Item1 >= map.Count){
                    (int, int) size = getDimensions(map);
                    map.Add(Enumerable.Repeat("", size.Item1+1).ToList());
                }
                if(pos.Item2 >= map[pos.Item1].Count){
                    foreach (var row in map){
                        row.Add("");
                    }
                }

                roomPos = getPos(map, room);
                map[roomPos.Item1+direction.Item1][roomPos.Item2+direction.Item2] = nextRoom;
            }

            List<List<string>> map = new List<List<string>>();
            List<string> alreadyAdded = [Country.Rooms[0].ShortDescription];
            List<(string, string, string)> notAddedRooms = new List<(string, string, string)>();
            map.Add(new List<string>{Country.Rooms[0].ShortDescription});
            foreach(Room room2 in Country.Rooms){
                Console.WriteLine("===== Working on =======");
                Console.WriteLine(room2.ShortDescription);
                foreach(var exit in room2.Exits){

                    if (alreadyAdded.Contains(exit.Value.ShortDescription)){
                        if(alreadyAdded.Contains(room2.ShortDescription)){
                            continue;
                            //add here later
                            //code for adding "doors"
                        }else{
                            alreadyAdded.Add(room2.ShortDescription);
                            addRoom(ref map, exit.Value.ShortDescription, exit.Key, room2.ShortDescription);
                            smallPrintMap(map);
                        }

                    }else{
                        if(alreadyAdded.Contains(room2.ShortDescription)){
                            alreadyAdded.Add(exit.Value.ShortDescription);
                            addRoom(ref map, room2.ShortDescription, exit.Key, exit.Value.ShortDescription);
                            smallPrintMap(map);
                        }else{
                        notAddedRooms.Add((room2.ShortDescription, exit.Key, exit.Value.ShortDescription));
                        }
                    }
                    //Console.WriteLine(room2.ShortDescription+" "+exit.Key+" "+exit.Value.ShortDescription);
                }
                smallPrintMap(map);
            }
            int counter = 0;
            int lastCountOfNotAdded = notAddedRooms.Count;
            foreach(var roomNot in notAddedRooms){
                alreadyAdded.Add(roomNot.Item1);//not sure if its Item1, to CHECK
                addRoom(ref map, roomNot.Item1, roomNot.Item2, roomNot.Item3);
                smallPrintMap(map);
            }

            Console.WriteLine($"Not added rooms:{notAddedRooms.Count}");
            foreach (var roomNot in notAddedRooms){
                Console.WriteLine(roomNot);
            }
            
        }

        public void PrintMap4(Country Country, string room){
            //only for develompent smallPrintMap s
            static void smallPrintMap(List<List<(List<string>,string)>> map){
                Console.WriteLine("----Current map2:----");
                Console.WriteLine("----map:----");
                foreach (var row in map){
                    foreach (var room in row){
                        Console.Write(room.Item2.PadLeft(8));
                        Console.Write(",");
                    }
                    Console.WriteLine();
                }
                Console.WriteLine("----exits:----");
                foreach (var row in map){
                    foreach (var room in row){
                        string str= "";
                        foreach(string exit in room.Item1){
                            str += exit;
                        }
                        Console.Write(str.PadLeft(8));
                        Console.Write(",");
                    }
                    Console.WriteLine();
                }
                Console.WriteLine("--------------------");
            }

            static (int, int) getPos(List<List<(List<string>,string)>> map, string room){
                for(int i = 0; i < map.Count; i++){
                    for(int j = 0; j < map[i].Count; j++){
                        //string roomNameWOexits = String.Join("", room.Split('+','-'));//weird way to remove exits
                        //if (roomNameWOexits == room){
                        if (map[i][j].Item2 == room){
                            return (i, j);
                        }
                    }
                }
                return (-1, -1);
            }
            static void addRoom(ref List<List<(List<string>,string)>> map, string room, string exit, string nextRoom){
                (int, int) roomPos = getPos(map, room);
                (int, int) direction = (0, 0);
                switch(exit){
                    case "north":
                        direction = (-1, 0);
                        break;
                    case "south":
                        direction = (1, 0);
                        break;
                    case "east":
                        direction = (0, 1);
                        break;
                    case "west":
                        direction = (0, -1);
                        break;
                }
                //check it it gets out of bounds
                (int, int) posNewRoom = (roomPos.Item1 + direction.Item1, roomPos.Item2 + direction.Item2);
                if (posNewRoom.Item1 < 0){
                    map.Insert(0, Enumerable.Repeat((new List<string>{}, ""), map[0].Count).ToList());
                    posNewRoom.Item1 = 0;
                }
                if(posNewRoom.Item2 < 0){
                    foreach (var row in map){
                        row.Insert(0, (new List<string>{}, ""));
                    }
                    posNewRoom.Item2 = 0;
                }
                if(posNewRoom.Item1 >= map.Count){
                    map.Add(Enumerable.Repeat((new List<string>{}, ""), map[0].Count).ToList());
                }
                if(posNewRoom.Item2 >= map[posNewRoom.Item1].Count){
                    foreach (var row in map){
                        row.Add((new List<string>{}, ""));
                    }
                }
                //var temp = map[posNewRoom.Item1][posNewRoom.Item2];
                //temp.Item2 = nextRoom;
                map[posNewRoom.Item1][posNewRoom.Item2] = (new List<string>{}, nextRoom);//temp;
                
            }

            static string PaddingCenter(string source, int length){
                int spaces = length - source.Length;
                int padLeft = spaces/2 + source.Length;
                return source.PadLeft(padLeft).PadRight(length);

            }

            static void drawMap(List<List<(List<string>,string)>> map, List<string> alreadyAdded, string roomToHighlight){
                CustomFunctions customFunctions = new CustomFunctions();
                int maxLenght = alreadyAdded.Max(x => x.Length);
                if(maxLenght > 14){
                    maxLenght = 14;
                }
                Console.WriteLine("----Current map:----");

                //Draw horizontal lines
                string horizontalLine = "";
                string horizontalLineBlank = "";
                for(int i = 0; i < map[0].Count; i++){
                    horizontalLine += "+";
                    horizontalLineBlank += "|";
                    for(int j = 0; j < maxLenght+4; j++){
                        horizontalLine += "-";
                        horizontalLineBlank += " ";
                    }
                    
                }
                horizontalLine += "+";
                horizontalLineBlank += "|";
                Console.WriteLine(horizontalLine);

                foreach(var row in map){
                    string line = "";
                    string horizontalLineWExits = "";
                    foreach(var roomAllData in row){
                        string room = roomAllData.Item2;
                        if(!roomAllData.Item1.Contains("w")){
                            line += "|";
                        }else{
                            line += " ";
                        }
                        horizontalLineWExits += "+";
                        if(!roomAllData.Item1.Contains("s")){
                            for(int j = 0; j < maxLenght+4; j++){
                                horizontalLineWExits += "-";
                            }
                        }else{
                            if(maxLenght%2 == 0){
                                for(int j = 0; j < (maxLenght/2)+1; j++){
                                    horizontalLineWExits += "-";
                                }
                                horizontalLineWExits += "   ";
                                for(int j = 0; j < (maxLenght/2)+0; j++){
                                    horizontalLineWExits += "-";
                                }
                            }else{
                                for(int j = 0; j < (maxLenght/2)+1; j++){
                                    horizontalLineWExits += "-";
                                }
                                horizontalLineWExits += "   ";
                                for(int j = 0; j < (maxLenght/2)+1; j++){
                                    horizontalLineWExits += "-";
                                }
                            }
                        }

                        line += PaddingCenter(room.Substring(0, Math.Min(maxLenght, room.Length)),maxLenght+4);
                    }
                    line += "|";
                    horizontalLineWExits += "+";
                    string[] finalLine = line.Split(roomToHighlight);

                    Console.WriteLine(horizontalLineBlank);
                    if(finalLine.Length == 1){
                        Console.WriteLine(line);
                    }else{
                        customFunctions.PrintStringColorful([finalLine[0], roomToHighlight, finalLine[1]], [ConsoleColor.White, ConsoleColor.Green, ConsoleColor.White]);
                    }
                    Console.WriteLine(horizontalLineBlank);
                    Console.WriteLine(horizontalLineWExits);
                }
            }
            
            List<List<(List<string>,string)>> map = new List<List<(List<string>,string)>>();//map of the rooms
            List<string> alreadyAdded = [Country.Rooms[0].ShortDescription];//list of rooms that are already added to the map
            List<(string, string, string)> notAddedRooms = new List<(string, string, string)>();//list of rooms that are not added to the map yet
            map.Add(new List<(List<string>,string)> {(new List<string>{}, Country.Rooms[0].ShortDescription)});//addidng the first room to the map

            foreach(Room roomCurrent in Country.Rooms){//run for every room in the country
                foreach(var exit in roomCurrent.Exits){//run  for every exit of the room
                    string currentRoom = roomCurrent.ShortDescription;
                    string exitDirection = exit.Key;
                    string nextRoom = exit.Value.ShortDescription;

                    //check if the current room is already added
                    if (alreadyAdded.Contains(currentRoom)){
                        if(alreadyAdded.Contains(nextRoom)){
                            continue;
                        }else{
                            alreadyAdded.Add(nextRoom);
                            addRoom(ref map, currentRoom, exitDirection, nextRoom);
                        }
                    }else{
                        if(alreadyAdded.Contains(nextRoom)){
                            alreadyAdded.Add(currentRoom);
                            addRoom(ref map, nextRoom, exitDirection, currentRoom);
                        }else{
                            notAddedRooms.Add((currentRoom, exitDirection, nextRoom));
                        }
                    }
                }
            }
            int lastCountOfNotAdded = notAddedRooms.Count;
            int counter = 0;
            while(true){
                if (notAddedRooms.Count == 0){
                    break;
                }
                foreach((string, string, string) roomCurrent in notAddedRooms){
                    if (alreadyAdded.Contains(roomCurrent.Item1)){
                        if(alreadyAdded.Contains(roomCurrent.Item3)){
                            notAddedRooms.Remove(roomCurrent);
                        }else{
                            alreadyAdded.Add(roomCurrent.Item3);
                            addRoom(ref map, roomCurrent.Item1, roomCurrent.Item2, roomCurrent.Item3);
                            notAddedRooms.Remove(roomCurrent);
                        }
                    }else{
                        if(alreadyAdded.Contains(roomCurrent.Item3)){
                            alreadyAdded.Add(roomCurrent.Item1);
                            addRoom(ref map, roomCurrent.Item3, roomCurrent.Item2, roomCurrent.Item1);
                            notAddedRooms.Remove(roomCurrent);
                        }
                    }
                }
                counter++;
                if (lastCountOfNotAdded == notAddedRooms.Count){
                    break;
                    string notAddedRoomsString = "";
                    foreach(var room3 in notAddedRooms){
                        notAddedRoomsString += room3.Item1+" "+room3.Item2+" "+room3.Item3+"\n";
                    }
                    throw new Exception("Map generation failed. Room(s) not connected. Check the room(s):\n"+notAddedRoomsString);
                }
            }
            
            //just rewrite the array to the new one
            List<List<(List<string>, string)>> map2 = new List<List<(List<string>, string)>>();
            for(int i = 0; i < map.Count; i++){
                map2.Add(new List<(List<string>, string)>());
                for(int j = 0; j < map[i].Count; j++){
                    map2[i].Add(map[i][j]);
                }
            }
            //add exits
            foreach(Room roomCurrent in Country.Rooms){
                foreach(var exit in roomCurrent.Exits){
                    //Console.WriteLine(roomCurrent.ShortDescription+" "+exit.Key+" "+exit.Value.ShortDescription);
                    //string roomNameWOexits = String.Join("", roomCurrent.ShortDescription.Split('+','-'));//weird way to remove exits but works
                    (int, int) roomPos = getPos(map2, roomCurrent.ShortDescription);
                    string exitThis = "";
                    switch(exit.Key){
                        case "north":
                            exitThis = "n";
                            break;
                        case "south":
                            exitThis = "s";
                            break;
                        case "east":
                            exitThis = "e";
                            break;
                        case "west":
                            exitThis = "w";
                            break;
                    }
                    (List<string>, string) roomSth = (map2[roomPos.Item1][roomPos.Item2].Item1, map2[roomPos.Item1][roomPos.Item2].Item2);
                    roomSth.Item1.Add(exitThis);
                    map2[roomPos.Item1][roomPos.Item2] = roomSth;

                }
            }

            drawMap(map2, alreadyAdded, room);
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