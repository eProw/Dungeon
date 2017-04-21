using System;
using System.Collections.Generic;

namespace Dungeon
{
	public class MapGen:Game
	{
		Random rand;

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

		public MapGen (int _w, int _h, int seed)
		{
			rand = new Random (seed);
			_W = _w;
			_H = _h;
			map = new bool[_w,_h];

			Map = new Tile[_w,_h];
		}

		public void GenerateMap(){
			GenerateRandomMap ();
		}

		void GenerateRandomMap(){
			InitMap ();

			List<List<Coords>> rooms = new List<List<Coords>> ();
			int numOfRooms = rand.Next (4,8);

			for(int i =0; i < numOfRooms; i++){
				List<Coords> room = new List<Coords> ();
				int X = rand.Next (4, w - 4), maxX = rand.Next (4,10);
				int Y = rand.Next (4, h - 4), maxY = rand.Next (4,10);;

				for (int x = X;x < maxX;x++){
					for (int y = Y;y < maxY;y++){
						room.Add (new Coords (x, y));
					}
				}

				rooms.Add (room);
			}

			foreach (List<Coords> room in rooms) {
				foreach (Coords c in room) {
					map [c.x, c.y] = true;
				}
			}

			for(int x = 0; x < w;x++){
				for(int y = 0; y < h;y++){
					Map [x, y] = new Tile (x,y,map[x,y]?tileType.floor:tileType.wall);
				}
			}
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

