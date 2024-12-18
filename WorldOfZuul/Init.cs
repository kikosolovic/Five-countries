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
            Country? Denmark = new("Denmark", "Your home. \n \n");
            Countries.Add(Denmark);

            Country? Haiti = new("Haiti", "Your objectives in Haiti revolve around Goal 7 - Affordable and clean energy.");
            Countries.Add(Haiti);

            Country? India = new("India", "Your objectives in India revolve around Goal 6 - Clean water and sanitation. \n \n");
            Countries.Add(India);

            Country? Brazil = new("Brazil", "Your objectives in Brazil revolve around Goal 15 - Life on land. \n \n");
            Countries.Add(Brazil);

            Country? Mozambique = new("Mozambique", "Your objectives in Mozambique revolve around Goal 13 - Climate action. \n \n");
            Countries.Add(Mozambique);

            Country? USA = new("USA", "Your objectives in the US revolve around Goal 12 - Responsible consumption and production. \n \n");
            Countries.Add(USA);


            Haiti.SetExits(Denmark, Haiti, India, Brazil, Mozambique, USA);
            India.SetExits(Denmark, Haiti, India, Brazil, Mozambique, USA);
            Brazil.SetExits(Denmark, Haiti, India, Brazil, Mozambique, USA);
            Mozambique.SetExits(Denmark, Haiti, India, Brazil, Mozambique, USA);
            USA.SetExits(Denmark, Haiti, India, Brazil, Mozambique, USA);
            Denmark.SetExits(Denmark, Haiti, India, Brazil, Mozambique, USA);

            return Countries;


        }
        public void CreateRooms(List<Country> countries)
        {
            MinigameCode minigameFunctions = new MinigameCode();
            Country Denmark = countries[0];
            Country Haiti = countries[1];
            Country India = countries[2];
            Country Brazil = countries[3];
            Country Mozambique = countries[4];
            Country USA = countries[5];

            // //Initialize rooms to Denmark
            Denmark.InitRoom("Home", "You're at home right now. You have other places to be, however.");

            // //initialize rooms to Haiti
            Haiti.InitRoom("Outside", "You're at the beautiful park in the middle of the complex.");
            Haiti.InitRoom("Lobby", "You're inside the main hall of the complex.");
            //Haiti.InitRoom("Corridor", "This corridor leads to the other rooms.");
            Haiti.InitRoom("PV Lab", "It's pretty dark here. You are in the PV Lab. \n We often test solar panels here, so we need to keep it dark. \n You can see a lot of solar panels and inverters around you. \n This is the place where we design and plan future solar panels.", new MinigameDelegate(minigameFunctions.photovoltaicMinigame),"choosen best locations for some solar power plants");
            Haiti.InitRoom("Wind Lab", "It's windy here! You are in the Wind Lab. You can see a lot of wind turbines and anemometers around you.\nThere are also countless TVs with real-world and simulation data about wind power plants.\nThis is the place where we design and plan future wind turbines.", new MinigameDelegate(minigameFunctions.windpowerMinigame), "choosen best locations for some wind power plants");
            //Haiti.InitRoom("Energy Storage Lab", "This is the Energy Storage Lab. You can see a lot of batteries and capacitors around you.\nThis is the place where we design and plan future energy storages.");
            //Haiti.InitRoom("Closet", "It's silent here, and also nothing intresting, just some old brooms, mops and tons of dust.");
            //Haiti.InitRoom("Infrastructure Building", "Building of the Infrastructure Department");
            //Haiti.InitRoom("Server Building", "Building of the Computational Department");


            Haiti.addExit("Outside", new List<string> { "south"/*, "north", "west"*/ }, new List<string> { "Lobby"/*, "Infrastructure Building", "Server Building" */});
            Haiti.addExit("Lobby", new List<string> { /*"south",*/ "north", "west", "east" }, new List<string> { /*"Corridor",*/ "Outside", "Wind Lab", "PV Lab" });
            //Haiti.addExit("Corridor", new List<string> { "north", "west", "east" }, new List<string> { "Lobby", "Energy Storage Lab", "Closet", });
            Haiti.addExit("PV Lab", new List<string> { "west" }, new List<string> { "Lobby" });
            Haiti.addExit("Wind Lab", new List<string> { "east" }, new List<string> { "Lobby" });
            //Haiti.addExit("Energy Storage Lab", new List<string> { "east" }, new List<string> { "Corridor" });
            //Haiti.addExit("Closet", new List<string> { "west" }, new List<string> { "Corridor" });
            //Haiti.addExit("Infrastructure Building", new List<string> { "south" }, new List<string> { "Outside" });
            //Haiti.addExit("Server Building", new List<string> { "east" }, new List<string> { "Outside" });



            // //initialize rooms to India
            India.InitRoom("UN Outpost", "You are just outside of a UN outpost located between your two objectives.", new MinigameDelegate(minigameFunctions.UNOutpost));
            India.InitRoom("Outside Sewage Treatment Plant", "You find yourself outside the abandoned plant. It looks dilapidated and dirty. The entrance to the lobby is to the north.");
            India.InitRoom("Lobby", "You're inside the lobby of the plant. There's trash on the ground everywhere. The tank room is to the east.");
            India.InitRoom("Storage Room", "There's nothing to see here that's of importance.");
            India.InitRoom("Tank Room", "You're inside the tank room.", new MinigameDelegate(minigameFunctions.SewagePlantQuiz), "restored function to the village of Kaithi's sewage treatment plant.");
            India.InitRoom("Crop Field", "You're in front of the crop field.", new MinigameDelegate(minigameFunctions.CropFieldQuiz), "installed a brand new drip irrigation system to a crop field in the Indian state of Uttar Pradesh.");

            India.addExit("UN Outpost", new List<string> { "north", "south" }, new List<string> { "Outside Sewage Treatment Plant", "Crop Field" });
            India.addExit("Outside Sewage Treatment Plant", new List<string> { "south", "north" }, new List<string> { "UN Outpost", "Lobby" });
            India.addExit("Lobby", new List<string> { "south", "east", "west" }, new List<string> { "Outside Sewage Treatment Plant", "Tank Room", "Storage Room" });
            India.addExit("Storage Room", new List<string> { "east" }, new List<string> { "Lobby" });
            India.addExit("Tank Room", new List<string> { "west" }, new List<string> { "Lobby" });
            India.addExit("Crop Field", new List<string> { "north" }, new List<string> { "UN Outpost" });



            // //initialize rooms to Brazil
            Brazil.InitRoom("Deforestated Area", "You are now in a Deforestated Area", new MinigameDelegate(minigameFunctions.guessTree), "beaten guessing number of trees game");
            Brazil.InitRoom("Mining Zone", "You are now in a Illegal Mining Zone.", new MinigameDelegate(minigameFunctions.beatMiners), "beaten illegal miners game");
            Brazil.InitRoom("Tribe", "You are now in a Indigenous tribe."/*, new MinigameDelegate(minigameFunctions.tribeHangman), "beaten tribe hangman game"*/);
           
            Brazil.addExit("Deforestated Area", new List<string> { "south" }, new List<string> { "Mining Zone"});
            Brazil.addExit("Mining Zone", new List<string> { "north","south" }, new List<string> { "Deforestated Area","Tribe" });
            Brazil.addExit("Tribe", new List<string> { "north" }, new List<string> { "Mining Zone" });
          

            //initialize rooms to Mozambique
            Mozambique.InitRoom("Dock", "You just arrived to Mozambique. The boat dropped you off at a small dock. ", new MinigameDelegate(minigameFunctions.Dock));
            Mozambique.InitRoom("Village", "You find yourself in a small village. People are walking around. ", new MinigameDelegate(minigameFunctions.Village));
            Mozambique.InitRoom("Field", "You are in a rice field. There are paths in between the individual rice plants. Locals are caring for the rice, this harvest is going to be plentiful.", new MinigameDelegate(minigameFunctions.Field), "saved the rice field from flooding in Mozambique.");
            Mozambique.InitRoom("Hill", "You have a view of the whole village and the oocean behind it.", new MinigameDelegate(minigameFunctions.Hill), "fixed the weather station and helped the village prepare for bad weather in advance in Mozambique.");
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
        
    }
}