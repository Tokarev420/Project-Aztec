using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Terrain : MonoBehaviour
{
    

	public Color color;
	public float scale = 1.0f;
	public Vector2 size;
	public Vector2 spriteSize;
	public Sprite[] sprites;
	private List<GameObject> objects;


    void Start()
    {
        objects = new List<GameObject>();

        Vector2 posOffset = size / 2;
        Vector2 _spriteSize = spriteSize * scale;

        for(int i=0;i<size.x;i++)
        {
        	for(int j=0;j<size.y;j++)
	        {
	        	GameObject obj = new GameObject();
	        	Quaternion rotationQuaternion = Quaternion.identity;
	        	rotationQuaternion.eulerAngles = new Vector3(0, 0, Random.Range(0,4) * 90);

	        	obj.transform.position = new Vector3((i - posOffset.x) * _spriteSize.x, (j - posOffset.y) * _spriteSize.y, 0);
	        	obj.transform.rotation = rotationQuaternion;
	        	obj.transform.localScale = new Vector3(scale, scale, scale);
	        	obj.transform.parent = this.transform;

	        	SpriteRenderer rend = obj.AddComponent(typeof(SpriteRenderer)) as SpriteRenderer;
         		rend.sprite = sprites[Random.Range(0, sprites.Length)];
         		rend.color = color;
	        }
        }

    }

    
    void Update()
    {
        
    }
}
