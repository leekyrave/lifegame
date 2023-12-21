using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace GameOfLife
{
    internal class MapEdite
    {
        private bool[,] map;
        private Dictionary<string, int> stats = new() {
            { "Gens", 0}, // Generations
            { "FIt", 0}, // Full number of iterations ~
            { "Deathes", 0},
            { "NLifes", 0}
        };
        public MapEdite(int X, int Y)
        {
            map = new bool[Y, X];
        }

        public void SetAlivePoint(int Y, int X)
        {
            map[CheckArray.GetAbsoluteIndex(map.GetLength(0), Y), CheckArray.GetAbsoluteIndex(map.GetLength(1), X)] = true;
            stats["NLifes"]++;
        }
        public void SetDeathPoint(int Y, int X)
        {
            map[CheckArray.GetAbsoluteIndex(map.GetLength(0), Y), CheckArray.GetAbsoluteIndex(map.GetLength(1), X)] = false;
            stats["Deathes"]++;
        }

        public Dictionary<string, int> GetStats() => stats;

        public void ShowMap()
        {
            for(int i  = 0; i < map.GetLength(0); i++)
            {
                for(int j = 0; j < map.GetLength(1); j++)
                {
                    if (map[i, j])
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write($"{Constants.ALIVE_POINT} ");
                        Console.ResetColor();
                    }

                    else
                        Console.Write($"{Constants.DEAD_POINT} ");
                }
                Console.Write("\n");
            }

            Console.Write("\n\n");
        }

        public bool NextGeneration()
        {
            bool isSomeChanges = false;
            for(int i = 0; i < map.GetLength(0); i++)
            {
                for(int j = 0; j < map.GetLength(1); j++)
                {
                    
                    stats["FIt"]++;
                    if (SetLiveOrDie(i, j))
                    {
                        isSomeChanges = true;
                        ShowMap();
                        Thread.Sleep(150);
                    }    
                     
                }
            }
            stats["Gens"]++;
            return isSomeChanges;
        }



        private bool SetLiveOrDie(int y, int x)
        {
            int y_tmp = 0;
            int x_tmp = 0;
            byte alive_points_near = 0;
            bool isChanges = false;
            for (int i = -1; i <= 1; i++)
            {
                for (int j = -1; j <= 1; j++)
                {
                    if (j == 0 && i == 0) continue;
                    y_tmp = CheckArray.GetAbsoluteIndex(map.GetLength(0), y + i);
                    x_tmp = CheckArray.GetAbsoluteIndex(map.GetLength(1), x + j);


                    alive_points_near = (map[y_tmp, x_tmp]) ? ++alive_points_near : alive_points_near;



                }
            }

            // If near point we have 3 alive points, in this point will be live
            if (!map[y, x] && alive_points_near == 3)
            {
                SetAlivePoint(y, x);
                isChanges = true;
                
            }
                
            // If near point we have less than 2 points and more than 3, this point will die
            if ((alive_points_near <= 1 || alive_points_near > 3) && map[y,x])
            {
                SetDeathPoint(y, x);
                isChanges = true;
            }

            return isChanges;
        }


    }
}
