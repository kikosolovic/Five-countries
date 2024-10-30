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
            Country? Haiti = new("Haiti", "Wouldnt you know, Haiti is located in the Caribbean");
            Countries.Add(Haiti);
            Country? India = new("India", "Wouldnt you know, India is located in South Asia");
            Countries.Add(India);
            Country? Brazil = new("Brazil", "Wouldnt you know, Brazil is located in South America");
            Countries.Add(Brazil);
            Country? Mozambique = new("Mozambique", "Wouldnt you know, Mozambique is located in Africa");
            Countries.Add(Mozambique);
            Country? USA = new("USA", "Wouldnt you know, USA is located in North America");
            Countries.Add(Mozambique);

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
            India.InitRoom("Outside", "You are standing outside the main entrance of the university. To the east is a large building, to the south is a computing lab, and to the west is the campus pub.");
            India.InitRoom("Theatre", "You find yourself inside a large lecture theatre. Rows of seats ascend up to the back, and there's a podium at the front. It's quite dark and quiet.");
            India.InitRoom("Pub", "You've entered the campus pub. It's a cosy place, with a few students chatting over drinks. There's a bar near you and some pool tables at the far end.");
            India.InitRoom("Lab", "You're in a computing lab. Desks with computers line the walls, and there's an office to the east. The hum of machines fills the room.");
            India.InitRoom("Office", "You've entered what seems to be an administration office. There's a large desk with a computer on it, and some bookshelves lining one wall.");


            India.addExit("Outside", new List<string> { "east", "south", "west" }, new List<string> { "Theatre", "Lab", "Pub" });
            India.addExit("Theatre", new List<string> { "west" }, new List<string> { "Outside" });
            India.addExit("Pub", new List<string> { "east" }, new List<string> { "Outside" });
            India.addExit("Lab", new List<string> { "north", "east" }, new List<string> { "Outside", "Office" });
            India.addExit("Office", new List<string> { "west" }, new List<string> { "Lab" });


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

    }
}