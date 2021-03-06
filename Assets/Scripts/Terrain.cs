﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Terrain : MonoBehaviour
{
    

	public Color color;
	public float scale = 1.0f;
	public float fill = 1.0f;
	public Vector2 size;
	public Vector2 spriteSize;
	public Sprite[] sprites;
	public Sprite[] normals;
	private List<GameObject> objects;
	public Material material;
	public bool EnableLights = true;


    void Start()
    {
        objects = new List<GameObject>();

        Vector2 posOffset = size / 2;
        Vector2 _spriteSize = spriteSize * scale;

        for(int i=0;i<size.x;i++)
        {
        	for(int j=0;j<size.y;j++)
	        {
	        	if(Random.value > fill) continue;

	        	GameObject obj = new GameObject();
	        	Quaternion rotationQuaternion = Quaternion.identity;
	        	rotationQuaternion.eulerAngles = new Vector3(0, 0, Random.Range(0,4) * 90);

	        	obj.transform.position = new Vector3((i - posOffset.x) * _spriteSize.x, (j - posOffset.y) * _spriteSize.y, 0);
	        	obj.transform.rotation = rotationQuaternion;
	        	obj.transform.localScale = new Vector3(scale, scale, scale);
	        	obj.transform.parent = this.transform;

	        	SpriteRenderer rend = obj.AddComponent(typeof(SpriteRenderer)) as SpriteRenderer;
	        	rend.sortingLayerName = "Terrain";
         		rend.sprite = sprites[Random.Range(0, sprites.Length)];
         		rend.color = color;

         		//if(EnableLights)
         		//	rend.material.CopyPropertiesFromMaterial(material);    
         		//rend.material.SetTexture("_NormalMap", UtilSprites.TextureFromSprite(rend.sprite));

         		objects.Add(obj);
	        }
        }

    }

    
    void Update()
    {
        
    }
}
