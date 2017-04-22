using System;

namespace Dungeon
{
	public class Render:Game
	{
		int w,h;

		char[,] screen;

		public Render (int _w , int _h)
		{
			w = _w;
			h= _h;

			screen = new char[w,h];
		}

		void BufferMapAt(int X,int Y){
			for(int x = 0; x < w;x++)
				for(int y = 0; y < h;y++){
					screen[x,y] = mGen.Map[x+X,y+Y].tType== tileType.floor?' ':'0';
				}
		}

		void RenderMap(){
			
		}
	}
}

