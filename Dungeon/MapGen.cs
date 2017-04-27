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

        public List<Coord> region;

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

        public MapGen(int _w, int _h, int perc)
        {
            rand = new Random();
            _W = _w;
            _H = _h;
            map = new bool[_w, _h];

            Map = new Tile[_w, _h];
            fillPerc = perc;
            GenerateMap();
        }

        public void GenerateMap(){
			GenerateRandomMap ();
            for(int i = 0; i < 3; i++)
            SmoothMap();
            AddMisc();

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

        void AddMisc()
        {

           List<List<Coord>> regions = GetRegions();

            int bestId = 0, maxCount = 0;

            for (int i = 0; i < regions.Count; i++)
            {
                if (regions[i].Count > maxCount)
                {
                    maxCount = regions[i].Count;
                    bestId = i;
                }
            }

            region = regions[bestId];
            for (int x = 0; x < w; x++)
                for (int y = 0; y < h; y++)
                {
                    map[x, y] = true;
                }

            foreach (Coord c in region)
            {
                map[c.x, c.y] = false;
            }

            for (int x = 0; x < w; x++)
            {
                for (int y = 0; y < h; y++)
                {
                    Map[x, y] = new Tile(x, y, map[x, y] ? tileType.wall : tileType.floor);
                }
            }

            for (int x = 0; x < w; x++)
                for (int y = 0; y < h; y++)
                {
                    if (Map[x,y].tType == tileType.floor)
                    {
                        tileType t = tileType.floor;

                        int num = rand.Next(100);

                        //Colocar diversos tiles en el mapa
                        if(num == 1)
                        {
                            t = tileType.grass;
                        }else if(num == 3)
                        {

                        }

                        Map[x, y].tType = t;
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

        List<Coord> GetRegionTiles(int startX, int startY)
        {
            List<Coord> tiles = new List<Coord>();
            int[,] mapFlags = new int[w, h];

            Queue<Coord> queue = new Queue<Coord>();
            queue.Enqueue(new Coord(startX, startY));
            mapFlags[startX, startY] = 1;

            while (queue.Count > 0)
            {
                Coord tile = queue.Dequeue();
                tiles.Add(tile);

                for (int x = tile.x - 1; x <= tile.x + 1; x++)
                {
                    for (int y = tile.y - 1; y <= tile.y + 1; y++)
                    {
                        if ((x>=0 && x < w && y >=0 && y<h)&& (y == tile.y || x == tile.x))
                        {
                            if (mapFlags[x, y] == 0 && !map[x, y])
                            {
                                mapFlags[x, y] = 1;
                                queue.Enqueue(new Coord(x, y));
                            }
                        }
                    }
                }
            }
            return tiles;
        }

        List<List<Coord>> GetRegions()
        {
            List<List<Coord>> regions = new List<List<Coord>>();
            int[,] mapFlags = new int[w, h];

            for (int x = 0; x < w; x++)
            {
                for (int y = 0; y < h; y++)
                {
                    if (mapFlags[x, y] == 0 && !map[x, y])
                    {
                        List<Coord> newRegion = GetRegionTiles(x, y);
                        regions.Add(newRegion);

                        foreach (Coord tile in newRegion)
                        {
                            mapFlags[tile.x, tile.y] = 1;
                        }
                    }
                }
            }

            return regions;
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
		hole,
        grass
	}

	public struct Coord {
		public int x,y;
		public Coord(int _x, int _y){
			x = _x;	
			y = _y;
		}
	}
}

