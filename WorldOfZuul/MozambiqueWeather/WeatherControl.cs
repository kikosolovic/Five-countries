using System;
using System.Collections.Generic;
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

        private static bool _weatherRunning = false;
        private static bool _stationFixed = false;
        private static string _currentWeather = "sunny";
        private static bool _realstorm = false;
        public static bool _swept = false;
        public static bool _10toSweep = false;
        private static Random _random = new Random();

        public static void StartWeather()
        {
            // if (!_realstorm)
            // {
            //     //here implement the first encounter with fake huricane
            //     _realstorm = true;
            // }

            string[] options = _stationFixed ? new string[] { "sunny", "sunny", "sunny", "cloudy", "rainy", "stormy" } : new string[] { "sunny", "windy", "cloudy", "rainy", "rainy", "rainy", "stormy" };
            Thread thread = new Thread(() =>
            {
                Thread.Sleep(2000);
                while (_weatherRunning)
                {


                    if (_currentWeather == "windy")
                    {
                        helper.say(write: "The wind is picking up. In these parts that might mean a storm is comming");
                    }
                    if (_currentWeather == "cloudy")
                    {
                        helper.say(write: "It's getting cloudy outside. Do you know where to hide if you need too?");
                    }
                    if (_currentWeather == "rainy")
                    {
                        helper.say(write: "It's getting rainy outside. You should hide in case a  storm is comming");
                        Thread.Sleep(15000);
                        _currentWeather = _random.Next(2) == 0 ? "stormy" : "rainy";
                    }
                    if (_currentWeather == "stormy")
                    {
                        helper.say(write: "It's getting stormy outside. You have 10 seconds to get into a shelter inside the village or you will be swept back whence you came from");
                        _10toSweep = true;
                        Thread.Sleep(10000);
                        sweep();
                    }
                    Thread.Sleep(6 * 1000); // 60 seconds // make it  _random too fuck it // but also long enough so they can talk to fisherman 
                    _currentWeather = options[_random.Next(options.Length - 2)];


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
            //check if the player is hidde
            return false;
        }
        private static void WeatherStationFixed()
        {
            _stationFixed = true;
        }
        private static void sweep()
        {
            if (!isHidden())
            {
                if (_stationFixed)
                {
                    helper.say(write: "You have been swept, press enter to stand up");
                    Program._game.Travel("haiti");
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
                        Program._game.Travel("haiti");
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
                helper.say(write: "You made it to the shelter right on time, wait until the storm passes");
                Thread.Sleep(15000);
                helper.say(write: "The storm is over, you can go back outside.");

                if (!_stationFixed)
                {
                    helper.say(write: "Grandma says the alert was fake, because of the broken weather station");
                }
            }
        }



    }
}