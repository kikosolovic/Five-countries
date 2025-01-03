using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using WorldOfZuul;
using FiveCountries;
using System.Collections.ObjectModel;
using System.Threading.Tasks.Sources;


// all minigames/quests should be created here, and referenced in Init.cs
namespace FiveCountries
{

    class MinigameCode
    {
        public void Dock()
        {

            helper.printForStory("Dialogues/Mozambique/Dock.json");
            Thread.Sleep(500);
            helper.printForStory("Dialogues/Mozambique/CarRide.json");
            Program._game.Move("north");
            Program._game.currentCountry.currentRoom.ExecuteMinigame();

        }
        public void Village()
        {
            StorylineManager st = new StorylineManager("Dialogues/Mozambique/Village.json");
            var count = -1; //configure so it fits with the dialogue

            while (!WeatherControl._10toSweep)
            {
                if (st.repetition == 0)
                {
                    helper.say(st.text, st.response, st.options); if (st.options == null || st.options == "") { break; }
                }
                else { helper.say(options: st.options); }

                var choice = helper.parseinput(Console.ReadLine());
                if (!WeatherControl._10toSweep)
                {
                    switch (choice)
                    {
                        case "stoptalking": return;
                        default:
                            st.NextLevel(choice);
                            count += 1;
                            if (count < 3) { WeatherControl.tutorialNext(count); }
                            break;
                    }
                }
            }
            helper.say(write: "All of a sudden you see a big wave heading straight towards the village. You estimate that it will take you in about 3 seconds.");
            Thread.Sleep(4000);
            helper.say(write: "3");
            Thread.Sleep(1000);
            helper.say(write: "2");
            Thread.Sleep(1000);
            helper.say(write: "1");
            Thread.Sleep(2000);


            helper.say(write: "\nYou are lucky, somebody pulled you into the shelter right before the storm hit.");
            Thread.Sleep(1000);
            Program._game.ExplicitMove("Shelter");
            WeatherControl.StartWeather();

        }
        public void Shelter()
        {
            helper.say(location: "Mozambique Shelter");
            helper.printForStory("Dialogues/Mozambique/Shelter.json");

        }
        public void Hill()
        {
            FieldControl.seedCount = 8;
            helper.printForStory("Dialogues/Mozambique/Hill.json");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("+8 manngrove seeds");
            Console.ResetColor();

        }
        public void Field()
        {
            helper.printForStory("Dialogues/Mozambique/Field.json");
        }

        public void UNOutpost()
        {
            StorylineManager st = new StorylineManager("Dialogues/IndiaIntro.json");
            while (true)
            {
                if (st.repetition == 0)
                {
                    helper.say(st.text, st.response, st.options); if (st.options == null || st.options == "") { return; }
                }
                else { helper.say(options: st.options); }

                var choice = helper.parseinput(Console.ReadLine());

                {
                    switch (choice)
                    {
                        case "stoptalking": return;
                        default:
                            st.NextLevel(choice);
                            break;

                    }
                }
            }
        }


