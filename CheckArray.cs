using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfLife 
{
    public class CheckArray
    {
        public static void SetLiveOrDie(ref bool[,] array, int y, int x)
        {
            for(int i = -1; i <= 1; i++)
            {
                for(int j = -1; j <= 1; j++)
                {
                    if (j == 0) continue;
                    try
                    {
                        y = (y + i > array.GetLength(0)) ? (Math.Abs(i) % y) - 1 : (y + i < 0) ? array.Length : y + i;
                        x = (x + j > array.GetLength(1)) ? (Math.Abs(j) % x) - 1 : (x + j < 0) ? 5 : x + j;

                        array[y + i, x + j] = true;
                    } catch(Exception e)
                    {
                        Console.WriteLine(e.ToString());
                    }
                    
                }
            }
        }


    }

}
