using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WorldOfZuul
{
    public static class helper
    {
        public static void WriteWithDelay(string text)
        {
            foreach (var ch in text)
            {
                Console.Write(ch);
                Thread.Sleep(20);
            }
            Console.WriteLine("\n");
        }

    }
}