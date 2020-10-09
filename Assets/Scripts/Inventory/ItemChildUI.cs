using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class ItemChildUI : MonoBehaviour
{
	//public UnityEvent EventHandler;
	private Image border;
	private Color original_color;
	private Color hover_color;

    void Start()
    {
        border = transform.GetChild(0).GetComponent<Image>();
        original_color = border.color;
        hover_color = original_color;
        hover_color.a = 0.5f;
    }

    void Update()
    {
        
    }

    public void Hover()
    {
    	//Debug.Log("ITEM");
        border.color = hover_color;
    }

    public void Exit()
    {
        border.color = original_color;
    }
}


