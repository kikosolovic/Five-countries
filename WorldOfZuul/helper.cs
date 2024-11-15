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

            var i = (text.Length > 70) ? 10 : 30;
            foreach (var ch in text)
            {
                Console.Write(ch);
                Thread.Sleep(i);
            }
            Console.WriteLine("\n");
        }

    }
}