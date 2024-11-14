using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FiveCountries
{
    public class Init
    {

        public List<Country> CreateCountries()
        {
            List<Country> Countries = new List<Country>();
            Country? Haiti = new("Haiti", "Wouldn't you know, Haiti is located in the Caribbean");
            Countries.Add(Haiti);

            Country? India = new("India", "Your objectives in India revolve around Goal 6 - Clean water and sanitation.\n \n"
            + "Due to the overprivatization of underground springs, there aren't enough left to support the country's crop fields.\n"
            + "This leads to overreliance on seasonal rains and ultimately - in a poor yield.\nOne of your objectives is to find an underground water source.\n"
            + "We believe that one such source of substantial quantity is located somewhere in the area that you find yourself in.\n"
            + "You need to find it and use it to install an irrigation system for one of the major crop fields in the region of Allahabad.\n \n"
            + "Due to waste, both industrial and human, India's rivers are contaminated and the water is unfit to drink.\n"
            + "This results in the consumption of polluted water and subsequently, morbidity and mortality increases.\n"
            + "There is an abandoned sewage treatment plant in the village of Kaithi that must be restored to working condition immediately. That's your other objective.\n"
            + "This will go a long way to help decrease the flow of waste going into the Ganges river.");
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
            India.InitRoom("Storage Room", "You're in a storage room. You look around and find the pipes you need.");
            India.InitRoom("Crop Field", "You're at the crop field mentioned in the report. You will need drip tubes and emitters to be able to install the irrigation system. There's two sheds to the west and east. You should check what's inside them.");
            India.InitRoom("Eastern Shed", "You're in a shed. You look around and you find a box with emitters in it. Just the ones you need.");
            India.InitRoom("Western Shed", "You're in a shed. You look around and spot drip tubes on one of the shelves. Jackpot!");


            India.addExit("UN Outpost", new List<string> { "north", "south" }, new List<string> { "Outside Sewage Treatment Plant", "Crop Field" });
            India.addExit("Outside Sewage Treatment Plant", new List<string> { "south", "north" }, new List<string> { "UN Outpost", "Lobby" });
            India.addExit("Lobby", new List<string> { "south", "west", "east" }, new List<string> { "Outside Sewage Treatment Plant", "Storage Room", "Tank Room" });
            India.addExit("Tank Room", new List<string> { "west" }, new List<string> { "Lobby" });
            India.addExit("Storage Room", new List<string> { "east" }, new List<string> { "Lobby" });
            India.addExit("Crop Field", new List<string> { "north", "east", "west" }, new List<string> { "UN Outpost", "Eastern Shed", "Western Shed" });
            India.addExit("Eastern Shed", new List<string> { "west" }, new List<string> { "Crop Field" });
            India.addExit("Western Shed", new List<string> { "east" }, new List<string> { "Crop Field" });



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
            Mozambique.InitRoom("Dock", "You just arrived to Mozambique. The boat dropped you off at a small dock. ", minigameFunctions.Dock);
            Mozambique.InitRoom("Village", "You find yourself inside a large lecture theatre. Rows of seats ascend up to the back, and there's a podium at the front. It's quite dark and quiet.");
            Mozambique.InitRoom("Hill", "You've entered the campus pub. It's a cosy place, with a few students chatting over drinks. There's a bar near you and some pool tables at the far end.");
            Mozambique.InitRoom("Lab", "You're in a computing lab. Desks with computers line the walls, and there's an office to the east. The hum of machines fills the room.");
            Mozambique.InitRoom("Office", "You've entered what seems to be an administration office. There's a large desk with a computer on it, and some bookshelves lining one wall.");


            Mozambique.addExit("Dock", new List<string> { "west" }, new List<string> { "Village" });
            Mozambique.addExit("Village", new List<string> { "north", "east" }, new List<string> { "Hill", "Dock" });
            Mozambique.addExit("Hill", new List<string> { "south" }, new List<string> { "village" });
            Mozambique.addExit("Lab", new List<string> { "north", "east" }, new List<string> { "Outside", "Office" });
            Mozambique.addExit("Office", new List<string> { "west" }, new List<string> { "Lab" });



            // //initialize rooms to USA
            USA.InitRoom("NYC", "You are in New York City, where waste management and recycling initiatives are critical to reducing urban waste.");
            USA.InitRoom("LA", "You are in Los Angeles, dealing with challenges related to plastic waste and sustainable disposal methods..");
            USA.InitRoom("SF", "You are in San Francisco, known for its zero-waste goals and composting initiatives.");
            USA.InitRoom("HOU", "You are in Houston, where industrial waste and hazardous waste management are major concerns.");
            USA.InitRoom("CHI", "You are in Chicago, focusing on electronic waste recycling and management.");


            USA.addExit("NYC", new List<string> { "east", "south", "west" }, new List<string> { "LA", "HOU", "SF" });
            USA.addExit("LA", new List<string> { "west" }, new List<string> { "NYC" });
            USA.addExit("SF", new List<string> { "east" }, new List<string> { "NYC" });
            USA.addExit("HOU", new List<string> { "north", "east" }, new List<string> { "NYC", "CHI" });
            USA.addExit("CHI", new List<string> { "west" }, new List<string> { "HOU" });

        }

        public List<Minigame> CreateGames()
        {
            List<Minigame> minigames = new List<Minigame>();
            Minigame[] Games = {
                new("Haiti", "Lab", "This is 1 game.", 11, 5),
                new("Haiti", "Lab", "This is 2 game.", 12, 5),
                new("Haiti", "Lab", "This is 3 game.", 13, 5),
                new("Haiti", "Lab", "This is 4 game.", 14, 5),

            };
            foreach (Minigame minigame in Games)
            {
                minigames.Add(minigame);
            }

            return minigames;
        }


    }
}