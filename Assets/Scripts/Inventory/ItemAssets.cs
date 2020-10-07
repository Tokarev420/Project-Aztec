using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ItemAssets : MonoBehaviour
{
    public static ItemAssets Items {get; private set;}
    public Sprite[] sprites;

    private void Awake()
    {
    	Items = this;
    }


    public Sprite GetSprite(int id)
    {
    	return sprites[id];
    }

    public Sprite GetSprite(Item it)
    {
    	return sprites[it.id];
    }
}
