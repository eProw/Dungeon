using System;

namespace Dungeon
{
	public class Player
	{
		int _health;
		public int maxHealth, gold,defense;
		public string name;

		public int x, y;

		public Item[] inventory;

		public const int inventorySize = 10;

		public int Health{ 
			get{ 
				return _health;
			}
			set{
				if (value < 0)
					_health = 0;
				if (value > maxHealth)
					_health = maxHealth; 
			}
		}

		public Player (int _maxHealth, int _gold, string _name,Item[] _inventory,int _x, int _y)
		{
			maxHealth = _maxHealth;
			Health = maxHealth;
			gold = _gold;
			name = _name;
			x = _x;
			y = _y;
			inventory = _inventory;
		}
	}
}

