using System;

namespace Dungeon
{
	public class Render
	{
		int w,h;
        MapGen mapGen;
		char[,] screen,lastFrame;

        int frameNum = 0;

		public Render (int _w , int _h,MapGen _mapGen)
		{
			w = _w;
			h= _h;

			screen = new char[w,h];
            lastFrame = new char[w,h];
            mapGen = _mapGen;
		}

		public void BufferMapAt(int X,int Y){
			for(int x = 0; x < w;x++)
				for(int y = 0; y < h;y++){
                    if (x + X < mapGen.w && x+X >0 && y + Y < mapGen.h && y+Y>0)
                    {
                        char c = ' ';

                        switch (mapGen.Map[x + X, y + Y].tType)
                        {
                            case tileType.wall:
                                c = '░';
                                break;

                            case tileType.floor:
                                c = ' ';
                                break;

                            case tileType.grass:
                                c = ',';
                                break;

                            default:
                                break;
                        }
                        screen[x, y] = c;
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
                    if (screen[x,y] != lastFrame[x,y]) {
                        Console.SetCursorPosition(x, y);
                        Console.Write(screen[x, y]);
                        lastFrame[x, y] = screen[x, y];
                    }
                }
            frameNum++;
        }
	}
}

