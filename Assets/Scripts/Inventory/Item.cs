using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Runtime.Serialization.Formatters;



[Serializable]
public struct Stack 	
{
	public int ItemId;
	public int Num;

	public Stack(int i, int n)
	{
		ItemId = i;
		Num = n;
	}

}


/// TYPE 0 - Uncraftable
/// TYPE 1 - Tool
/// TYPE 2 - Weapon

[Serializable]
public class Item
{
	public int id;
	public int type = 0;
	public bool divisible = true;
	public List<Stack> divisibles;
	public string name;
	public string description;

	public Item(int _id, string _name = "DefaultItem", bool _divisible = true)
	{
		 id = _id;
		 name = _name;
		 type = 0;
		 divisible = _divisible;
		 divisibles = new List<Stack>();
	}
}
