using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Activator : MonoBehaviour
{
	public GameObject[] obj;
    public bool disableInitially = false;
    // Start is called before the first frame update
    void Start()
    {
        if(disableInitially)
            disable();
    }

    public void disable()
    {
        for(int i=0;i<obj.Length;i++)
        {
                obj[i].SetActive(false);
        }
    }

    public void enable()
    {
        for(int i=0;i<obj.Length;i++)
        {
                obj[i].SetActive(true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Tab))
        {
        	for(int i=0;i<obj.Length;i++)
        	{
        		obj[i].SetActive(!obj[i].activeSelf);
        	}
        }
    }
}
