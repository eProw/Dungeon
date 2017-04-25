using System;

namespace Dungeon
{
	class MainClass
	{
		public static void Main (string[] args)
		{
			Console.Title = "Dungeon";
            Console.CursorVisible = false;
			Game game = new Game ();
		}
	}
}
