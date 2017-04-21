using System;

namespace Dungeon
{
	interface IItem{
		void Sell();
		void Use();
	}

	class itemType{

	}

	class Weapon:itemType,IItem{

	}

	class Potion:itemType,IItem{

	}

	class Armor:itemType,IItem{

	}

	class Scroll:itemType{

	}
}

