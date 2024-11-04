using System;
using System.Collections.Generic;
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