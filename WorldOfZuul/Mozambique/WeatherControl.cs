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
        public static bool _swept = false;
        public static bool _10toSweep = false;
        public static bool _tutorial = true;
        public static List<string> _toConfigure = new List<string> { "sunny", "rainy", "stormy" };
        private static Random _random = new Random();

        public static void StartWeather()
        {
            _weatherRunning = true;
            string[] options = _stationFixed ? new string[] { "sunny", "sunny", "sunny", "cloudy", "rainy", "stormy" } : new string[] { "sunny", "windy", "cloudy", "rainy", "rainy", "rainy", "stormy" };
            Thread thread = new Thread(() =>
            {
                while (_weatherRunning)

                {
                    if (_currentWeather == "windy")
                    {
                        helper.say(write: "The wind is picking up. In these parts that might mean a storm is coming.");
                    }
                    if (_currentWeather == "cloudy")
                    {
                        helper.say(write: "It's getting cloudy outside. Do you know where to hide if you need too?");
                    }
                    if (_currentWeather == "rainy")
                    {
                        helper.say(write: "It's getting rainy outside. You should hide in case a storm is comming.");
                        Thread.Sleep(10000);
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
            });
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
            Room field = Program._game.currentCountry.Rooms.Where(r => r.ShortDescription == "Hill").First();
            field.mminigameCompleted = true;
            StartWeather();
        }
        public static void tutorialNext(int id)
        {
            Thread.Sleep(400);
            List<string> weather = new List<string> { "The wind is picking up.", "The weather is getting worse.", "It is starting to rain." };
            helper.say(write: weather[id]);


        }
        public static void stationGame()
        {
            if (Program._game.currentCountry.currentRoom.ShortDescription == "Hill")
            {

                helper.say(write: "Weather station needs to be configured");
                helper.say(write: "Since you are not an expert, you can only configure based on the current weather. Write the command configure [weather] with sunny/rainy/stormy depending on what you can see from the hill. Use the command weather to get updated on what you see.");

            }
            else
            {
                helper.say(write: "You can only configure the weather station on the Hill.");
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
                            helper.say(write: "Weather station is fixed.");
                        }
                        else
                        {
                            helper.say(write: "Nice! The weather station needs to be configured for " + _toConfigure.Count + " more weathers.");
                        }
                    }
                    else
                    {
                        helper.say(write: "This weather is already configured.");
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
        public static void sweep()

        {

            if (!isHidden())
            {
                if (_stationFixed)
                {

                    Console.Clear();
                    helper.say(write: "You have been swept.");
                    Thread.Sleep(1000);
                    Program._game.Travel("denmark");
                    StopWeather();
                    _swept = true;
                    _10toSweep = false;
                    FieldControl.verifyField();

                    //press enter
                    //dock.stop

                }
                else
                {
                    if (_random.Next(1) == 0)
                    {
                        Console.Clear();

                        helper.say(write: "You have been swept.");
                        Thread.Sleep(1000);
                        Program._game.Travel("denmark");
                        StopWeather();
                        _swept = true;
                        _10toSweep = false;
                        FieldControl.verifyField();
                    }
                    else
                    {
                        helper.say(write: "Nothing happened, probably false alarm.");
                    }
                }
            }
            else
            {
                helper.say(write: "You are safe inside the shelter.");
                Thread.Sleep(3000);
                FieldControl.verifyField();

            }
        }



    }
}