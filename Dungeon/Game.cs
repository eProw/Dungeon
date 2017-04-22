using System;

namespace Dungeon
{
	public class Game
	{
		public MapGen mapGen;
		public Render render;
		public Game ()
		{
            Console.WriteLine("Hello world");

            Console.ReadKey(true);
            //Initialize variables by calling it out of this constructor
            Start();
        }

        void Start()
        {
            render = new Render(Console.WindowWidth, Console.WindowHeight);
        }

	}
}

