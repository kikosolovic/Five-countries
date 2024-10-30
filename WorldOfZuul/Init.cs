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
        public List<Room> CreateRooms()
        {

            List<Room> Rooms = new List<Room>();
            Room? outside = new("Outside", "You are standing outside the main entrance of the university. To the east is a large building, to the south is a computing lab, and to the west is the campus pub.");
            Rooms.Add(outside);
            Room? theatre = new("Theatre", "You find yourself inside a large lecture theatre. Rows of seats ascend up to the back, and there's a podium at the front. It's quite dark and quiet.");
            Rooms.Add(theatre);
            Room? pub = new("Pub", "You've entered the campus pub. It's a cozy place, with a few students chatting over drinks. There's a bar near you and some pool tables at the far end.");
            Rooms.Add(pub);
            Room? lab = new("Lab", "You're in a computing lab. Desks with computers line the walls, and there's an office to the east. The hum of machines fills the room.");
            Rooms.Add(lab);
            Room? office = new("Office", "You've entered what seems to be an administration office. There's a large desk with a computer on it, and some bookshelves lining one wall.");
            Rooms.Add(office);
            outside.SetExits(null, theatre, lab, pub); // North, East, South, West

            theatre.SetExit("west", outside);

            pub.SetExit("east", outside);

            lab.SetExits(outside, office, null, null);

            office.SetExit("west", lab);
            return Rooms;


        }
        public void QuickAssign(List<Room> Rooms, List<Country> Countries)
        {
            foreach (var country in Countries)
            {
                foreach (var Room in Rooms)
                {
                    country.addRoom(Room);
                }
            }
        }
    }
}