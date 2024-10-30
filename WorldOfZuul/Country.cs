using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace FiveCountries
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
            SetExit("haiti", Haiti);
            SetExit("india", India);
            SetExit("brazil", Brazil);
            SetExit("mozambique", Mozambique);
            SetExit("usa", USA);

        }

        public void addRoom(Room room)
        {
            Rooms.Add(room);
            if (Rooms.Count == 1)
            {
                this.currentRoom = room;
                Console.WriteLine(this.currentRoom.ShortDescription);
            }
        }


        public void InitRoom(string ShortDescription, string LongDescription)
        {
            Room room = new Room(ShortDescription, LongDescription);
            this.Rooms.Add(room);
            if (this.Rooms.Count == 1)
            {
                this.currentRoom = room;
            }
        }

        public void addExit(string roomName, List<string> directions, List<string> neighborNames)
        {

            Room? room = Rooms.Find(r => r.ShortDescription == roomName);

            if (room != null)
            {

                for (int i = 0; i < directions.Count; i++)
                {
                    room.SetExit(directions[i], Rooms.Find(r => r.ShortDescription == neighborNames[i]));
                }

            }
            else
            {
                Console.WriteLine("Room not found " + roomName);
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