namespace GameOfLife;
class Program
{
    static void Main(string[] args)
    {
        int X, Y = 0;
        Console.WriteLine("Welcome to the game! Game of Life.\nPlease, enter the size of game-map X x Y\nValid sizes is:\nX: {0} - {1}\nY: {2} - {3}\n\nX: ", Constants.MIN_HORIZONTAL, Constants.MAX_HORIZONTAL, Constants.MIN_VERTICAL, Constants.MAX_VERTICAL);

      
        while(true)
        {
            if(Int32.TryParse(Console.ReadLine(), out X))
            {
                if(X <= Constants.MAX_HORIZONTAL && X >= Constants.MIN_HORIZONTAL) 
                    break;
            }
            Console.WriteLine("Entered number isn't valid");
        }


        Console.WriteLine("Y: ");
        while (true)
        {
            if (Int32.TryParse(Console.ReadLine(), out Y))
            {
                if (Y <= Constants.MAX_VERTICAL && Y >= Constants.MIN_VERTICAL)
                    break;
            }
            Console.WriteLine("Entered number isn't valid");
        }

        MapEdite mapProcess = new(X,Y);


        mapProcess.ShowMap();
        Console.WriteLine("Map Initialized.\nNow all of points are died, please, set alive points for start(write X, Y of this point)\nWrite like: 5 4");

        
        while(true)
        {
            var input = Console.ReadLine();
            if (input == "") break;

            var splittedIntegers = input.Split(' ');
            int X_t, Y_t;
            while (true)
            {
                if (Int32.TryParse(splittedIntegers[0], out X_t) && Int32.TryParse(splittedIntegers[1], out Y_t))
                {
                    break;
                }

                Console.WriteLine("Bad values");
            }

            if(X_t > X || Y_t > Y)
            {
                Console.WriteLine("Bad number, overflow");
                continue;
            }

            mapProcess.SetAlivePoint(X_t, Y_t);

            mapProcess.ShowMap();
        }

        Console.WriteLine("Game is Started");

        while(true)
        {

        }







        


    }
}