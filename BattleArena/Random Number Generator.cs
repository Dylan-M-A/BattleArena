using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleArena
{
    internal class Random_Number_Generator
    {
        public void RandomNumberGenerator()
        {
            Random rnd = new Random();

            for (int j = 0; j < 4; j++)
            {
                Console.WriteLine(rnd.Next(1, 20));
            }
        }
    }
}
