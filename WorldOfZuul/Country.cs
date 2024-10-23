using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace WorldOfZuul
{
    public class Country
    {
        public string ShortDescription { get; private set; }
        public string LongDescription { get; private set; }
        public List<Room> Rooms { get; private set; } = new();
        public Dictionary<string, Country> Exits { get; private set; } = new();
        public Room? currentRoom { get; private set; }
        public Room? previousRoom { get; private set; }

        public Country(string shortDesc, string longDesc)
        {
            ShortDescription = shortDesc;
            LongDescription = longDesc;
        }


        public void SetExits(Country? Haiti, Country? India, Country? Brazil, Country? Mozambique, Country? USA)
        {
            SetExit("Haiti", Haiti);
            SetExit("India", India);
            SetExit("Brazil", Brazil);
            SetExit("Mozambique", Mozambique);
            SetExit("USA", USA);

        }

        public void addRoom(Room room)
        {
            Rooms.Add(room);
            Console.WriteLine(room);
            if (Rooms.Count == 1)
            {
                this.currentRoom = room;
                Console.WriteLine(this.currentRoom.ShortDescription);
            }
        }

        public void setRoom(Room croom, Room proom)
        {
            this.currentRoom = croom;
            this.previousRoom = proom;

        }

        public void SetExit(string direction, Country? neighbor)
        {
            if (neighbor != null)
                Exits[direction] = neighbor;
        }

    }
}