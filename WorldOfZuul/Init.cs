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
            Country? India = new("India", "Wouldn't you know, India is located in South Asia");
            Countries.Add(India);
            Country? Brazil = new("Brazil", "Wouldn't you know, Brazil is located in South America");
            Countries.Add(Brazil);
            Country? Mozambique = new("Mozambique", "Wouldn't you know, Mozambique is located in Africa");
            Countries.Add(Mozambique);
            Country? USA = new("USA", "Wouldn't you know, USA is located in North America");
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
            India.InitRoom("UN Outpost", "You are standing between the locations of your two objectives. You can go either north or south");
            India.InitRoom("Outside Sewage Treatment Plant", "You find yourself outside an abandoned sewage treatment plant. It's your job to restore it to working condition. The entrance to the lobby is to the north.");
            India.InitRoom("Lobby", "You're inside the lobby of the plant. There is a storage room to the east and the tank room is to the west.");
            India.InitRoom("Tank Room", "You're inside the tank room. This is where the water gets recycled.");
            India.InitRoom("Storage Room", "You're in a storage room.");
            India.InitRoom("Field", "You're at a field that's in dire need of some fluids.");
            India.InitRoom("Eastern Shed", "You're in a shed.");
            India.InitRoom("Western Shed", "You're in a shed.");
            

            India.addExit("UN Outpost", new List<string> { "north", "south"}, new List<string> { "Outside Sewage Treatment Plant", "Field" });
            India.addExit("Outside Sewage Treatment Plant", new List<string> { "south", "north" }, new List<string> { "UN Outpost", "Lobby" });
            India.addExit("Lobby", new List<string> { "south", "west", "east" }, new List<string> { "Outside Sewage Treatment Plant", "Storage Room", "Tank Room" });
            India.addExit("Tank Room", new List<string> { "west" }, new List<string> { "Lobby" });
            India.addExit("Storage Room", new List<string> { "east" }, new List<string> { "Lobby" });
            India.addExit("Field", new List<string> { "north", "east", "west" }, new List<string> { "UN Outpost", "Eastern Shed", "Western Shed" });
            India.addExit("Eastern Shed", new List<string> { "west" }, new List<string> { "Field" });
            India.addExit("Western Shed", new List<string> { "east" }, new List<string> { "Field" });



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
            Mozambique.InitRoom("Outside", "You are standing outside the main entrance of the university. To the east is a large building, to the south is a computing lab, and to the west is the campus pub.");
            Mozambique.InitRoom("Theatre", "You find yourself inside a large lecture theatre. Rows of seats ascend up to the back, and there's a podium at the front. It's quite dark and quiet.");
            Mozambique.InitRoom("Pub", "You've entered the campus pub. It's a cosy place, with a few students chatting over drinks. There's a bar near you and some pool tables at the far end.");
            Mozambique.InitRoom("Lab", "You're in a computing lab. Desks with computers line the walls, and there's an office to the east. The hum of machines fills the room.");
            Mozambique.InitRoom("Office", "You've entered what seems to be an administration office. There's a large desk with a computer on it, and some bookshelves lining one wall.");


            Mozambique.addExit("Outside", new List<string> { "east", "south", "west" }, new List<string> { "Theatre", "Lab", "Pub" });
            Mozambique.addExit("Theatre", new List<string> { "west" }, new List<string> { "Outside" });
            Mozambique.addExit("Pub", new List<string> { "east" }, new List<string> { "Outside" });
            Mozambique.addExit("Lab", new List<string> { "north", "east" }, new List<string> { "Outside", "Office" });
            Mozambique.addExit("Office", new List<string> { "west" }, new List<string> { "Lab" });



            // //initialize rooms to USA
            USA.InitRoom("Outside", "You are standing outside the main entrance of the university. To the east is a large building, to the south is a computing lab, and to the west is the campus pub.");
            USA.InitRoom("Theatre", "You find yourself inside a large lecture theatre. Rows of seats ascend up to the back, and there's a podium at the front. It's quite dark and quiet.");
            USA.InitRoom("Pub", "You've entered the campus pub. It's a cosy place, with a few students chatting over drinks. There's a bar near you and some pool tables at the far end.");
            USA.InitRoom("Lab", "You're in a computing lab. Desks with computers line the walls, and there's an office to the east. The hum of machines fills the room.");
            USA.InitRoom("Office", "You've entered what seems to be an administration office. There's a large desk with a computer on it, and some bookshelves lining one wall.");


            USA.addExit("Outside", new List<string> { "east", "south", "west" }, new List<string> { "Theatre", "Lab", "Pub" });
            USA.addExit("Theatre", new List<string> { "west" }, new List<string> { "Outside" });
            USA.addExit("Pub", new List<string> { "east" }, new List<string> { "Outside" });
            USA.addExit("Lab", new List<string> { "north", "east" }, new List<string> { "Outside", "Office" });
            USA.addExit("Office", new List<string> { "west" }, new List<string> { "Lab" });

        }

        public List<Minigame> CreateGames()
        {
            List<Minigame> minigames = new List<Minigame>();
            Minigame[] Games = {
                new("Haiti", "Lab", "This is 1 game.", 11),
                new("Haiti", "Lab", "This is 2 game.", 12),
                new("Haiti", "Lab", "This is 3 game.", 13),
                new("Haiti", "Lab", "This is 4 game.", 14),
            
            };
            foreach (Minigame minigame in Games)
            {
                minigames.Add(minigame);
            }
            
            return minigames;
        }

        
    }
}