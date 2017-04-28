using System;
using System.Windows.Forms;

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
            mapGen = new MapGen(150,100,50);
            render = new Render(Console.WindowWidth, Console.WindowHeight,mapGen);

            render.BufferMapAt(0,0);
            render.RenderMap();
            running = true;
            Run();
        }

        void Run()
        {
            int x = 0, y = 0;

            while (running)
            {

                //Console.ReadKey(true);


                render.BufferMapAt(x,y);
                render.RenderMap();
                //AÑADIR INPUT PARA EXPLORAR CUEVA
                if (Cursor.Position.X > 700)
                    x++;
                else if (Cursor.Position.X < 400)
                    x--;

                if (Cursor.Position.Y > 600)
                    y++;
                else if (Cursor.Position.Y < 300)
                    y--;
                //x--;
                //y--;
                System.Threading.Thread.Sleep(10);
            }

        }

        public void Stop()
        {
            running = false;
        }
	}
}

