namespace GameOfLife;
class Program
{
    static void Main(string[] args)
    {
        Console.OutputEncoding = System.Text.Encoding.Unicode;
        int X = 0, Y = 0;
        byte type = 1;
        Console.WriteLine("Welcome to the game! Game of Life.\nPlease, enter the size of game-map X x Y\nValid sizes is:\nX: {0} - {1}\nY: {2} - {3}\n\nX: ", Constants.MIN_HORIZONTAL, Constants.MAX_HORIZONTAL, Constants.MIN_VERTICAL, Constants.MAX_VERTICAL);
        // Validating numbers of Y and X
        while (true)
        {
            if(Int32.TryParse(Console.ReadLine(), out X))
            {
                if(X <= Constants.MAX_HORIZONTAL && X >= Constants.MIN_HORIZONTAL) 
                    break;
            }
            Console.WriteLine("Entered number isn't valid");
        }

        // Validating
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

        // Set default variables of map, died or living points
        while(true)
        {
            var input = Console.ReadLine();
            if (input == "") break;

            
            int X_t, Y_t;
            var splittedIntegers = input.Split(' ');

            if (splittedIntegers.Length < 2)
            {
                Console.WriteLine("Miss arguments. Try again");
                continue;
            }
                

            while (true)
            {

                if (splittedIntegers.Length == 2 &&
                    int.TryParse(splittedIntegers[0], out X_t) &&
                    int.TryParse(splittedIntegers[1], out Y_t))
                    break;

            }


            if (X_t > X || Y_t > Y)
            {
                Console.WriteLine("Bad number, overflow");
                continue;
            }

            
            mapProcess.SetAlivePoint(Y_t, X_t);

            mapProcess.ShowMap();
        }

        Console.WriteLine("Game is ready\nPress some key to start\nIf you want to stop game - just press random key");

        Console.ReadKey();
        // Start of the game
        while(!Console.KeyAvailable)
        {
            if(!mapProcess.NextGeneration())
                break;
        }

        Dictionary<string, int> stats = mapProcess.GetStats();
        Console.WriteLine($"Game is end.\n\nStatistics:\n\nGenerations: {stats["Gens"]}\nNew lifes: {stats["NLifes"]}\nDeathes: {stats["Deathes"]}");

        ConsoleKeyInfo cki;

        while(true)
        {
            cki = Console.ReadKey();
            if (cki.Key == ConsoleKey.Enter)
                break;
        }

    }
}