        public void photovoltaicMinigame()
        {
            Console.WriteLine(@"
Welcome to the first minigame in Haiti's Lab!
OBJECTIVE: Choose the best locations for photovoltaic power plants in Haiti.
Your task is to find the best spots for Photovoltaic(PV) power plants. You will be shown a map of Haiti and you will have to choose the best locations for 3 new Photovoltaic power plants.
");

            string haitiMapPV = @"
================================================= MAP OF HAITI =================================================

                                                    ██████                                          
                                                   ██▓▓███████           ~SEA~                           
                                              Port-de-Paix ███                                      
                                            ███▓▓██▓▓▓███*▒▒▒█▒                             _______
                                       ██████████████████▒▒▒▒▒▒█▒▒                        _/       \___
                                      ██████▒▒▒▒▒▒█▒▒▒██████▒▒▒▒▒▒▒███   ██ Cap-Haitien  |
                                     ███▒█████████████▒████████▒▒▒▒▒██████▓*▓████▓▓██    |               
                                     ███████▓▓▓▓▓▓▓▓████████████▒▒▒▒▒▒▒████████▓▓▓▓█▒████|           
                                       ███▓██▓██▓▓▓▓▓▓▓█████████▒▒▒▒▒▒▒▒▒▒▒██████████████|           
                                                    █▓▓▓▓████▓████▒▒▒▒▒▒▒▒▒▒██▒▒▒▒██████*| Ouanaminthe    
                                               Gonaives █*██▓▓▓████████▒▒▒▒▒████▒▒▒▒▒▒▒▒██|          
                                                         ███▓▓▓███▒██████▓██████▒▒▒▒▒▒▒█▒█|          
                ~SEA~                                    ▓█▓█▓▓█████████▓▓▓▓▓█████████████|          
                                                         ███▓▓▓▓▓▓▓▓████▓▓▓▓▓▓██████████|           
                                                         ▓▓▓▓▓▓▓▓▓▓███████▓▓▓▓▓████████████|         
                                                        ▓▓▓▓▓▓▓▓▓▓▓███████████*█▓▓▓██▓▓▓████| <- Hinche
                                                          ▓▓▓▓▓▓▓▓▓████▒▒███████▓▓▓▓▓▓▓▓▓███|        
                                                        █████████▓▓▓███▒▒█████▓▓▓▓▓▓▓▓▓▓▓█|          
                                                        █▓▓█▒▒█████▓▓███████▓▓▓▓▓▓▓▓▓▓██|            
                                          █▓█▓▓           █▓███▒▒███▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓█▓▓█|            
                                          ▓▓██▓▓▓▓▓▓         ████████████▓▓▓▓▓▓███▓▓▓▓▓██|           
                                           █▓▓▓▓██▓▓▓▓▓█      █▓▓▓██████▓▓▓▓▓▓▓▓█████████|           
                                                ██▓▓▓▓▓▓▓       ▓▓▓█████▓▓▓▓▓▓▓████████▒▒|           
                                                  ██▓▓▓█ Arcahaie *▓▓▓▓▓▓▓▓▓▓███████▒▒▒▒█|           
          ▒▒▒▒██▒* Jeremie                                            █▓▓▓▓▓▓▓▓█▓█▓████|             
         ▒▒▒▒▒▒▒▒████████  ████  █                  Port-au-prince v █▓▓▓▓▓▓▓▓█▒██|                  
        ▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒█▒██████▒             Carrefour -> ▓▓▓*▒▒▒*███▓▓▓▓▓▓███▒██|                
       ▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒███▒▒▒██*Miragoane   ████▒▒▒▒▒▒▒▒██▓█████████|                
       ▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒███▒▒▒▒▒▒▒▒██████████▓▓█████▒▒▒▒▒▒▒▒▒████▒▒▒▒▒▒▒▒▒|              
        ▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒█▒▒▒▒▒▒▒▒▒▒████▒██▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒█|          
         ▒████▒▒▒▒▒▒▒▒▒▒▒▒▒▒█████▒▒▒▒▒▒▒██▒█▒▒▒█████▒▒▒▒▒▒▒▒██████▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒|          
                 ██▒▒▒▒▒▒█████▓███████████▓▓▓███████████████████▓██*████████████████▒▒▒▒▒|           
                    ▒████████* Les Cayes      ███▓█▓▓▓▓█▓▓▓▓███▓█   Jacmel       ███████|            
                      █████                                                         █▓███|           
                       █████  ██▓▓▓                                                  █▓▓█|           
                                                                                         |           
                                                ~SEA~                                     \
                                                                                           |         
                                                                                            \ 
================================================================================================================
            Legend:                                          
            ▒▒▒▒▒▒▒▒▒▒▓▓▓▓▓▓▓▓▓▓██████████                      * - city             
               1200      1500      1800   kWh/kWp/year          | - border with Dominican Republic

            ";
            Console.WriteLine(haitiMapPV);
            Console.WriteLine(@"
            On the map you can see the predicted solar yield in kWh/kWp/year for different regions in Haiti.
            The higher the number, the more solar energy can be produced in that region.
            A bit more knowledge about units here:
                kWh is a unit of how much energy is produced.
                kWp is a unit of how much power is theoreticaly produced by the solar panels.

            So if we have a PV instalation of 1kWp in a region with 1800kWh/kWp/year, it will produce 1800kWh of energy in a year.
            
            Solar energy is a great source of renewable and clean energy, since during the operation it doesn't produce any emmisions or pollution.
            The downside to solar energy is that it is not always available, since it depends on the weather and the time of day.
            ");
            Console.WriteLine(@"
            Places to choose from:
            1. Port-de-Paix
            2. Cap-Haitien
            3. Ouanaminthe
            4. Hinche
            5. Arcahaie
            6. Carrefour
            7. Miragoane
            8. Les Cayes
            9. Jacmel
            10. Port-au-prince
            11. Gonaives
            12. Jeremie
            ");

            Console.WriteLine("Choose the best locations for the photovoltaic power plants (type 3 numbers spaced by space '') :");
            string[] answers = Console.ReadLine().Split(' ');
            while (answers.Length != 3)
            {
                answers = Console.ReadLine().Split(' ');
            }
            int[] optimalAnswers = { 8, 9, 3, 11, 2, 4 };
            int score = 0;
            for (int i = 0; i < answers.Length; i++)
            {
                if (optimalAnswers.Contains(Int32.Parse(answers[i])))
                {
                    score += 1;
                }
            }
            if (score == 3)
            {
                Console.WriteLine("Congrats! You have chosen the best cities available for our new investments!");
                Program._game.currentCountry.currentRoom.minigameCompleted = true;
            }
            else if (score == 2)
            {
                Console.WriteLine("Good job! You have chosen some of the best cities available for our new investments!");
                Program._game.currentCountry.currentRoom.minigameCompleted = true;
            }
            else if (score == 1)
            {
                Console.WriteLine("Good! You have chosen one of the best cities available for our new investments!");
                Program._game.currentCountry.currentRoom.minigameCompleted = true;
            }
            else
            {
                Console.WriteLine("You have not chosen any of the best cities available for our new investments!");
            }
        }
        public void windpowerMinigame()
        {
            string haitiWindMAp = @"
================================================= MAP OF HAITI =================================================
                    ▓▒▒▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓
                  ▓▒▒▒▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▒▒▒▒▒▒▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓
          ▓▓▓▓▓  ▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓      ▓▓▒▒▒▒▒▒▒▒▒▒▒▒▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓
▒░▒▒▒▓▓▓▓▒▒▒▒▒▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓    ▒▒▒▒▒▒▒▒▒▒▒▒▒▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓
▒▒▒▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓       ▓▓▒░░░░░░░░░░░▒▒▒▒▒▒▒▒▒▓▓▓▓▓▓▓▓▓▓▓▓▓▓
▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓           *      ░░▒░░░░░░░░░░▒▒▒▒▒▒▓▓▓▓▓▓▓▓▓▓▓▓▓_______
▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓           Port-de-Paix        ▒░░░░░░░░▒▒▒▒▒▒▓▓▓▓▓▓▓▓ /       \___
▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▒▓                                 ▓▒▒▒▓▓▒▒▒▒▒▒▒▒▒▒▒▒▓  _|   
▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▒▒▒▒▒                                       *      ▓▓▓▓▒▒▒▓|   
▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▒▒▒▒▒▒▒▒▒▒▒▒░░░▓                                 Cap-Haitien         |   
▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒░░░░░░░▒▓▓▓▓▓▒▒▓▓▓▓                                         |   
▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒░░░░░░░░░░░░░░░░░░░░░░░▒▓▓                                     |    
▓▓▓▓▓▓▓▓▓▓▓▓▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒░░░░░░░░░░░░░░░░░░░░░░░▒▒▒▒▒▒░░░░                                   |    
▓▓▓▓▓▓▓▓▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒░░░░░░░░░░░░░░░░░░░░░░░░▒▒▒▒▒▒▒▒▒▓▓▓▓▓▓* Gonaives                       |   
▓▓▓▓▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒░░░░░░░░░░░░░░░░░░░░░░░░░▒▒▒▒▒▒▒▒▒▓▓▓▓▓▓▓▓▓                                |   
▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░▓▓▓▓▓▓▓▓▓▓▒▒░▓                                _|   
▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░▓▓▓▓▓▓▓▓░░░▒                               |__   
▒▒▒▒▒▒▒▒▒▒▒▒▒░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░▒                                   |_ 
▒▒▒▒▒▒▒▒░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░▓                                   | 
▒▒▒░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░▒▓                                 | 
░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░▒                                   _|  
░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░▒▒▓                                |    
░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░▒▒░▒▒▓   ▓▒▒░░░░░▒▒▒▒▓                                |_   
░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░▒▒▒▒▒▓        ▓▒▒▒▒▒▒▒▒▒▓▓                             |   
░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░▒▒▒▒▒▒▒▒▒▒▓          ▓▓▒▒▒▒▒▒▓                            |   
░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░▒▒▒▒▓        ▓▒░░░▒▒▒▓                          |   
░░░░░░░░░░░░░░░░░░░░░░░░░▒▒▒▒░░░░░░░░░░░░░░░░░░░░░░░▒▒▒▒▓▓▓▓  ▓▒░▒▒▒▓▓▓▓▓▓* Arcahaie            _|   
░░░░░░░░░░░░░░░░░░░░░░░░░░▒▒▒▒▒▒▒░░░░░░░░░░░░░░░░░░░░▒▒▒▒▒▒▒▒▒▒▒▒▒▒▓▓▓▓▓▓▓▓▓▓              ____|     
░░░░░░░░░░░░░         *░░░░░▒▒▓   ▓▒▒▒░░░░░░░░░░░░░░░▒▒▒▒▒▒▒▒▒▒▒▓▓▓▓▓▓▓▓▓▓▓▓▓             |___       
░░░░░░░░░░░░    Jeremie               ▓▒▒▒░░░░░░░░░░▒▒▒▒▒▒▒▒▒▒▒▒░▒▒▒▓▓▓▓▓▓▓▓▓               _|       
░░░░░░░░░░░                                  ▒▒▒▒    *▒▒▒▒▒▒▒▒▒▒▒▒▒   *     *               |_       
░░░░░░▒▒▒▒                                   Miragoane      ▓  Carrefour    Port-au-prince    |____  
░░░░░░░░░░░                                                                                       |  
░░░░░░░░░░░░                                                                                     _|  
░░░░░░░░░░░░░░░░░░░░                                               Jacmel                       _|   
▒▒▒░░░░░░░░░░░░░░░░▒▒▓     Les Cayes    ░░   ░░                      *     ░        ░Belle Anse |_   
▒▒▒░░░░░░░░░░░░░░░░░░░░░▒      *░░░▒▒▒▒▒▒▒▒▒░░░░░░░▒▒▒░░░░       ░░░░░░░░░░░░░░░░░░░░░░░░░░*     |   
▒▒▒░░░░░░░░░░░░░░░░░░░░░░░▓   ░░░░░▒▒▒▒▒▒░░░░░░░░░░░░░▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒░░░░░░░░░░░░░░░░░░░░    |   
▒▒░░░░░░░░░░░░░░░░░░░░░░░░░▒    ▒░▒░░░▒▒░░░░░░░░░░░░░░░░░▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒░░░░░░░   |   
▒▒░░░░░░░░░░░░░░░░░░░░░░░░░░▒▒▒▒░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▓ \  
▒▒▒░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░▒ | 
▒▒▒░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▓ \
▒▒▒▒▒▒░░░░░░░░░░░░░░▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒░░░▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓ |
================================================================================================================
            Legend:                                          
            ▒▒▒▒▒▒▒▒▒▒▓▓▓▓▓▓▓▓▓▓██████████                      * - city             
            0         3         7        10    m/s              | - border with Dominican Republic
                                                                ' ' - land
            
            ";
            Console.WriteLine(@"
Welcome to another minigame in Haiti's Lab!
OBJECTIVE: Choose the best location for a wind power plant on Haiti's shore.
Your task is to find the best spots for wind power plants. You will be shown a map of Haiti's waters and averege wind speed.
");
            Console.WriteLine(haitiWindMAp);
            Console.WriteLine(@"
            This time, we will be working with wind power plants.
            The map shows the average wind speed in m/s for different regions in Haiti.
            The advantage of wind power is that it is more predictable than solar power, especially in regions placed near seas and oceans,
            where wind is usually much more stable and comes from the same direction.
            Another good thing about wind power is that it can be produced during the night, when solar power is not available.
            Wind power is also very clean, since the pollution is not produced during the production of electricity.

            In real life Haiti might not be the best place to build big wind power plants since it's a region that is often hit by hurricanes.
            However, we have omitted this fact for the purpose of the game.");

            Console.WriteLine(@"
            Choose at least 2 good locations for offshore wind power plants (type 2 numbers spaced by space ''):
            Regions to choose from:
            1.North of Port-de-Paix
            2.West of Port-de-Paix
            3.Jeremie
            4.Les Cayes
            5.Miragoane
            5.Gonaives
            6.Arcahaie
            7.Jacmel
            8.Cap-Haitien
            9.Carrefour
            10.Belle Anse
            11.Port-au-prince
            12.North-East of Cap-Haitien
            ");
            string[] answers = Console.ReadLine().Split(' ');
            while (answers.Length < 2)
            {
                answers = Console.ReadLine().Split(' ');
            }
            int[] optimalAnswers = { 1, 2, 5, 6, 9, 11, 12 };
            int score = 0;
            for (int i = 0; i < answers.Length; i++)
            {
                if (optimalAnswers.Contains(Int32.Parse(answers[i])) && score < 2)
                {
                    score += 1;
                }
            }
            if (score == 2)
            {
                Console.WriteLine("Congrats! You have chosen both of the best available places for our new investments!");
                Program._game.currentCountry.currentRoom.minigameCompleted = true;
            }
            else if (score == 1)
            {
                Console.WriteLine("Good job! You have chosen one of the best places available for our new investments!");
                Program._game.currentCountry.currentRoom.minigameCompleted = true;
            }
            else
            {
                Console.WriteLine("You have not chosen any of the best places available for our new investments!");
            }
        }

        public void EcoFriendlyHomeMakeover()
        {
            
            StorylineManager preGameDialogue = new StorylineManager("Dialogues/laDialogue.json");

            while (true)
            {
                helper.say(preGameDialogue.text, preGameDialogue.response, preGameDialogue.options);

                if (string.IsNullOrEmpty(preGameDialogue.options)) break;

                var choice = helper.parseinput(Console.ReadLine());

                try
                {
                    preGameDialogue.NextLevel(choice);
                }
                catch (Exception)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Invalid choice. Please select a valid option.");
                    Console.ResetColor();
                }
            }

            
            Console.ForegroundColor = ConsoleColor.Cyan;
            helper.WriteWithDelay("\nThe UN Ambassador leads you to a suburban neighborhood in Los Angeles.");
            helper.WriteWithDelay("\n'This city is working hard to make its homes more eco-friendly,' the ambassador explains.");
            helper.WriteWithDelay("\n'Your mission is to help by making sustainable choices in this eco-friendly home makeover challenge.'");
            Console.ResetColor();

            
            List<Question> questions = new List<Question>
    {
        new Question
        {
            Text = "You need a new refrigerator. Which option is the most eco-friendly choice?",
            Options = new Dictionary<char, string>
            {
                { 'A', "A standard refrigerator with a low upfront cost." },
                { 'B', "An ENERGY STAR-certified refrigerator." },
                { 'C', "A second-hand refrigerator from a friend." },
                { 'D', "The largest refrigerator available for more storage." }
            },
            CorrectOption = 'B',
            Explanation = "ENERGY STAR-certified appliances use less energy, saving you money and reducing environmental impact."
        },
        new Question
        {
            Text = "You're redesigning your garden. What should you plant to conserve water?",
            Options = new Dictionary<char, string>
            {
                { 'A', "A lawn with exotic flowers." },
                { 'B', "Native drought-resistant plants." },
                { 'C', "A tropical fruit garden." },
                { 'D', "Water-intensive grass turf." }
            },
            CorrectOption = 'B',
            Explanation = "Native drought-resistant plants require less water and are well-suited to LA's climate."
        },
        new Question
        {
            Text = "How can you best reduce household waste?",
            Options = new Dictionary<char, string>
            {
                { 'A', "Use disposable plates and utensils to avoid washing dishes." },
                { 'B', "Implement a composting system for organic waste." },
                { 'C', "Throw all waste into the general trash bin." },
                { 'D', "Burn waste in the backyard." }
            },
            CorrectOption = 'B',
            Explanation = "Composting reduces landfill waste and provides nutrient-rich soil for gardening."
        },
        new Question
        {
            Text = "Which lighting option is the most energy-efficient for your home?",
            Options = new Dictionary<char, string>
            {
                { 'A', "Incandescent bulbs." },
                { 'B', "Halogen bulbs." },
                { 'C', "Compact Fluorescent Lamps (CFLs)." },
                { 'D', "Light Emitting Diode (LED) bulbs." }
            },
            CorrectOption = 'D',
            Explanation = "LED bulbs are the most energy-efficient and have a longer lifespan than other bulbs."
        },
        new Question
        {
            Text = "To conserve water during showers, you should:",
            Options = new Dictionary<char, string>
            {
                { 'A', "Take longer showers to relax." },
                { 'B', "Install a low-flow showerhead." },
                { 'C', "Keep the water running while not in use." },
                { 'D', "Shower multiple times a day." }
            },
            CorrectOption = 'B',
            Explanation = "Low-flow showerheads reduce water usage without compromising the shower experience."
        }
    };

            int minigameScore = 0;
            int questionNumber = 1;

            foreach (var question in questions)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                helper.WriteWithDelay($"Question {questionNumber}: {question.Text}");
                Console.ResetColor();

                foreach (var option in question.Options)
                {
                    Console.Write($"{option.Key}. ");
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine(option.Value);
                    Console.ResetColor();
                }

                Console.Write("\nEnter your choice (A, B, C, or D): ");
                char playerChoice = GetValidOption();

                if (char.ToUpper(playerChoice) == question.CorrectOption)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Correct! " + question.Explanation);
                    
                    minigameScore++;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"Incorrect. Correct Answer: {question.CorrectOption}. {question.Options[question.CorrectOption]}");
                    Console.WriteLine(question.Explanation);
                }

                Console.ResetColor();
                Console.WriteLine("\nPress Enter to continue...");
                Console.ReadLine();
                questionNumber++;
            }

            // Final Minigame Results
            Console.ForegroundColor = ConsoleColor.Blue;
            helper.WriteWithDelay($"\nGame Over! You scored {minigameScore}/{questions.Count}.");
            if (minigameScore == questions.Count)
                helper.WriteWithDelay("Outstanding work! Your decisions showcase the best of sustainable practices.");
            else if (minigameScore >= questions.Count / 2)
                helper.WriteWithDelay("Good job! Your efforts show promise, but there's always room for improvement.");
            else
                helper.WriteWithDelay("There's a lot to learn about sustainability. Keep trying and you'll get there!");
            Console.ResetColor();
            Program._game.currentCountry.currentRoom.minigameCompleted = true;

            // Post-game Dialogue
            StorylineManager postGameDialogue = new StorylineManager("Dialogues/postGameLA.json");

            while (true)
            {
                helper.say(postGameDialogue.text, postGameDialogue.response, postGameDialogue.options);

                if (string.IsNullOrEmpty(postGameDialogue.options)) break;

                var choice = helper.parseinput(Console.ReadLine());

                try
                {
                    postGameDialogue.NextLevel(choice);
                }
                catch (Exception)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Invalid choice. Please select a valid option.");
                    Console.ResetColor();
                }
            }

            // Final Dialogue Finisher
            Console.ForegroundColor = ConsoleColor.Yellow;
            helper.WriteWithDelay("\nUN Ambassador: 'Your eco-friendly choices have inspired this city to push even further for sustainability.'");
            helper.WriteWithDelay("A local eco-enthusiast named Mia steps forward. 'Thanks to you, people are already adopting these practices in their homes.'");
            Console.ForegroundColor = ConsoleColor.Cyan;
            helper.WriteWithDelay("\nThe ambassador adds, 'Let's move on to our next destination. There's still work to be done.'");
            Console.ResetColor();
        }

        public static int printWord(List<char> guessedLetters, String randomWord)
        {
            int counter = 0;
            int rightLetters = 0;
            Console.Write("\r\n");
            foreach (char c in randomWord)
            {
                if (guessedLetters.Contains(c))
                {
                    Console.Write(c + " ");
                    rightLetters += 1;
                }
                else
                {
                    Console.Write("  ");
                }
                counter += 1;
            }
            //Console.Write("\r\n");
            return rightLetters;
        }

        private static void printLines(String randomWord)
        {
            Console.Write("\r");
            foreach (char c in randomWord)
            {
                Console.OutputEncoding = System.Text.Encoding.Unicode;
                Console.Write("\u0305 ");
            }
        }

        public void guessTree()
        {
            Random random = new Random();
            int treesNumber = random.Next(1, 501);
            int guess;
    

            Console.WriteLine("You need to guess how many trees were cut in order to know how many seeds will be needed to recover the area!");

            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write("Guess a number between 1 and 500: ");
            Console.ResetColor();

            do
            {
                


                var input = Console.ReadLine();
                if (string.IsNullOrEmpty(input) || int.TryParse(input, out guess) == false)
                {
                    Console.WriteLine("Invalid input.");
                    return;

                
                }

                else if (guess < treesNumber)
                {
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    Console.WriteLine("Too low");
                    Console.ResetColor();
                    Console.WriteLine("Try a number greater than " + guess);
                }
                else if (guess > treesNumber)
                {

                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine("Too high");
                    Console.ResetColor();
                    Console.WriteLine("Guess a number smaller than " + guess);
                }
            } while (guess != treesNumber);

            
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine("You guessed right! Now you have planted " + treesNumber + " seeds!");
            Console.ResetColor();
            Program._game.currentCountry.currentRoom.minigameCompleted = true;
        }

        public void beatMiners()
        {
            string input = Console.ReadLine();
            int score = 0;

            Random random = new Random();
            string[] choices = { "rock", "paper", "scissors" };
            Console.WriteLine("In order to end the illegal mining you need to beat them in a 'rock paper scissors' battle.");

            while (score < 1)
            {
                Console.ForegroundColor = ConsoleColor.DarkCyan;
                Console.Write("Enter your choice (rock, paper, scissors): ");
                Console.ResetColor();

                string playerChoice = Console.ReadLine().ToLower();

                if (playerChoice != "rock" && playerChoice != "paper" && playerChoice != "scissors")
                {
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine("Invalid choice. Please try again.");
                    Console.ResetColor();
                    continue;
                }

                int computerChoiceIndex = random.Next(3);
                string computerChoice = choices[computerChoiceIndex];

                Console.WriteLine($"Computer chose: {computerChoice}");

                if (playerChoice == computerChoice)
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("It's a tie!");
                    Console.ResetColor();
                }
                else if ((playerChoice == "rock" && computerChoice == "scissors") ||
                         (playerChoice == "paper" && computerChoice == "rock") ||
                         (playerChoice == "scissors" && computerChoice == "paper"))
                {

                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                    Console.WriteLine("You have defeated them, now you are one step closer to sustainability");
                    Program._game.currentCountry.currentRoom.minigameCompleted = true;
                    break;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine("They won! Try again with a different strategy.");
                    Console.ResetColor();
                }


            }

        }

