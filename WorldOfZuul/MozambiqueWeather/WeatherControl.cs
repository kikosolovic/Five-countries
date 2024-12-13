using System;
using System.Collections.Generic;
using System.Configuration.Assemblies;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Threading.Tasks;
using System.Transactions;
using FiveCountries;



namespace WorldOfZuul
{
    public static class WeatherControl
    {

        private static bool _weatherRunning = true;
        private static bool _stationFixed = false;
        private static string _currentWeather = "sunny";
        private static bool _realstorm = false;
        public static bool _swept = false;
        public static bool _10toSweep = false;
        public static bool _tutorial = true;
        public static List<string> _toConfigure = new List<string> { "sunny", "rainy", "stormy" };
        private static Random _random = new Random();

        public static void StartWeather()
        {
            // if (!_realstorm)
            // {
            //     helper.say(write: "The wind is picking up.");
            //     helper.say(write: "The weather is getting worse");
            //     helper.say(write: "It is starting to rain");
            //     helper.say(write: "The weather is getting worse");
            //     helper.say(write: "The weather is getting worse");
            //     _realstorm = true;
            // }

            string[] options = _stationFixed ? new string[] { "sunny", "sunny", "sunny", "cloudy", "rainy", "stormy" } : new string[] { "sunny", "windy", "cloudy", "rainy", "rainy", "rainy", "stormy" };
            Thread thread = new Thread(() =>

            {
                while (_weatherRunning)
                {
                    if (_tutorial)
                    {
                        helper.say(write: "You have 10 seconds to get into a shelter inside the village or you will be swept back whence you came from.");
                        Thread.Sleep(10000);

                        if (Program._game.currentCountry.currentRoom.ShortDescription != "Shelter")
                        {

                            helper.say(write: "\nYou are lucky, somebody pulled you into the shelter right before the storm hit.");
                            Program._game.Move("north");
                            Thread.Sleep(1000);
                            Console.WriteLine(Program._game.currentCountry?.ShortDescription + " " + Program._game.currentCountry?.currentRoom?.ShortDescription + " >");
                            helper.say(write: "you are here");
                        }
                        _tutorial = false;

                    }
                    else
                    {


                        if (_currentWeather == "windy")
                        {
                            helper.say(write: "The wind is picking up. In these parts that might mean a storm is comming.");
                        }
                        if (_currentWeather == "cloudy")
                        {
                            helper.say(write: "It's getting cloudy outside. Do you know where to hide if you need to?");
                        }
                        if (_currentWeather == "rainy")
                        {
                            helper.say(write: "It's getting rainy outside. You should hide in case a storm is coming.");
                            Thread.Sleep(15000);
                            _currentWeather = _random.Next(2) == 0 ? "stormy" : "rainy";
                        }
                        if (_currentWeather == "stormy")
                        {
                            helper.say(write: "It's getting stormy outside. You have 10 seconds to get into a shelter inside the village or you will be swept back whence you came from.");
                            _10toSweep = true;
                            Thread.Sleep(10000);
                            sweep();
                        }

                        if (Program._game.currentCountry.currentRoom.ShortDescription == "Hill")
                        {

                            Thread.Sleep(10 * 1000);
                        }
                        else
                        {

                            Thread.Sleep(30 * 1000);
                        }

                        _currentWeather = options[_random.Next(options.Length - 2)];


                    }
                }
            }
    );
            thread.Start();

        }
        public static void StopWeather()
        {
            _weatherRunning = false;
        }
        public static void GetWeather()
        {
            helper.say(write: "Right now it's " + _currentWeather);
        }
        private static bool isHidden()
        {
            if (Program._game.currentCountry.currentRoom.ShortDescription == "Shelter")
            {
                return true;
            }
            return false;
        }
        private static void WeatherStationFixed()
        {
            _stationFixed = true;
        }
        public static void tutorialNext(int id)
        {
            List<string> weather = new List<string> { "The wind is picking up.", "The weather is getting worse.", "It is starting to rain." };
            helper.say(write: weather[id]);


        }
        public static void stationGame()
        {
            if (Program._game.currentCountry.currentRoom.ShortDescription == "Hill")
            {

                helper.say(write: "Weather station needs to be configured.");
                helper.say(write: "Since you are not an expert, you can only configure based on the current weather. Write the command configure [weather] with sunny/rainy/stormy depending on what you can see from the hill. Use command weather to get updated on what you see.");

            }

        }
        public static void configure(string weather)
        {
            if (Program._game.currentCountry.currentRoom.ShortDescription == "Hill")
            {
                if (_currentWeather == weather)
                {
                    if (_toConfigure.Contains(weather))
                    {

                        _toConfigure.Remove(weather);
                        if (_toConfigure.Count == 0)
                        {
                            WeatherStationFixed();
                            helper.say(write: "Weather station is fixed");
                        }
                        else
                        {
                            helper.say(write: "Weather station needs to be configured for " + _toConfigure.Count + " more weathers.");
                        }
                    }
                    else
                    {
                        helper.say(write: "You have already configured this weather.");
                    }
                }
                else
                {
                    helper.say(write: "You can only configure the current weather.");
                }
            }
            else
            {
                helper.say(write: "You can only configure the weather station on the Hill.");
            }
        }
        private static void sweep()

        {

            if (!isHidden())
            {
                if (_stationFixed)
                {
                    Console.Clear();
                    helper.say(write: "You have been swept, press enter to stand up.");
                    Program._game.Travel("india");
                    StopWeather();
                    _swept = true;

                    //press enter
                    //dock.stop

                }
                else
                {
                    if (_random.Next(3) == 0)
                    {
                        Console.Clear();
                        helper.say(write: "You have been swept, press enter to stand up");
                        Program._game.Travel("india");
                        StopWeather();
                        _swept = true;
                    }
                    else
                    {
                        helper.say(write: "fake alarm not swept");
                    }

                }

                //sweep2

            }
            else
            {
                helper.say(write: "You made it to the shelter right on time, wait until the storm passes.");
                Thread.Sleep(3000);
                helper.say(write: "The storm is over, you can go back outside.");

            }
        }



    }
}