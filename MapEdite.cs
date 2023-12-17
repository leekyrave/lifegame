using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfLife
{
    internal class MapEdite
    {
        bool[,] map;

        public MapEdite(int X, int Y) {
            map = new bool[Y, X];
        }

        public void SetAlivePoint(int X, int Y) => map[Y, X] = true;
        public void SetDeathPoint(int X, int Y) => map[Y, X] = false;

        public void ShowMap()
        {
            for(int i  = 0; i < map.GetLength(0); i++)
            {
                for(int j = 0; j < map.GetLength(1); j++)
                {
                    if (map[i, j])
                    {
                        Console.Write($"{Constants.ALIVE_POINT} ");
                    } else
                    {
                        Console.Write($"{Constants.DEAD_POINT} ");
                    }
                }
                Console.Write("\n");
            }
        }

        public void NextGeneration()
        {
            bool[,] tmp;
            for(int i = 0; i  <= map.GetLength(0); i++)
            {
                for(int j = 0; j <= map.GetLength(1); j++)
                {
                     
                }
            }
        }
    }
}
