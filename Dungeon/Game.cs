using System;

namespace Dungeon
{
	public class Game
	{
		public MapGen mapGen;
		public Render render;
		public Game ()
		{
			render = new Render(Console.WindowWidth,Console.WindowHeight);
            Console.WriteLine("Hello world");//Foo

            Console.ReadKey(true);
			
        }

	}
}

