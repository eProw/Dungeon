using System;

namespace Dungeon
{
	public class Item{
		public string name, description;
		public int value;
		public bool itemCarried;
		public bool carriable;

		public Item(string _name, string _descr,int _value, bool _itCarried,bool _carriable){
			name = _name;
			description = _descr;
			value = _value;
			itemCarried = _itCarried;
			carriable = _carriable;
		}

		public Item(){

		}

		void Drop(){
			itemCarried = false;
		}

		void Carry(){
			itemCarried = true;
		}

		public virtual void Use(){
			
		}
	}

	class Weapon:Item{
		public char graphic;
		public bool usesAmmo;
		public weaponType wType;

		public int damage;

		public Weapon(string _name, string _descr,int _value, bool _itCarried,bool _carriable,bool _usesAmmo,weaponType _wType,int _damage)
			:base(_name,_descr,_value,_itCarried,_carriable){
			usesAmmo = _usesAmmo;
			wType = _wType;
			damage = _damage;
			graphic = wType == weaponType.dist?(char)(402):(char)(8225);
		}
		public override void Use ()
		{
			Damage ();
		}

		void Damage(){

		}

		public enum weaponType{
			dist,
			melee
		}
	}

	class Potion:Item{
		public Potion(string _name, string _descr,int _value, bool _itCarried,bool _carriable)
			:base(_name,_descr,_value,_itCarried,_carriable){

		}

		public override void Use ()
		{
			Drink ();
		}

		void Drink(){

		}
	}

	class Armor:Item{
		public Armor(string _name, string _descr,int _value, bool _itCarried,bool _carriable)
			:base(_name,_descr,_value,_itCarried,_carriable){

		}

		public void Equip(){

		}
	}

	class Scroll:Item{
		public Scroll(string _name, string _descr,int _value, bool _itCarried,bool _carriable)
			:base(_name,_descr,_value,_itCarried,_carriable){

		}

		public override void Use ()
		{
			Speech ();
		}

		void Speech(){

		}
	}

	class Money:Item{

	}

	class Ammo:Item{

	}

	class Food:Item{
		public Food(string _name, string _descr,int _value, bool _itCarried,bool _carriable, int healthPoints)
			:base(_name,_descr,_value,_itCarried,_carriable){

		}

		public override void Use ()
		{
			Eat ();
		}

		void Eat(){

		}
	}
}

