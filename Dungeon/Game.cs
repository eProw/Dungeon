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
            //Console.ReadKey();
            Console.WriteLine("Loading...");
            mapGen = new MapGen(600,300,50);
            render = new Render(Console.WindowWidth, Console.WindowHeight,mapGen);

            render.BufferMapAt(0,0);
            render.RenderMap();
            running = true;
            Run();
        }

        void Run()
        {
            int x = 0, y = 0;
            x = mapGen.region[0].x;
            y = mapGen.region[0].y;

            while (running)
            {
                render.BufferMapAt(x,y);
                render.RenderMap();

                //AÑADIR INPUT PARA EXPLORAR CUEVA
                x++;
                y++;
                System.Threading.Thread.Sleep(100);
            }

        }

        public void Stop()
        {
            running = false;
        }
	}
}

