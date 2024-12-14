using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FiveCountries
{
    public static class FieldControl
    {
        public static List<List<String>> fieldMap = [

            new List<string>  {"#","#","#","#","#","~","~","~",},
            new List<string>  {"#","#","|","|","#","|","|","~",},
            new List<string>  {"#","|","|","|","|","|","|","~",},
            new List<string>  {"#","|","|","|","|","|","~","~",},
            new List<string>  {"#","#","|","|","|","|","~","~",},
            new List<string>  {"#","|","|","|","|","|","|","~",},
            new List<string>  {"#","|","|","|","|","|","|","~",},
            new List<string>  {"|","|","|","#","#","#","#","~",},
        ];

        // id to create wall -> "15","16","25","26","35","45","55","56","66"
        public static int seedCount = 0;


        public static void printMap()
        {
            foreach (var row in fieldMap)
            {
                Console.WriteLine(string.Join("  ", row));
            }
        }
        public static void plantMangroves(string cords)
        {
            try
            {
                int x = Int32.Parse(cords[0].ToString());
                int y = Int32.Parse(cords[1].ToString());
                if (Program._game.currentCountry.currentRoom.ShortDescription == "Field")
                {
                    if (seedCount == 0)
                    {
                        helper.say(write: "You don't have any seeds."); return;
                    }


                    if (x < 8 && x > 0 && y < 8 && y > 0)
                    {
                        fieldMap[x][y] = "#";
                        seedCount--;
                        foreach (var row in fieldMap)
                        {
                            Console.WriteLine(string.Join("  ", row));
                        }
                    }

                    else
                    {
                        helper.say(write: "Invalid coordinates. Try again.");
                    }
                }
                else
                {
                    helper.say(write: "You can only plant mangroves in the field.");
                }
            }
            catch
            {
                helper.say(write: "Invalid coordinates. Try again.");
            }



        }

        public static void removeMangroves(string cords)
        {
            int x = Int32.Parse(cords[0].ToString());
            int y = Int32.Parse(cords[1].ToString());

            if (Program._game.currentCountry.currentRoom.ShortDescription == "Field")
            {


                if (x < 8 && x > 0 && y < 8 && y > 0)
                {
                    if (fieldMap[x][y] == "#")
                    {
                        fieldMap[x][y] = "|";
                        seedCount++;
                    }
                    else
                    {
                        helper.say(write: "There are no mangroves here!");
                    }
                    foreach (var row in fieldMap)
                    {
                        Console.WriteLine(string.Join("  ", row));
                    }
                }

                else
                {
                    helper.say(write: "Invalid coordinates. Try again.");
                }
            }
            else
            {
                helper.say(write: "You can only plant mangroves in the field.");
            }
        }

        public static Boolean verifyField()
        {
            List<string> mangroveWall = new List<string>
            {
                "15",
                "16",
                "25",
                "26",
                "35",
                "45",
                "55",
                "56",
                "66"
            };
            Boolean status = true;
            mangroveWall.ForEach(cords =>
            {

                int x = Int32.Parse(cords[0].ToString());
                int y = Int32.Parse(cords[1].ToString());

                if (fieldMap[x][y] != "#")
                {
                    status = false;
                }
            });
            return status;

        }

    }
}