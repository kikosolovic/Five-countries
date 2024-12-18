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

        public void PrintMap4(Country Country, string room){
            static (int, int) getPos(List<List<(List<string>,string)>> map, string room){
                for(int i = 0; i < map.Count; i++){
                    for(int j = 0; j < map[i].Count; j++){
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
                map[posNewRoom.Item1][posNewRoom.Item2] = (new List<string>{}, nextRoom);
                
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
                    string[] finalLine = line.Split(roomToHighlight.Substring(0, Math.Min(maxLenght, roomToHighlight.Length)));

                    Console.WriteLine(horizontalLineBlank);
                    if(finalLine.Length == 1){
                        Console.WriteLine(line);
                    }else{
                        customFunctions.PrintStringColorful([finalLine[0], roomToHighlight.Substring(0, Math.Min(maxLenght, roomToHighlight.Length)), finalLine[1]], [ConsoleColor.White, ConsoleColor.Green, ConsoleColor.White]);
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
                    if (roomPos.Item1 != -1){
                        (List<string>, string) roomSth = (map2[roomPos.Item1][roomPos.Item2].Item1, map2[roomPos.Item1][roomPos.Item2].Item2);
                        roomSth.Item1.Add(exitThis);
                        map2[roomPos.Item1][roomPos.Item2] = roomSth;
                    }
                    

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
        

        

        



    }



}