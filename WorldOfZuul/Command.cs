using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FiveCountries
{
    public class Command
    {
        public string Name { get; }
        public string? SecondWord { get; }

        public Command(string name, string? secondWord = null)
        {
            Name = name;
            SecondWord = secondWord;
        }
    }
}
