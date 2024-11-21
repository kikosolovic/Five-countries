using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WorldOfZuul;

namespace FiveCountries
{
    public static class helper
    {
        public static Game _game;
        private static readonly object ConsoleLock = new object();

        public static void WriteWithDelay(string text)

        {

            var i = (text.Length > 70) ? 10 : 30;
            foreach (var ch in text)
            {
                Console.Write(ch);
                Thread.Sleep(i);
            }
            Console.WriteLine("\n");
        }


        public static void say(string text = null, string response = null, string options = null, string write = null)
        {//add pretty text, slow rolling or sometjhig
            lock (ConsoleLock)
            {
                if (write != null)
                {
                    WriteWithDelay(write);
                }
                else
                {

                    if (text != null && text != "")
                    {
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        helper.WriteWithDelay(">> " + text);

                        Console.ResetColor();
                    }


                    if (response != null && response != "")
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        helper.WriteWithDelay(">> " + response);
                        Console.ResetColor();
                    }

                    if (options != null && options != "")
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        helper.WriteWithDelay(">> " + options);
                        Console.ResetColor();
                    }

                }
            }
        }
        public static void getGame(Game game)
        {
            _game = game;
        }
    }


}