using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FiveCountries
{
    public class Init
    {
        MinigameCode minigamesCode = new();

        public List<Country> CreateCountries()
        {
            List<Country> Countries = new List<Country>();
            Country? Haiti = new("Haiti", "Wouldn't you know, Haiti is located in the Caribbean");
            Countries.Add(Haiti);

            Country? India = new("India", "Your objectives in India revolve around Goal 6 - Clean water and sanitation. \n \n");

            Country? Brazil = new("Brazil", "Your objectives in Brazil revolve around Goal 15 - Life on land. \n \n");
            Countries.Add(Brazil);

            Country? Mozambique = new("Mozambique", "Your objectives in Mozambique revolve around Goal 13 - Climate action. \n \n");
            Countries.Add(Mozambique);

            Country? USA = new("USA", "Your objectives in the US revolve around Goal 12 - Responsible consumption and production. \n \n");
            Countries.Add(USA);

            Haiti.SetExits(Haiti, India, Brazil, Mozambique, USA);
            India.SetExits(Haiti, India, Brazil, Mozambique, USA);
            Brazil.SetExits(Haiti, India, Brazil, Mozambique, USA);
            Mozambique.SetExits(Haiti, India, Brazil, Mozambique, USA);
            USA.SetExits(Haiti, India, Brazil, Mozambique, USA);

            return Countries;


        }
        public void CreateRooms(List<Country> countries)
        {
            MinigameCode minigameFunctions = new MinigameCode();
            Country Haiti = countries[0];
            Country India = countries[1];
            Country Brazil = countries[2];
            Country Mozambique = countries[3];
            Country USA = countries[4];

            // //initialize rooms to Haiti
            Haiti.InitRoom("Outside", "You are standing outside the main entrance of the university. To the east is a large building, to the south is a computing lab, and to the west is the campus pub.");
            Haiti.InitRoom("Theatre", "You find yourself inside a large lecture theatre. Rows of seats ascend up to the back, and there's a podium at the front. It's quite dark and quiet.");
            Haiti.InitRoom("Pub", "You've entered the campus pub. It's a cosy place, with a few students chatting over drinks. There's a bar near you and some pool tables at the far end.");
            Haiti.InitRoom("Lab", "You're in a computing lab. Desks with computers line the walls, and there's an office to the east. The hum of machines fills the room.");
            Haiti.InitRoom("Office", "You've entered what seems to be an administration office. There's a large desk with a computer on it, and some bookshelves lining one wall.");


            Haiti.addExit("Outside", new List<string> { "east", "south", "west" }, new List<string> { "Theatre", "Lab", "Pub" });
            Haiti.addExit("Theatre", new List<string> { "west" }, new List<string> { "Outside" });
            Haiti.addExit("Pub", new List<string> { "east" }, new List<string> { "Outside" });
            Haiti.addExit("Lab", new List<string> { "north", "east" }, new List<string> { "Outside", "Office" });
            Haiti.addExit("Office", new List<string> { "west" }, new List<string> { "Lab" });


            // //initialize rooms to India
            India.InitRoom("UN Outpost", "You are just outside of a UN outpost located between your two objectives. You can go either north or south.");
            India.InitRoom("Outside Sewage Treatment Plant", "You find yourself outside the abandoned plant mentioned in your report. The entrance to the lobby is to the north.");
            India.InitRoom("Lobby", "You're inside the lobby of the plant. There is a storage room to the east and the tank room is to the west.");
            India.InitRoom("Tank Room", "You're inside the tank room. You ascertain that the tanks are rusty and full of holes and that the pipes need replacing. You should maybe check the storage room to see if you can't find spare ones.");
            India.InitRoom("Crop Field", "You're at the crop field mentioned in the report. You will need drip tubes and emitters to be able to install the irrigation system. There's two sheds to the west and east. You should check what's inside them.");


            India.addExit("UN Outpost", new List<string> { "north", "south" }, new List<string> { "Outside Sewage Treatment Plant", "Crop Field" });
            India.addExit("Outside Sewage Treatment Plant", new List<string> { "south", "north" }, new List<string> { "UN Outpost", "Lobby" });
            India.addExit("Lobby", new List<string> { "south", "east" }, new List<string> { "Outside Sewage Treatment Plant", "Tank Room" });
            India.addExit("Tank Room", new List<string> { "west" }, new List<string> { "Lobby" });
            India.addExit("Storage Room", new List<string> { "east" }, new List<string> { "Lobby" });
            India.addExit("Crop Field", new List<string> { "north" }, new List<string> { "UN Outpost" });



            // //initialize rooms to Brazil
            Brazil.InitRoom("Outside", "You are standing outside the main entrance of the university. To the east is a large building, to the south is a computing lab, and to the west is the campus pub.");
            Brazil.InitRoom("Theatre", "You find yourself inside a large lecture theatre. Rows of seats ascend up to the back, and there's a podium at the front. It's quite dark and quiet.");
            Brazil.InitRoom("Pub", "You've entered the campus pub. It's a cosy place, with a few students chatting over drinks. There's a bar near you and some pool tables at the far end.");
            Brazil.InitRoom("Lab", "You're in a computing lab. Desks with computers line the walls, and there's an office to the east. The hum of machines fills the room.");
            Brazil.InitRoom("Office", "You've entered what seems to be an administration office. There's a large desk with a computer on it, and some bookshelves lining one wall.");


            Brazil.addExit("Outside", new List<string> { "east", "south", "west" }, new List<string> { "Theatre", "Lab", "Pub" });
            Brazil.addExit("Theatre", new List<string> { "west" }, new List<string> { "Outside" });
            Brazil.addExit("Pub", new List<string> { "east" }, new List<string> { "Outside" });
            Brazil.addExit("Lab", new List<string> { "north", "east" }, new List<string> { "Outside", "Office" });
            Brazil.addExit("Office", new List<string> { "west" }, new List<string> { "Lab" });


            //initialize rooms to Mozambique
            Mozambique.InitRoom("Dock", "You just arrived to Mozambique. The boat dropped you off at a small dock. ", new MinigameDelegate(minigameFunctions.Dock));
            Mozambique.InitRoom("Village", "You find yourself in a small village. People are walking around. ", new MinigameDelegate(minigameFunctions.Village));
            Mozambique.InitRoom("Hill", "You have a view of the whole village and the oocean behind it.");
            Mozambique.InitRoom("Field", "You are in a rice field. There are paths in between the individual rice plants. Locals are caring for  the rice, this harvest is going to be plentiful.");
            Mozambique.InitRoom("Boat", "You find yourself on a small fishing boat in the middle of the ocean. There is nowhere to hide.");

            Mozambique.addExit("Dock", new List<string> { "west" }, new List<string> { "Village" });
            Mozambique.addExit("Village", new List<string> { "north", "east" }, new List<string> { "Hill", "Dock" });
            Mozambique.addExit("Hill", new List<string> { "south" }, new List<string> { "village" });
            Mozambique.addExit("Field", new List<string> { "north", "east" }, new List<string> { "Outside", "Office" });
            Mozambique.addExit("Boat", new List<string> { "west" }, new List<string> { "Lab" });



            // //initialize rooms to USA
            USA.InitRoom("New York City", "You are in New York City, where waste management and recycling initiatives are critical to reducing urban waste.", new MinigameDelegate(minigameFunctions.RecyclingSortingMinigameNYC));
            USA.InitRoom("Los Angeles", "You are in Los Angeles, dealing with challenges related to plastic waste and sustainable disposal methods..", new MinigameDelegate(minigameFunctions.EcoFriendlyHomeMakeover));
            USA.InitRoom("San Francisco", "You are in San Francisco, known for its zero-waste goals and composting initiatives.");
            USA.InitRoom("Houston", "You are in Houston, where industrial waste and hazardous waste management are major concerns.");
            USA.InitRoom("Chicago", "You are in Chicago, focusing on electronic waste recycling and management.");


            USA.addExit("New York City", new List<string> { "east", "south", "west" }, new List<string> { "Los Angeles", "Houston", "San Francisco" });
            USA.addExit("Los Angeles", new List<string> { "west" }, new List<string> { "New York City" });
            USA.addExit("San Francisco", new List<string> { "east" }, new List<string> { "New York City" });
            USA.addExit("Houston", new List<string> { "north", "east" }, new List<string> { "New York City", "Chicago" });
            USA.addExit("Chicago", new List<string> { "west" }, new List<string> { "Houston" });

        }

        public List<Minigame> CreateGames()
        {
            List<Minigame> minigames = new List<Minigame>();
            Minigame[] Games = {
                // Country, Room, Description, unique ID, Function, maximum Score
                new("Haiti", "Lab", "This is 1 game", 11, minigamesCode.minigame11, 2),
                new("Haiti", "Lab", "This is 2 game", 12, minigamesCode.minigame12, 4),
                new("Haiti", "Lab", "This is 3 game", 13, minigamesCode.minigame13, 1),
                new("Haiti", "Lab", "This is 4 game", 14, minigamesCode.minigame14, 2),

            };
            foreach (Minigame minigame in Games)
            {
                minigames.Add(minigame);
            }

            return minigames;
        }
    }
}