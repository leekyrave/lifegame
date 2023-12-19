using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfLife
{
    internal static class Constants
    {
        public const int MAX_VERTICAL = 100;
        public const int MIN_VERTICAL = 25;

        public const int MAX_HORIZONTAL = 100;
        public const int MIN_HORIZONTAL = 25;

        public const string ALIVE_POINT = "\x1b[92m*\x1b[39m";
        public const string DEAD_POINT = "*";


    }
}
