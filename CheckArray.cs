using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfLife 
{
    public class CheckArray
    {

        // Something like "Cyclic array for topologic map"
        public static int GetAbsoluteIndex(int size, int index)
        {
            /* 
                if(index >= size) 
                    index = index % size;
                else if(index < 0)
                    index = size - (Math.Abs(index) % size);

                Example:
                    Size of array: 25;
                    Index: 25
                In normal situations it will be Exception(overflow), but if we use absolute index - it will be INDEX: 0. 26 - 1; 27 - 2, etc..

                Example #2:
                    Size of array: 25;
                    Index: -5
                If we use abs. index - it will be INDEX: 20, etc...
            */
            index = (index >= size) ? index % size : (index < 0) ? size - (Math.Abs(index) % size) : index; 
            return index;
        }


    }

}
