using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;
using System.Runtime.Serialization.Formatters;

public static class Util
{
    public static List<Item> GetItemList(string[] str)
    {
    	List<Item> items = new List<Item>();

    	for(int i=0;i<str.Length;i++)
    	{
    		Item itm = JsonUtility.FromJson<Item>(str[i]);
    		items.Add(itm);
    	}

    	return items;
    }

    public static string[] GetStringList(List<Item> items)
    {
    	string[] str = new string[items.Count];
    	for(int i=0;i<items.Count;i++)
    	{
    		str[i] = JsonUtility.ToJson(items[i]);
    	}
    	return str;
    }
}
