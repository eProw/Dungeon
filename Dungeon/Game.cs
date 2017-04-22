using System;

namespace Dungeon
{
	public class Game
	{
		public MapGen mGen;
		public Render render;
		public Game ()
		{
            Console.WriteLine("Hello world");

            Console.ReadKey(true);
            //Initialize variables by calling it out of the constructor
            Init();
        }

        void Init()
        {
            render = new Render(Console.WindowWidth, Console.WindowHeight);
        }

	}
}

