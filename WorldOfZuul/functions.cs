using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace FiveCountries
{
    public class CustomFunctions{
        public void PrintMap2(string room){
            Console.WriteLine("\n-- -- -- -- --  MAP  -- -- -- -- -- --");
            Console.WriteLine("+---------+------------+-------------+");
            Console.WriteLine("|         |            |             |");
            switch(room){
                case "Pub":
                    //Console.WriteLine("|   Pub       Office       Theatre   |");
                    string[] text = {"|   ", "Pub", "       Outside      Theatre   |"};
                    ConsoleColor[] colors = {ConsoleColor.White, ConsoleColor.Green, ConsoleColor.White};
                    PrintStringColorful(text, colors);
                    break;
                case "Outside":
                    //Console.WriteLine("|   Pub       Outside      Theatre   |");
                    string[] text2 = {"|   Pub       ", "Outside", "      Theatre   |"};
                    ConsoleColor[] colors2 = {ConsoleColor.White, ConsoleColor.Green, ConsoleColor.White};
                    PrintStringColorful(text2, colors2);
                    break;
                case "Theatre":
                    //Console.WriteLine("|   Pub       Outside      Theatre   |");
                    string[] text3 = {"|   Pub       Outside      ", "Theatre", "   |"};
                    ConsoleColor[] colors3 = {ConsoleColor.White, ConsoleColor.Green, ConsoleColor.White};
                    PrintStringColorful(text3, colors3);
                    break;
                default:
                    Console.WriteLine("|   Pub       Outside      Theatre   |");
                    break;
            }
            Console.WriteLine("|         |            |             |");
            Console.WriteLine("+---------++---   ---+-+----------+--+");
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
    }
}