using System;

namespace Dungeon
{
	public class Game
	{
        bool running = false;
		public MapGen mapGen;
		public Render render;
		public Game ()
        {
            //Initialize variables by calling it out of this constructor
            Start();
        }

        public void Start()
        {
            Console.WriteLine("Loading...");
            mapGen = new MapGen(200,60,62543,50);
            render = new Render(Console.WindowWidth, Console.WindowHeight,mapGen);

            render.BufferMapAt(0,0);
            render.RenderMap();
            running = true;
            Run();
        }

        void Run()
        {
            while (running)
            {

            }

        }

        public void Stop()
        {
            running = false;
        }
	}
}

