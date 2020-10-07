using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemUI : MonoBehaviour
{

	public ItemManager manager;
	public GameObject ItemAsset;

	public int ItemsPerRow = 5;
	public int Rows = 3;
	///TO DO: ROWS NUMBER
	public float ItemScale = 1.0f;
	public float ItemSpacing = 0.2f;

	private Image mainBorder;
	private Vector2 BorderSize;
	private Vector2 ItemSize = new Vector2(100.0f, 100.0f);
	private Vector2 SpaceSize;
	private float EdgeSize;

	private List<GameObject> ItemSprites;
	bool refreshed = false;

    void Start()
    {


        mainBorder = this.GetComponent<Image>();
       	SpaceSize = ItemSize * ItemSpacing;
       	EdgeSize = ItemSize.x + SpaceSize.x;

       	BorderSize = new Vector2(ItemsPerRow, Rows) * EdgeSize + SpaceSize + new Vector2(SpaceSize.x, SpaceSize.y * 2.0f);

       	mainBorder.rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, BorderSize.x);
       	mainBorder.rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, BorderSize.y);

       	//Debug.Log(mainBorder.rectTransform.position.ToString());

       	ItemSprites = new List<GameObject>();
    }

    void Update()
    {
    	if(!refreshed)
    	{
    		refreshed = true;
    		RefreshItems();
    	}
    }

    public void RefreshItems()
    {
    	ItemSprites.Clear();

    	Debug.Log("COUNT:" + manager.Inventory.Count);

    	for(int i=0;i<manager.Inventory.Count;i++)
    	{
    		GameObject newItem = Instantiate(ItemAsset) as GameObject;

    		newItem.transform.SetParent(this.transform);
    		RectTransform rt = newItem.GetComponent<RectTransform>();
    		rt.position = GetOffsetPosition(i);
    		//rt.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, ItemSize.x);
    		//rt.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, ItemSize.y);

    		Image img = newItem.transform.GetChild(1).GetComponent<Image>();
    		img.sprite = ItemAssets.Items.GetSprite(manager.Inventory[i].ItemId);
    	}

    }

    private Vector2 GetOffsetPosition(int Idx)
    {
    	Vector2 ScreenCenter = new Vector2(Screen.width, Screen.height) / 2.0f;
    	return ScreenCenter - (BorderSize / 2.0f) - (new Vector2(-ItemSize.x, ItemSize.y) / 2.0f) + (new Vector2(SpaceSize.x * 1.5f, SpaceSize.y)) + GetPosition(Idx);
    }

    private Vector2 GetPosition(int Idx)
    {
    	int x = Idx % ItemsPerRow;
    	int y = Rows - Idx / ItemsPerRow;

    	return (new Vector2(x, y) * EdgeSize);
    }
}