        public void tribeHangman(int wrong)
        {
            Console.ForegroundColor = ConsoleColor.Gray;
            if (wrong == 0)
            {
                Console.WriteLine("\n+---+");
                Console.WriteLine("    |");
                Console.WriteLine("    |");
                Console.WriteLine("    |");
                Console.WriteLine("   ===");
            }
            else if (wrong == 1)
            {
                Console.WriteLine("\n+---+");
                Console.WriteLine("O   |");
                Console.WriteLine("    |");
                Console.WriteLine("    |");
                Console.WriteLine("   ===");
            }
            else if (wrong == 2)
            {
                Console.WriteLine("\n+---+");
                Console.WriteLine("O   |");
                Console.WriteLine("|   |");
                Console.WriteLine("    |");
                Console.WriteLine("   ===");
            }
            else if (wrong == 3)
            {
                Console.WriteLine("\n+---+");
                Console.WriteLine(" O  |");
                Console.WriteLine("/|  |");
                Console.WriteLine("    |");
                Console.WriteLine("   ===");
            }
            else if (wrong == 4)
            {
                Console.WriteLine("\n+---+");
                Console.WriteLine(" O  |");
                Console.WriteLine("/|\\ |");
                Console.WriteLine("    |");
                Console.WriteLine("   ===");
            }
            else if (wrong == 5)
            {
                Console.WriteLine("\n+---+");
                Console.WriteLine(" O  |");
                Console.WriteLine("/|\\ |");
                Console.WriteLine("/   |");
                Console.WriteLine("   ===");
            }
            else if (wrong == 6)
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("\n+---+");
                Console.WriteLine(" O   |");
                Console.WriteLine("/|\\  |");
                Console.WriteLine("/ \\  |");
                Console.WriteLine("    ===");
                Console.WriteLine("You lost, try again.");
                Console.ResetColor();
            }
            Console.ResetColor();

        }
        public void tribeHangmanMain()

