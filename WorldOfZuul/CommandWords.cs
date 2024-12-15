using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FiveCountries
{
    public class CommandWords
    {
        public List<string> ValidCommands { get; } = new List<string> { "north", "east", "south", "west", "look", "back", "help", "quit", "travel", "map", "play", "score", "score", "denmark", "haiti", "india", "brazil", "mozambique", "usa", "pick", "seeds", "pipes", "tubes", "emitters", "startminigame", "hammer", "analyze", "stoptalking", "playagain", "weather", "configure", "error", "sweep", "plant", "unplant" };

        public bool IsValidCommand(string command)
        {
            return ValidCommands.Contains(command.ToLower());
        }
    }

}
