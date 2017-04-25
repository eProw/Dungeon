using System;
using System.Collections.Generic;

namespace Dungeon
{
	public class MapGen
	{
		Random rand;
        public bool ready = false;

		bool[,] map;

		public Tile[,] Map;

		int _W ,_H;

		public int w{ 
			get{
				return _W;
		}}
		public int h{
			get{ 
				return _H;
		}} 

        public int fillPerc;

		public MapGen (int _w, int _h, int seed, int perc)
		{
			rand = new Random (seed);
			_W = _w;
			_H = _h;
			map = new bool[_w,_h];

			Map = new Tile[_w,_h];
            fillPerc = perc;
            GenerateMap();
		}

		public void GenerateMap(){
			GenerateRandomMap ();
            for(int i = 0; i < 3; i++)
            SmoothMap();

            for (int x = 0; x < w; x++)
            {
                for (int y = 0; y < h; y++)
                {
                    Map[x, y] = new Tile(x, y, map[x, y] ? tileType.wall : tileType.floor);
                }
            }

            ready = true;
        }

        void GenerateRandomMap()
        {
            InitMap();
            for (int x = 0; x < w; x++)
                for (int y = 0; y < h; y++)
                {
                    map[x, y] = rand.Next(0,100) < fillPerc;
                }
        }

        void SmoothMap()
        {
            for (int x = 0; x < w; x++)
                for (int y = 0; y < h; y++)
                {
                    int neighbours = GetNeighbours(x,y);
                    if (neighbours > 4)
                    {
                        map[x, y] = true;
                    }
                    else if (neighbours < 4)
                    {
                        map[x, y] = false;
                    }
                }
        }

        int GetNeighbours(int xOffset,int yOffset)
        {
            int neighbours = 0;

            for(int x = xOffset - 1; x <= xOffset + 1; x++)
            {
                for(int y = yOffset - 1; y <= yOffset + 1; y++)
                {
                    if (x > 0 && x < w && y > 0 && y < h)
                    {
                        if(x != xOffset || y != yOffset)
                            if (map[x, y])
                            {
                                neighbours++;
                            }
                    }   
                    else
                    {
                        neighbours++;
                    }
                }
            }
            return neighbours;
        }

		void InitMap(){
			for(int x = 0; x < w;x++){
				for(int y = 0; y < h;y++){
					map [x, y] = false;
				}
			}
		}
	}

	public class Tile{
		public Item itemContainer;
		public int x,y;
		public tileType tType;
		public Tile(int _x, int _y,tileType _tType){
			x = _x;
			y = _y;
			tType = _tType;
		}
	}

	public enum tileType{
		floor,
		wall,
		hole
	}

	struct Coords {
		public int x,y;
		public Coords(int _x, int _y){
			x = _x;	
			y = _y;
		}
	}
}