        {

            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine("You need to guess the word chosen by the tribe leader to pass.");
            Console.ResetColor();
            
            
            String randomWord = "sustainability";

            string belowLines = "_ _ _ _ _ _ _ _ _ _ _ _ _ _";
            Console.Write(belowLines);
            
            int lengthOfWordToGuess = randomWord.Length;
            int amountOfTimesWrong = 0;
            List<char> currentLettersGuessed = new List<char>();
            int currentLettersRight = 0;

            while (amountOfTimesWrong != 6 && currentLettersRight != lengthOfWordToGuess)
            {
                Console.Write("\nLetters guessed so far: ");
                foreach (char letter in currentLettersGuessed)
                {
                    Console.Write(letter + " ");
                }

                Console.Write("\nGuess a letter: ");
                char letterGuessed = Console.ReadLine()[0];

                if (currentLettersGuessed.Contains(letterGuessed))
                {
                    Console.Write("\r\n You have already guessed this letter.");
                    tribeHangman(amountOfTimesWrong);
                    currentLettersRight = printWord(currentLettersGuessed, randomWord);
                    Console.Write(belowLines);
                }
                else
                {

                    bool right = false;
                    for (int i = 0; i < randomWord.Length; i++) { if (letterGuessed == randomWord[i]) { right = true; } }


                    if (right)

                    {
                        tribeHangman(amountOfTimesWrong);

                        currentLettersGuessed.Add(letterGuessed);
                        currentLettersRight = printWord(currentLettersGuessed, randomWord);
                        Console.Write("\r\n");
                        Console.Write(belowLines);
                    }

                    else
                    {
                        amountOfTimesWrong += 1;
                        currentLettersGuessed.Add(letterGuessed);

                        tribeHangman(amountOfTimesWrong);

                        currentLettersRight = printWord(currentLettersGuessed, randomWord);
                        Console.Write("\r\n");
                        printLines(randomWord);
                    }
                }
            }
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine("You have learned a little bit more about sustainability.");
            Console.ResetColor();

        }

