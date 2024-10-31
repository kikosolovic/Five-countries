using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;


namespace FiveCountries
{
    public class Minigame
    {
        public string country {get; set;}
        public string room {get; set;}
        public string description {get; set;}
        public int id {get; set;}

        public Minigame(string country2, string room2, string description2, int id2){
            country = country2;
            room = room2;
            description = description2;
            id = id2;
        }

    }





}