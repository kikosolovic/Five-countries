using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
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
            Countries.Add(India);

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
            Haiti.InitRoom("Outside", "You're at the beautiful park in the middle of the complex.");
            Haiti.InitRoom("Lobby", "You're inside the main hall of the complex.");
            Haiti.InitRoom("Corridor", "This corridor leads to the other rooms.");
            Haiti.InitRoom("PV Lab", "It's pretty dark here. You are in the PV Lab. \n We often test solar panels here, so we need to keep it dark. \n You can see a lot of solar panels and inverters around you. \n This is the place where we design and plan future solar panels.");
            Haiti.InitRoom("Wind Lab", "It's windy here! You are in the Wind Lab. You can see a lot of wind turbines and anemometers around you.\nThere are also countless TVs with real-world and simulation data about wind power plants.\nThis is the place where we design and plan future wind turbines.");
            Haiti.InitRoom("Energy Storage Lab", "This is the Energy Storage Lab. You can see a lot of batteries and capacitors around you.\nThis is the place where we design and plan future enegry storeges.");
            Haiti.InitRoom("Closet", "It's silent here, and also nothing intresting, just some old brooms, mops and tons of dust.");
            Haiti.InitRoom("Infrastructure Building", "Building of the Infrastructure Department");
            //Haiti.InitRoom("Server Building", "Building of the Computational Department");


            Haiti.addExit("Outside", new List<string> { "south", "north"/*, "west"*/ }, new List<string> { "Lobby", "Infrostructure Building"/*, "Server Building" */});
            Haiti.addExit("Lobby", new List<string> { "south", "north", "west", "east" }, new List<string> { "Corridor", "Outside", "Wind Lab", "PV Lab" });
            Haiti.addExit("Corridor", new List<string> { "north", "west", "east" }, new List<string> { "Lobby", "Energy Storage Lab", "Closet", });
            Haiti.addExit("PV Lab", new List<string> { "west" }, new List<string> { "Lobby" });
            Haiti.addExit("Wind Lab", new List<string> { "east" }, new List<string> { "Lobby" });
            Haiti.addExit("Energy Storage Lab", new List<string> { "east" }, new List<string> { "Corridor" });
            Haiti.addExit("Closet", new List<string> { "west" }, new List<string> { "Corridor" });
            Haiti.addExit("Infrostructure Building", new List<string> { "south" }, new List<string> { "Outside" });
            //Haiti.addExit("Server Building", new List<string> { "east" }, new List<string> { "Outside" });



            // //initialize rooms to India
            India.InitRoom("UN Outpost", "You are just outside of a UN outpost located between your two objectives.", new MinigameDelegate(minigameFunctions.UNOutpost));
            India.InitRoom("Outside Sewage Treatment Plant", "You find yourself outside the abandoned plant. It looks dilapidated and dirty. The entrance to the lobby is to the north.");
            India.InitRoom("Lobby", "You're inside the lobby of the plant. There's trash on the ground everywhere. The tank room is to the east.");
            India.InitRoom("Storage Room", "There's nothing to see here that's of importance.");
            India.InitRoom("Tank Room", "You're inside the tank room.", new MinigameDelegate(minigameFunctions.SewagePlantQuiz));
            India.InitRoom("Crop Field", "You're in front of the crop field.", new MinigameDelegate(minigameFunctions.CropFieldQuiz));

            India.addExit("UN Outpost", new List<string> { "north", "south" }, new List<string> { "Outside Sewage Treatment Plant", "Crop Field" });
            India.addExit("Outside Sewage Treatment Plant", new List<string> { "south", "north" }, new List<string> { "UN Outpost", "Lobby" });
            India.addExit("Lobby", new List<string> { "south", "east", "west" }, new List<string> { "Outside Sewage Treatment Plant", "Tank Room", "Storage Room" });
            India.addExit("Storage Room", new List<string> { "east" }, new List<string> { "Lobby" });
            India.addExit("Tank Room", new List<string> { "west" }, new List<string> { "Lobby" });
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
            Mozambique.InitRoom("Field", "You are in a rice field. There are paths in between the individual rice plants. Locals are caring for  the rice, this harvest is going to be plentiful.", new MinigameDelegate(minigameFunctions.Field));
            Mozambique.InitRoom("Hill", "You have a view of the whole village and the oocean behind it.", new MinigameDelegate(minigameFunctions.Hill));
            Mozambique.InitRoom("Shelter", "You are inside a cycloon shelter. The harsh weather can't get to you, or so they say.", new MinigameDelegate(minigameFunctions.Shelter));

            Mozambique.addExit("Dock", new List<string> { "north", "south" }, new List<string> { "Village", "Boat" });
            Mozambique.addExit("Village", new List<string> { "north", "south", "east", "west" }, new List<string> { "Shelter", "Dock", "Hill", "Field" });
            Mozambique.addExit("Hill", new List<string> { "west" }, new List<string> { "Village" });
            Mozambique.addExit("Field", new List<string> { "east" }, new List<string> { "Village" });
            Mozambique.addExit("Shelter", new List<string> { "south" }, new List<string> { "Village" });



            // //initialize rooms to USA
            USA.InitRoom("New York City", "You are in New York City, where waste management and recycling initiatives are critical to reducing urban waste.", new MinigameDelegate(minigameFunctions.RecyclingSortingMinigameNYC));
            USA.InitRoom("Chicago", "You are in Chicago, focusing on electronic waste recycling and management.", new MinigameDelegate(minigameFunctions.ElectronicRepairChallenge));
            USA.InitRoom("Houston", "You are in Houston, where industrial waste and hazardous waste management are major concerns.");
            USA.InitRoom("Los Angeles", "You are in Los Angeles, dealing with challenges related to plastic waste and sustainable disposal methods.", new MinigameDelegate(minigameFunctions.EcoFriendlyHomeMakeover));
            USA.InitRoom("San Francisco", "You are in San Francisco, known for its zero-waste goals and composting initiatives.", new MinigameDelegate(minigameFunctions.CompostingPuzzleMinigameSFA));

            USA.addExit("New York City", new List<string> { "south" }, new List<string> { "Chicago" });
            USA.addExit("Chicago", new List<string> { "north", "south" }, new List<string> { "New York City", "Houston" });
            USA.addExit("Houston", new List<string> { "north", "south" }, new List<string> { "Chicago", "Los Angeles" });
            USA.addExit("Los Angeles", new List<string> { "north", "south" }, new List<string> { "Houston", "San Francisco" });
            USA.addExit("San Francisco", new List<string> { "north" }, new List<string> { "Los Angeles" });




        }

        public List<Minigame> CreateGames()
        {
            List<Minigame> minigames = new List<Minigame>();
            Minigame[] Games = {
                // Country, Room, Description, unique ID, Function, maximum Score
                new("Haiti", "PV Lab", "Planning PV's instalations", 11, minigamesCode.photovoltaicMinigame, 6),
                new("Haiti", "Wind Lab", "Planning Wind Power plants", 12, minigamesCode.windpowerMinigame, 2),

            };
            foreach (Minigame minigame in Games)
            {
                minigames.Add(minigame);
            }

            return minigames;
        }
    }
}