        // Question Class for Minigames
        public class Question
        {
            public string Text { get; set; }
            public Dictionary<char, string> Options { get; set; }
            public char CorrectOption { get; set; }
            public string Explanation { get; set; }

        }
        // Method to get a valid option from the player
        private char GetValidOption()
        {
            while (true)
            {
                string? input = Console.ReadLine();
                if (!string.IsNullOrEmpty(input) && input.Length == 1)
                {
                    char option = char.ToUpper(input[0]);
                    if (option >= 'A' && option <= 'D')
                    {
                        return option;
                    }
                }
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("Invalid input. Please enter A, B, C, or D: ");
                Console.ResetColor();
            }
        }
        public void RecyclingSortingMinigameNYC()
        {
            int score = 0;
            StorylineManager preGameDialogue = new StorylineManager("Dialogues/nycDialogue.json");

            while (true)
            {
                helper.say(preGameDialogue.text, preGameDialogue.response, preGameDialogue.options);

                if (string.IsNullOrEmpty(preGameDialogue.options)) break;

                var choice = helper.parseinput(Console.ReadLine());

                try
                {
                    preGameDialogue.NextLevel(choice);
                }
                catch (Exception)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Invalid choice. Please select a valid option.");
                    Console.ResetColor();
                }
            }

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\nThe ambassador leads you to a large warehouse filled with bins labeled 'Recycle', 'Compost', and 'Trash'.");
            Console.WriteLine("He turns to you with a determined expression. 'This is where it all starts. Sorting these items correctly can make a huge impact.'");
            Console.WriteLine("'Your task is simple,' he continues. 'Identify each item and decide where it belongs—recycle, compost, or trash.'");
            Console.ResetColor();

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\nHow it works:");
            Console.WriteLine("- You’ll be presented with an item.");
            Console.WriteLine("- Type 'recycle', 'compost', or 'trash' to decide where it goes.");
            Console.WriteLine("- Let’s do this and show the team what proper sorting looks like!\n");
            Console.ResetColor();

            string[] items = {
        "plastic bottle", "banana peel", "glass jar", "pizza box with grease",
        "electronics", "paper", "food scraps", "plastic bag", "tin can",
        "aluminum foil", "egg shells", "styrofoam cup",
        "used tissue", "coffee grounds", "cereal box", "broken toy"
    };

