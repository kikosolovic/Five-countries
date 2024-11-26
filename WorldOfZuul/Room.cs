﻿using System.Dynamic;
using static System.Formats.Asn1.AsnWriter;


namespace FiveCountries
{
    //creates a delegate for minigames so that they can be passed as arguments in Init.cs
    public delegate void MinigameDelegate(ref int score);

    public class Room
    {
        public string ShortDescription { get; private set; }
        public string LongDescription { get; private set; }
        public bool mminigamePlayed = false;

        public MinigameDelegate? minigame { get; set; } = null;
        public Dictionary<string, Room> Exits { get; private set; } = new();

        public Room(string shortDesc, string longDesc)
        {
            ShortDescription = shortDesc;
            LongDescription = longDesc;

        }
        public Room(string shortDesc, string longDesc, MinigameDelegate? minigame)
        {
            ShortDescription = shortDesc;
            LongDescription = longDesc;
            this.minigame = minigame;
        }

        // runs the minigame that is assigned to the room in Init.cs, if there isnt one > null, after the minigame is played it is deleted so
        // player cannot play it multiple times, (might not be the best solution if he fails he has to restart game to play again)
        public void ExecuteMinigame(ref int score)
        {
            if (minigame != null && !mminigamePlayed)
            {
                minigame(ref score);  // Pass the score by reference
                this.mminigamePlayed = true;  // Reset the minigame so it can't be played again
            }
            // else
            // {
            //     Console.WriteLine("There is no minigame in this room, or you have already played it.");
            // }
        }
        public void playAgain()
        {
            this.mminigamePlayed = false;
            //possible score to get * .5
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