using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace FiveCountries
{
    public class CustomFunctions{
        MinigameCode minigamesCode = new();

        public void PrintMap(string room){
            Console.WriteLine("\n-- -- -- -- --  MAP  -- -- -- -- -- --       ^ N");
            Console.WriteLine("+---------+------------+-------------+       |");
            Console.WriteLine("|         |            |             |  W ---+---> E");
            switch(room){
                case "Pub":
                    //Console.WriteLine("|   Pub       Office       Theatre   |");
                    string[] text = {"|   ", "Pub", "       Outside      Theatre   |       |"};
                    ConsoleColor[] colors = {ConsoleColor.White, ConsoleColor.Green, ConsoleColor.White};
                    PrintStringColorful(text, colors);
                    break;
                case "Outside":
                    //Console.WriteLine("|   Pub       Outside      Theatre   |");
                    string[] text2 = {"|   Pub       ", "Outside", "      Theatre   |       |"};
                    ConsoleColor[] colors2 = {ConsoleColor.White, ConsoleColor.Green, ConsoleColor.White};
                    PrintStringColorful(text2, colors2);
                    break;
                case "Theatre":
                    //Console.WriteLine("|   Pub       Outside      Theatre   |");
                    string[] text3 = {"|   Pub       Outside      ", "Theatre", "   |       |"};
                    ConsoleColor[] colors3 = {ConsoleColor.White, ConsoleColor.Green, ConsoleColor.White};
                    PrintStringColorful(text3, colors3);
                    break;
                default:
                    Console.WriteLine("|   Pub       Outside      Theatre   |       |");
                    break;
            }
            Console.WriteLine("|         |            |             |       |");
            Console.WriteLine("+---------++---   ---+-+----------+--+       S");
            Console.WriteLine("           |         |            |");
            switch(room){
                case "Lab":
                    //Console.WriteLine("           |   Lab       Office   |");
                    string[] text4 = {"           |   ", "Lab", "       Office   |"};
                    ConsoleColor[] colors4 = {ConsoleColor.White, ConsoleColor.Green, ConsoleColor.White};
                    PrintStringColorful(text4, colors4);
                    break;
                case "Office":
                    //Console.WriteLine("           |   Lab       Office   |");
                    string[] text5 = {"           |   Lab       ", "Office", "   |"};
                    ConsoleColor[] colors5 = {ConsoleColor.White, ConsoleColor.Green, ConsoleColor.White};
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
                (int, int) posNewRoom = (roomPos.Item1 + direction.Item1, roomPos.Item2 + direction.Item2);
                if (posNewRoom.Item1 < 0){
                    (int, int) size = getDimensions(map);
                    map.Insert(0, Enumerable.Repeat("", size.Item1+1).ToList());
                    posNewRoom.Item1 = 0;
                }
                if(posNewRoom.Item2 < 0){
                    foreach (var row in map){
                        row.Insert(0, "");
                    }
                    posNewRoom.Item2 = 0;
                }
                if(posNewRoom.Item1 >= map.Count){
                    (int, int) size = getDimensions(map);
                    map.Add(Enumerable.Repeat("", size.Item1+1).ToList());
                }
                if(posNewRoom.Item2 >= map[posNewRoom.Item1].Count){
                    foreach (var row in map){
                        row.Add("");
                    }
                }
                map[posNewRoom.Item1][posNewRoom.Item2] = nextRoom;
            }
            
            List<List<string>> map = new List<List<string>>();//map of the rooms
            List<string> alreadyAdded = [Country.Rooms[0].ShortDescription];//list of rooms that are already added to the map
            List<(string, string, string)> notAddedRooms = new List<(string, string, string)>();//list of rooms that are not added to the map yet
            map.Add(new List<string>{Country.Rooms[0].ShortDescription});//addidng the first room to the map

            foreach(Room roomCurrent in Country.Rooms){//run for every room in the country
                //Console.WriteLine($"\n\n===== Working on {roomCurrent.ShortDescription}");
                foreach(var exit in roomCurrent.Exits){//run  for every exit of the room
                    string currentRoom = roomCurrent.ShortDescription;
                    string exitDirection = exit.Key;
                    string nextRoom = exit.Value.ShortDescription;

                    //Console.WriteLine(exitDirection+" "+nextRoom);

                    //check if the current room is already added
                    if (alreadyAdded.Contains(currentRoom)){
                        if(alreadyAdded.Contains(nextRoom)){
                            continue;
                            //check for the doors
                            //TODO:
                        }else{
                            alreadyAdded.Add(nextRoom);
                            addRoom(ref map, currentRoom, exitDirection, nextRoom);
                            //smallPrintMap(map);
                        }
                    }else{
                        if(alreadyAdded.Contains(nextRoom)){
                            alreadyAdded.Add(currentRoom);
                            addRoom(ref map, nextRoom, exitDirection, currentRoom);
                            //smallPrintMap(map);
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
                            //check for the doors
                            //TODO:
                            notAddedRooms.Remove(roomCurrent);
                        }else{
                            alreadyAdded.Add(roomCurrent.Item3);
                            addRoom(ref map, roomCurrent.Item1, roomCurrent.Item2, roomCurrent.Item3);
                            //smallPrintMap(map);
                            notAddedRooms.Remove(roomCurrent);
                        }
                    }else{
                        if(alreadyAdded.Contains(roomCurrent.Item3)){
                            alreadyAdded.Add(roomCurrent.Item1);
                            addRoom(ref map, roomCurrent.Item3, roomCurrent.Item2, roomCurrent.Item1);
                            //smallPrintMap(map);
                            notAddedRooms.Remove(roomCurrent);
                        }
                    }
                }
                counter++;
                if (lastCountOfNotAdded == notAddedRooms.Count){
                    break;
                }
            }
            smallPrintMap(map);
        }

/// <summary>
///     Prints all strings in text[], each in color from colors[] in the same line
/// </summary>
/// <param name="text">Array of strings to print</param>
/// <param name="colors">Array of colors to print</param>
        public void PrintStringColorful(string[] text, ConsoleColor[] colors){
            for(int i = 0; i < text.Length; i++){
                Console.ForegroundColor = colors[i];
                Console.Write(text[i]);
                Console.ResetColor();
            }
            Console.WriteLine();
            

        }
        
        public void PlayGame(Country country, Room room, List<Minigame> minigames, int gameNumber = 0){
            int counter = 1;
            List<Minigame> gamesForHere = new List<Minigame>();

            foreach (var minigame in minigames)// Get all games for this room
            {
                if (minigame.country == country.ShortDescription && minigame.room == room.ShortDescription){
                    gamesForHere.Add(minigame);
                }
            }
            if (gameNumber == 0){
                if (gamesForHere.Count == 0){
                    Console.WriteLine("Sorry, there are no games available in this room.");
                    return;
                }else{
                    Console.WriteLine("Here you can choose from the following games:");
                    foreach (var minigame in gamesForHere)
                    {
                        Console.WriteLine($"{counter}.{minigame.description}");
                        counter++;
                    }
                }
                Console.Write("# of the game you want to play: ");
                string? input = Console.ReadLine();
                gameNumber = int.Parse(input);
            }
            
            if (gameNumber > gamesForHere.Count || gameNumber < 1){
                Console.WriteLine("Invalid game number.");
                return;
            }

            int gameid = gamesForHere[gameNumber-1].id;

            //here add a call to the game
            switch(gameid){
                case 11:
                    minigamesCode.minigame11();
                    break;
                case 12:
                    minigamesCode.minigame12();
                    break;
                case 13:
                    minigamesCode.minigame13();
                    break;
                case 14:
                    minigamesCode.minigame14();
                    break;
                default:
                    Console.WriteLine("Invalid game number.");
                    break;
            }



        }


    }
}