            Random random = new Random();
            int timeLimit = 40;
            DateTime endTime = DateTime.Now.AddSeconds(timeLimit);

            while (DateTime.Now < endTime)
            {
                string item = items[random.Next(items.Length)];
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.Write($"Item: {item} - Where does it go? (recycle/compost/trash): ");
                Console.ResetColor();

                string response = Console.ReadLine()?.Trim().ToLower();

                if ((item == "plastic bottle" || item == "glass jar" || item == "tin can" ||
                     item == "aluminum foil" || item == "cereal box") && response == "recycle")
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Correct! This item belongs in recycling.");
                    score++;
                }
                else if ((item == "banana peel" || item == "food scraps" || item == "egg shells" ||
                          item == "coffee grounds") && response == "compost")
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Correct! This item should go to compost.");
                    score++;
                }
                else if ((item == "pizza box with grease" || item == "electronics" ||
                          item == "plastic bag" || item == "styrofoam cup" ||
                          item == "used tissue" || item == "broken toy") && response == "trash")
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Correct! This item belongs in the trash.");
                    score++;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Incorrect! Try to sort more carefully.");
                }

                Console.ResetColor();
            }

            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine($"\nTime's up! You sorted {score} items correctly.");
            Console.WriteLine("The ambassador smiles. 'You've done well. Every properly sorted item is one less going to waste.'");
            Console.WriteLine("The recycling team applauds your effort, inspired by your work.");
            Console.ResetColor();
            Program._game.currentCountry.currentRoom.minigameCompleted = true;

            StorylineManager postGameDialogue = new StorylineManager("Dialogues/postGameNYC.json");

            while (true)
            {
                helper.say(postGameDialogue.text, postGameDialogue.response, postGameDialogue.options);

                if (string.IsNullOrEmpty(postGameDialogue.options)) break;

                var choice = helper.parseinput(Console.ReadLine());

                try
                {
                    postGameDialogue.NextLevel(choice);
                }
                catch (Exception)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Invalid choice. Please select a valid option.");
                    Console.ResetColor();
                }

            }
            string finalText = "The UN Ambassador steps forward and gives you a friendly pat on the back.";
            helper.say(finalText, "UN Ambassador: 'Your hard work has made a real difference here today. But remember, there's still more work to do. We'll need you in the next city to help tackle even bigger challenges.'", null);

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\nYou prepare to move on to the next city, ready to take on new challenges.");
            Console.ResetColor();
        }
        public void CompostingPuzzleMinigameSFA()
        {
            // Pre-game Dialogue
            StorylineManager preGameDialogue = new StorylineManager("Dialogues/sfaDialogue.json");

            while (true)
            {
                helper.say(preGameDialogue.text, preGameDialogue.response, preGameDialogue.options);

                if (string.IsNullOrEmpty(preGameDialogue.options)) break;

                var choice = helper.parseinput(Console.ReadLine());

                try
                {
                    preGameDialogue.NextLevel(choice);
                }
                catch (Exception)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Invalid choice. Please select a valid option.");
                    Console.ResetColor();
                }
            }

            // Contextual Minigame Introduction
            Console.ForegroundColor = ConsoleColor.Cyan;
            helper.WriteWithDelay("\nThe UN Ambassador leads you to a bustling composting site in San Francisco, a city known for its dedication to sustainability.");
            helper.WriteWithDelay("\n'This city has set an example for others to follow in composting and waste management,' the ambassador explains.");
            helper.WriteWithDelay("\n'Your task is to sort compostable items into the correct bins. Each item must be categorized into Food Scraps, Garden Waste, or Paper Products.'");
            Console.ResetColor();

            // Define Items and Bin Mapping
            string[] items = {
        "apple core", "banana peel", "grass clippings", "dead leaves", "pizza box",
        "coffee grounds", "tree branches", "paper napkins", "rotten vegetables", "newspaper"
    };

            Dictionary<string, string> binMapping = new Dictionary<string, string>
    {
        { "apple core", "Food Scraps" },
        { "banana peel", "Food Scraps" },
        { "grass clippings", "Garden Waste" },
        { "dead leaves", "Garden Waste" },
        { "pizza box", "Paper Products" },
        { "coffee grounds", "Food Scraps" },
        { "tree branches", "Garden Waste" },
        { "paper napkins", "Paper Products" },
        { "rotten vegetables", "Food Scraps" },
        { "newspaper", "Paper Products" }
    };

            // Number of items to sort in this round
            int totalItems = 7;
            Random random = new Random();

            int minigameScore = 0;
            for (int i = 0; i < totalItems; i++)
            {
                // Pick a random item
                var item = items[random.Next(items.Length)];

                // Ask the player to sort the item
                Console.ForegroundColor = ConsoleColor.Yellow;
                helper.WriteWithDelay($"Item {i + 1}: {item}");
                Console.ResetColor();
                Console.Write("Which bin does this belong to? (Type: Food Scraps, Garden Waste, Paper Products): ");
                string response = Console.ReadLine()?.Trim();

                // Check the player's response
                if (binMapping.TryGetValue(item, out string correctBin))
                {
                    if (string.Equals(response, correctBin, StringComparison.OrdinalIgnoreCase))
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("Correct! You placed it in the right bin.");
                        minigameScore++;
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine($"Incorrect. The correct bin for {item} is {correctBin}.");
                    }

                    Console.WriteLine($"Explanation: {correctBin} is the proper category for {item} to ensure effective composting.");
                    Console.ResetColor();
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Invalid item. Skipping...");
                    Console.ResetColor();
                }

                Console.WriteLine(); // Add spacing between rounds
            }

            // Display the final score
            Console.ForegroundColor = ConsoleColor.Blue;
            helper.WriteWithDelay($"\nGame Over! You sorted {minigameScore.ToString()}/{totalItems} items correctly.");
            if (minigameScore == totalItems)
                helper.WriteWithDelay("Excellent! You're a composting champion!");
            else if (minigameScore >= totalItems / 2)
                helper.WriteWithDelay("Good job! A bit more practice, and you'll master composting.");
            else
                helper.WriteWithDelay("Keep practicing to improve your composting skills.");
            Console.ResetColor();
            Program._game.currentCountry.currentRoom.minigameCompleted = true;

            // Post-game Dialogue
            StorylineManager postGameDialogue = new StorylineManager("Dialogues/postGameSFA.json");

            while (true)
            {
                helper.say(postGameDialogue.text, postGameDialogue.response, postGameDialogue.options);

                if (string.IsNullOrEmpty(postGameDialogue.options)) break;

                var choice = helper.parseinput(Console.ReadLine());

                try
                {
                    postGameDialogue.NextLevel(choice);
                }
                catch (Exception)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Invalid choice. Please select a valid option.");
                    Console.ResetColor();
                }
            }

            
            Console.ForegroundColor = ConsoleColor.Yellow;
            helper.WriteWithDelay("\nUN Ambassador: 'You've done an amazing job here in San Francisco. Your dedication to sustainability is inspiring.'");
            helper.WriteWithDelay("A local community leader adds: 'Thanks to your efforts, more people understand the value of composting. We're ready to make an even bigger impact!'");
            Console.ForegroundColor = ConsoleColor.Cyan;
            helper.WriteWithDelay("\nThe ambassador smiles warmly: 'Well done! Now, let's move on to the next city and continue making a difference.'");
            Console.ResetColor();
        }
        public void ElectronicRepairChallenge()
        {
            StorylineManager preGameDialogue = new StorylineManager("Dialogues/chicagoDialogue.json");

            while (true)
            {
                helper.say(preGameDialogue.text, preGameDialogue.response, preGameDialogue.options);

                if (string.IsNullOrEmpty(preGameDialogue.options)) break;

                var choice = helper.parseinput(Console.ReadLine());

                try
                {
                    preGameDialogue.NextLevel(choice);
                }
                catch (Exception)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Invalid choice. Please select a valid option.");
                    Console.ResetColor();
                }
            }

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("Welcome to the Electronic Repair Challenge!");
            Console.ResetColor();

            Console.WriteLine("\nInstructions:");
            Console.WriteLine("1. You will repair parts of an electronic device.");
            Console.WriteLine("2. Each part requires a specific tool. Use the hints below to select the correct one:");
            Console.WriteLine("   - Screwdriver: For screws or assembling mechanical parts.");
            Console.WriteLine("   - Soldering Iron: For repairing electronic circuits.");
            Console.WriteLine("   - Multimeter: For diagnosing electrical issues.");
            Console.WriteLine("3. Complete the repairs to finish the challenge successfully!\n");

            string[] devices = { "Smartphone", "Laptop", "Old Television" };
            string[][] deviceParts = {
        new string[] { "Screen", "Battery", "Charging Port" },
        new string[] { "Keyboard", "Hard Drive", "Battery" },
        new string[] { "Screen", "Speakers", "Power Supply" }
    };

            string[] tools = { "Screwdriver", "Soldering Iron", "Multimeter" };

            Random rand = new Random();
            string currentDevice = devices[rand.Next(devices.Length)];
            string[] currentParts = deviceParts[Array.IndexOf(devices, currentDevice)];

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"You are tasked with repairing a {currentDevice}.");
            Console.ResetColor();
            Console.WriteLine($"You can repair the following parts:");

            foreach (var part in currentParts)
            {
                Console.WriteLine($"- {part}");
            }

            foreach (var partToRepair in currentParts)
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine($"\nYou need to repair: {partToRepair}");
                Console.ResetColor();

                if (partToRepair == "Screen")
                {
                    Console.WriteLine("Hint: Screens often need a diagnostic tool or a precise repair tool.");
                }
                else if (partToRepair == "Battery")
                {
                    Console.WriteLine("Hint: Batteries are delicate and might need precise connections repaired.");
                }
                else if (partToRepair == "Charging Port")
                {
                    Console.WriteLine("Hint: Ports often involve delicate soldering.");
                }
                else if (partToRepair == "Keyboard" || partToRepair == "Hard Drive")
                {
                    Console.WriteLine("Hint: These parts often involve screws or assembly adjustments.");
                }
                else if (partToRepair == "Speakers" || partToRepair == "Power Supply")
                {
                    Console.WriteLine("Hint: Electrical components often require diagnosing issues.");
                }

                Console.WriteLine("Select an action:");
                Console.WriteLine("1. Use Screwdriver\n2. Use Soldering Iron\n3. Use Multimeter");

                string action = Console.ReadLine();

                if ((action == "1" && (partToRepair == "Keyboard" || partToRepair == "Hard Drive")) ||
                    (action == "2" && (partToRepair == "Charging Port" || partToRepair == "Power Supply")) ||
                    (action == "3" && (partToRepair == "Screen" || partToRepair == "Speakers")))
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"Great! You successfully repaired the {partToRepair}.");
                    Console.ResetColor();
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"Incorrect tool choice. Try again next time!");
                    Console.ResetColor();
                }
            }

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Congratulations! You have completed the repairs.");
            Console.ResetColor();

            StorylineManager postGameDialogue = new StorylineManager("Dialogues/postGameChicago.json");

            while (true)
            {
                helper.say(postGameDialogue.text, postGameDialogue.response, postGameDialogue.options);

                if (string.IsNullOrEmpty(postGameDialogue.options)) break;

                var choice = helper.parseinput(Console.ReadLine());

                try
                {
                    postGameDialogue.NextLevel(choice);
                }
                catch (Exception)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Invalid choice. Please select a valid option.");
                    Console.ResetColor();
                }
            }
        }



        public void SewagePlantQuiz()
        {
            // Contextual Minigame Introduction
            Console.ForegroundColor = ConsoleColor.Cyan;
            helper.WriteWithDelay("\nYou go inside the tank room and inspect the damage.");
            helper.WriteWithDelay("\nThe pipes are clogged. There are pumps, valves and sensors that are in need of replacement.\nAt least the tanks themselves are intact. It would have been a lot worse had you needed to replace them too.");
            helper.WriteWithDelay("\nIt looks like you have your work cut out for you.");
            Console.ResetColor();

            // Questions for the Minigame
            List<Question> questions = new List<Question>
    {
        new Question
        {
            Text = "What is the primary purpose of a sewage treatment plant?",
            Options = new Dictionary<char, string>
            {
                { 'A', "To generate electricity." },
                { 'B', "To treat wastewater and remove contaminants." },
                { 'C', "To provide drinking water." },
                { 'D', "To manage stormwater." }
            },
            CorrectOption = 'B',
            Explanation = "The main goal of a sewage treatment plant is to eliminate pollutants from wastewater, resulting in clean, safe water for discharge or reuse."
        },
        new Question
        {
            Text = "Proper sewage treatment can help prevent what diseases?",
            Options = new Dictionary<char, string>
            {
                { 'A', "Airborne diseases." },
                { 'B', "Waterborne diseases." },
                { 'C', "Foodborne diseases." },
                { 'D', "All of the above." },

            },
            CorrectOption = 'B',
            Explanation = "Waterborne diseases are caused by the viruses and bacteria in dirty water. The more people consume the filtered water that has gone through sewage treatment, the more the percentage of them will get sick."
        },
        new Question
        {
            Text = "Which of the following is a key indicator for measuring progress towards SDG Goal 6?",
            Options = new Dictionary<char, string>
            {
                { 'A', "Percentage of population using clean water." },
                { 'B', "Number of new dams constructed." },
                { 'C', "Amount of water used per capita." },
                { 'D', "Total length of rivers in a country." }
            },
            CorrectOption = 'A',
            Explanation = "With the increase of locals using safe and clean water, we're getting closer to the completion of our goal in India."
        },
        new Question
        {
            Text = "Which of the following is a major challenge for water management in India?",
            Options = new Dictionary<char, string>
            {
                { 'A', "Over-extraction of groundwater." },
                { 'B', "Pollution of water bodies." },
                { 'C', "Inefficient water use in agriculture." },
                { 'D', "All of the above." }
            },
            CorrectOption = 'D',
            Explanation = "All three of the aforementioned are the reason why India has a severe lack of clean water."
        },
    };

            int minigameScoreSewage = 0;
            int questionNumber = 1;

            foreach (var question in questions)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                helper.WriteWithDelay($"Question {questionNumber}: {question.Text}");
                Console.ResetColor();

                foreach (var option in question.Options)
                {
                    Console.Write($"{option.Key}. ");
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine(option.Value);
                    Console.ResetColor();
                }

                Console.Write("\nEnter your choice: ");
                char playerChoice = GetValidOption();

                if (char.ToUpper(playerChoice) == question.CorrectOption)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Correct! " + question.Explanation);
                    minigameScoreSewage++;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"Incorrect. Correct Answer: {question.CorrectOption}. {question.Options[question.CorrectOption]}");
                    Console.WriteLine(question.Explanation);
                }

                Console.ResetColor();
                Console.WriteLine("\nPress Enter to continue...");
                Console.ReadLine();
                questionNumber++;
            }

            Console.ForegroundColor = ConsoleColor.Blue;
            helper.WriteWithDelay($"\nGame Over! You scored {minigameScoreSewage}/{questions.Count}.");
            if (minigameScoreSewage == questions.Count)
            {
                helper.WriteWithDelay("You found all the tools that you'd need. Then you fixed or replaced all of the valves," +
                " pipes and sensors. Afterwards you managed to unclog the pipes\nand finally did a systems check to see if everything is operational once more. And it is, thanks to you.");
                Program._game.currentCountry.currentRoom.minigameCompleted = true;
            }
            else if (minigameScoreSewage < questions.Count && minigameScoreSewage != 0)
            {
                helper.WriteWithDelay("You found all the tools that you'd need. You managed to unclog the pipes but just barely and you couldn't do\nanything with the valves, pipes and sensors." +
                "Perhaps it's better if you refresh your memory and then try again.");
                Program._game.currentCountry.currentRoom.minigameCompleted = false;
            }
            else if (minigameScoreSewage == 0)
            {
                helper.WriteWithDelay("There's a lot that you haven't learned yet. Come back again.");
                Program._game.currentCountry.currentRoom.minigameCompleted = false;
            }
            Console.ResetColor();

        }
        public void CropFieldQuiz()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            helper.WriteWithDelay("\nYou go to the field. You need to locate the groundwater source,\nconnect the pipes to it and install the irrigation system.\nTime to get to work.");
            Console.ResetColor();

            List<Question> questions = new List<Question>
            {
                new Question
                {
                    Text = "Which irrigation method involves delivering water directly to the roots of plants through a network of tubes or pipes?",
                    Options = new Dictionary<char, string>
                    {
                        { 'A', "Flood irrigation." },
                        { 'B', "Sprinkler irrigation." },
                        { 'C', "Drip irrigation." },
                        { 'D', "Surface irrigation." }
                    },
                    CorrectOption = 'C',
                    Explanation = "Drip irrigation delivers water directly to the roots."
                },
                new Question
                {
                    Text = "What is the main advantage of using drip irrigation over traditional flood irrigation?",
                    Options = new Dictionary<char, string>
                    {
                        { 'A', "It is cheaper to install" },
                        { 'B', "It uses less water and reduces evaporation." },
                        { 'C', "It requires less maintenance." },
                        { 'D', "It is suitable for all types of crops." }
                    },
                    CorrectOption = 'B',
                    Explanation = "Drip irrigation uses less water, thus optimizing its usage. This is especially useful in India."
                },
                new Question
                {
                    Text = "What percentage of India's population lacks access to safely managed drinking water services?",
                    Options = new Dictionary<char, string>
                    {
                        { 'A', "10%" },
                        { 'B', "40%" },
                        { 'C', "70%" },
                        { 'D', "90%" }
                    },
                    CorrectOption = 'B',
                    Explanation = "40 percent of the Indian population lacks access to clean water. That's a little bit over 570 million people."
                },
                new Question
                {
                    Text = "Approximately how many Indians get sick from waterborne diseases every year?",
                    Options = new Dictionary<char, string>
                    {
                        { 'A', "7.2 million" },
                        { 'B', "641 thousand" },
                        { 'C', "37.7 million" },
                        { 'D', "50.1 million" }
                    },
                    CorrectOption = 'C',
                    Explanation = "37.7 million get sick every year due to lack of clean water and sanitation."
                },
            };

            int minigameScoreField = 0;
            int questionNumber = 1;

            foreach (var question in questions)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                helper.WriteWithDelay($"Question {questionNumber}: {question.Text}");
                Console.ResetColor();

                foreach (var option in question.Options)
                {
                    Console.Write($"{option.Key}. ");
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine(option.Value);
                    Console.ResetColor();
                }

                Console.Write("\nEnter your choice: ");
                char playerChoice = GetValidOption();

                if (char.ToUpper(playerChoice) == question.CorrectOption)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Correct! " + question.Explanation);
                    minigameScoreField++;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"Incorrect. Correct Answer: {question.CorrectOption}. {question.Options[question.CorrectOption]}");
                    Console.WriteLine(question.Explanation);
                }

                Console.ResetColor();
                Console.WriteLine("\nPress Enter to continue...");
                Console.ReadLine();
                questionNumber++;
            }

            Console.ForegroundColor = ConsoleColor.Blue;
            helper.WriteWithDelay($"\nGame Over! You scored {minigameScoreField}/{questions.Count}.");
            if (minigameScoreField == questions.Count)
            {
                helper.WriteWithDelay("You successfully located the underground water source. You connected the tubes to the water and installed the system. " +
                "\nWhen you were done, you checked if the water is properly irrigating the soil. And it is, due to your valiant efforts.");
                Program._game.currentCountry.currentRoom.minigameCompleted = true;

            }
            else if (minigameScoreField < questions.Count && minigameScoreField != 0)
            {
                helper.WriteWithDelay("You successfully located the underground water source. You connected the tubes to the water and installed the system." +
                "\nWhen you were done, you checked if the water is properly irrigating the soil. But it's not, the water is not leaking out of the tubes. You better try again.");
                Program._game.currentCountry.currentRoom.minigameCompleted = false;
            }
            else if (minigameScoreField == 0)
            {
                helper.WriteWithDelay("There's a lot that you haven't learned yet. Come back again.");
                Program._game.currentCountry.currentRoom.minigameCompleted = false;
            }
            Console.ResetColor();

        }


    }

}