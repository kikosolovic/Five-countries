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
                if (Console.KeyAvailable)
                {
                    Console.Write(text.Substring(text.IndexOf(ch)));

                    break;
                }
                Console.Write(ch);
                Thread.Sleep(i);
            }
            Console.WriteLine("\n");
        }



        public static void say(string text = null, string response = null, string options = null, string error = null, string location = null, string write = null)
        {//this is important because of the lock, so that only one thread can write at a time
            lock (ConsoleLock)
            {
                if (write != null)
                {
                    Console.WriteLine(write);
                }


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
                if (error != null && error != "")
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    helper.WriteWithDelay(error);
                    Console.ResetColor();
                }
                if (location != null && location != "")
                {
                    Console.ForegroundColor = ConsoleColor.Blue;
                    helper.WriteWithDelay(location);
                    Console.ResetColor();
                }


            }

        }
        public static void analyze(string item)
        {

            item = item.ToLower();
            switch (item)
            {
                case "hammer":
                    helper.say(write: "Perfect! A hammer is a great tool to smash the weather station with. ");
                    break;
                case "screwdriver":
                    helper.say(write: "Screwdriver");
                    break;
                default:

                    helper.say(write: "Probably can't use that in this situation.");
                    break;


            }

        }
        public static void getGame(Game game)
        {
            _game = game;
        }
        public static void loading()
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
        public static string parseinput(string input)
        {
            return input.ToLower().Trim();
        }

    }




}