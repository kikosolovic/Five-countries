using System.Dynamic;
using static System.Formats.Asn1.AsnWriter;


namespace FiveCountries
{
    //creates a delegate for minigames so that they can be passed as arguments in Init.cs
    public delegate void MinigameDelegate();
    public class Room
    {
        public string ShortDescription { get; private set; }
        public string LongDescription { get; private set; }
        public bool minigamePlayed = false;
        public bool minigameCompleted = false;
        public string outcome;

        public MinigameDelegate? minigame { get; set; } = null;
        public Dictionary<string, Room> Exits { get; private set; } = new();

        public Room(string shortDesc, string longDesc, MinigameDelegate? minigame, string outcome)
        {
            ShortDescription = shortDesc;
            LongDescription = longDesc;
            this.minigame = minigame;
            this.outcome = outcome;
        }


        public void ExecuteMinigame(int score = 0)
        {
            if (minigame != null && !minigamePlayed)
            {
                minigame();
                this.minigamePlayed = true;
            }

        }
        public void playAgain()
        {
            this.minigamePlayed = false;
        }


        public void SetExits(Room? north, Room? east, Room? south, Room? west)
        {
            SetExit("north", north);
            SetExit("east", east);
            SetExit("south", south);
            SetExit("west", west);
        }


        public void SetExit(string direction, Room? neighbor)
        {
            if (neighbor != null)
                Exits[direction] = neighbor;
        }
    }
}