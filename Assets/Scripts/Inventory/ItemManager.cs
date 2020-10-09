using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemManager : MonoBehaviour
{

	public TextAsset ItemsJson;
	public bool LoadFromJson = true;
	public int GiveItems = 0;
	public static ItemManager Instance {get; private set;}

	List<Item> Items;
	public List<Stack> Inventory;
    
    void Start()
    {
        Instance = this;
        Items = new List<Item>();
        string[] lines = ItemsJson.text.Split('\n');
        Items = Util.GetItemList(lines);
        Debug.Log("Loaded " + Items.Count + " items");

        Inventory = new List<Stack>();

        if(GiveItems > 0)
        {
        	for(int i=0;i<Items.Count;i++)
        	{
        		Inventory.Add(new Stack(Items[i].id, GiveItems));
        	}
        }
    }

    public Item GetInventoryItem(int idx)
    {
        return Items[Inventory[idx].ItemId];
    }

    void Update()
    {
        
    }
}
