using System;

namespace Dungeon
{
	public class Render
	{
		int w,h;
        MapGen mapGen;
		char[,] screen;

		public Render (int _w , int _h,MapGen _mapGen)
		{
			w = _w;
			h= _h;

			screen = new char[w,h];
            mapGen = _mapGen;
		}

		public void BufferMapAt(int X,int Y){
			for(int x = 0; x < w;x++)
				for(int y = 0; y < h;y++){
                    if (x + X < mapGen.w && y + Y < mapGen.h)
                    {
                        screen[x, y] = mapGen.Map[x + X, y + Y].tType == tileType.floor ? ' ' : '░';
                    }
                    else
                    {
                        screen[x, y] = '░';
                    }
				}
		}

        public void RenderMap()
        {
            for (int x = 0; x < w; x++)
                for (int y = 0; y < h; y++)
                {
                    Console.SetCursorPosition(x,y);
                    Console.Write(screen[x,y]);
                }
        }
	}
}

