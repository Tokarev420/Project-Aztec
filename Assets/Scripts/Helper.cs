using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;
using System.Runtime.Serialization.Formatters;

public class Helper : MonoBehaviour
{
    
    void Start()
    {
        /*Item battery = new Item(0, "Battery", false);

        Stack b1 = new Stack(0, 1);
        Stack b2 = new Stack(0, 10);



        Item laptop = new Item(1, "Laptop", true);
        laptop.divisibles.Add(b1);
        laptop.divisibles.Add(b2);

        Debug.Log(laptop.divisibles[0].ItemId);
        
        List<Item> items = new List<Item>();
        items.Add(battery);
        items.Add(laptop);

        string path = Application.persistentDataPath + "/save.json";
        File.WriteAllLines(path, Util.GetStringList(items));*/
    }

    void Update()
    {
        
    }
}
