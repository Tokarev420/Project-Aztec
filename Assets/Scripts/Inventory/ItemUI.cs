using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemUI : MonoBehaviour
{
	////TO DO: DESTROY ITEMS BEFORE CLEARING LIST
	////TO DO: UPDATE SIZES WHEN CHANGING RESOLUTION
	public ItemManager manager;
	public GameObject ItemAsset;
	public GameObject ActiveBar;
	public Activator activator;

	public int ItemsPerRow = 5;
	public int Rows = 3;
	///TO DO: ROWS NUMBER
	public float ItemScale = 1.0f;
	public float ActiveItemRatio = 0.1f;
	public float ItemSpacing = 0.2f;
	public float yOffsetRatio = 0.0f;

	private Image mainBorder;
	private Image activeBorder;
	private Vector2 BorderSize;
	private Vector2 ActiveBorderSize;
	private Vector2 ItemSize = new Vector2(100.0f, 100.0f);
	private Vector2 SpaceSize;
	private float EdgeSize;
	private float yOffset;
	private float ActiveItemScale = 1.0f;

	private List<GameObject> ItemSprites;
	private List<GameObject> ActiveItemSprites;
	public List<int> ActiveItemIds;
	bool refreshed = false;

    void Start()
    {
        mainBorder = this.GetComponent<Image>();
        activeBorder = ActiveBar.GetComponent<Image>();

        ItemSize = ItemSize * ItemScale;
       	SpaceSize = ItemSize * ItemSpacing;
       	EdgeSize = ItemSize.x + SpaceSize.x;
       	yOffset = yOffsetRatio * Screen.width * ItemScale;

       	ActiveItemScale = (Screen.height * ActiveItemRatio) / ItemSize.y;

       	BorderSize = new Vector2(ItemsPerRow, Rows) * EdgeSize + SpaceSize + new Vector2(SpaceSize.x, SpaceSize.y);

       	mainBorder.rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, BorderSize.x);
       	mainBorder.rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, BorderSize.y);
       	OffsetY(mainBorder.rectTransform);

       	ItemSprites = new List<GameObject>();
       	ActiveItemSprites = new List<GameObject>();
       	ActiveItemIds = new List<int>();
    }

    void Update()
    {
    	if(!refreshed)
    	{
    		refreshed = true;
    		RefreshItems();
    		activator.disable();
    	}
    }

    public void RefreshItems()
    {
    	ItemSprites.Clear();
    	ActiveItemIds.Clear();
    	//ActiveItemSprites.Clear();

    	Debug.Log("COUNT:" + manager.Inventory.Count);

    	int filledItems = 0;

    	for(int i=0;i<manager.Inventory.Count;i++)
    	{
    		int offsetNum = 0;
    		if(manager.GetInventoryItem(i).type > 0)
    		{
    			//Daca sunt mai multe iteme ACTIVE scazi 1 si raman celelalte
    			if(manager.Inventory[i].Num > 1)
    				offsetNum = 1;
    			else
    			{
    				ActiveItemIds.Add(i);
    				continue;
    			}
    		}
    		GameObject newItem = Instantiate(ItemAsset) as GameObject;
    		newItem.transform.SetParent(this.transform);
    		RectTransform rt = newItem.GetComponent<RectTransform>();
    		rt.position = GetOffsetPosition(filledItems);
    		rt.localScale = Vector3.one * ItemScale;
    		OffsetY(rt);

    		Image img = newItem.transform.GetChild(1).GetComponent<Image>();
    		img.sprite = ItemAssets.Items.GetSprite(manager.Inventory[i].ItemId);

    		ItemSprites.Add(newItem);
    		ResetCounter(i, manager.Inventory[i].Num - offsetNum);

    		filledItems++;
    	}	

    	RefreshActiveItems();
    }

    public void RefreshActiveItems()
    {
    	if(ActiveItemIds.Count < 1)
    	{
    		ActiveBar.SetActive(false);
    		return;
    	}
    	else
    	{
    		ActiveBar.SetActive(true);
    	}

    	Debug.Log(ActiveItemScale);

		ActiveBorderSize = new Vector2(ActiveItemIds.Count, 1) * EdgeSize + SpaceSize + new Vector2(SpaceSize.x, SpaceSize.y);
		ActiveBorderSize = ActiveBorderSize * ActiveItemScale;

       	activeBorder.rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, ActiveBorderSize.x);
       	activeBorder.rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, ActiveBorderSize.y);    
       	activeBorder.rectTransform.anchoredPosition = new Vector2(0, ActiveBorderSize.y / 1.75f);    

       	for(int i=0;i<ActiveItemIds.Count;i++)
    	{
    		GameObject newItem = Instantiate(ItemAsset) as GameObject;
    		newItem.transform.SetParent(ActiveBar.transform);
    		RectTransform rt = newItem.GetComponent<RectTransform>();
    		rt.position = GetActiveOffsetPosition(i);
    		rt.localScale = Vector3.one * ActiveItemScale;
    		
    		Image img = newItem.transform.GetChild(1).GetComponent<Image>();
    		img.sprite = ItemAssets.Items.GetSprite(manager.Inventory[ActiveItemIds[i]].ItemId);

    		ActiveItemSprites.Add(newItem);
    		DisableCounter(i);
    	}
    }

    public void OffsetY(RectTransform rt)
    {
    	rt.anchoredPosition = rt.anchoredPosition + new Vector2(0, yOffset);
    }

    public void ResetCounter(int idx, int num)
    {
    	Text txt = ItemSprites[idx].transform.GetChild(2).GetComponent<Text>();
    	txt.text = "" + num;
    }

    public void DisableCounter(int idx)
    {
    	Text txt = ActiveItemSprites[idx].transform.GetChild(2).GetComponent<Text>();
    	txt.text = "";
    }

    private Vector2 GetOffsetPosition(int Idx)
    {
    	Vector2 ScreenCenter = new Vector2(Screen.width, Screen.height) / 2.0f;
    	return ScreenCenter - (BorderSize / 2.0f) - (new Vector2(-ItemSize.x, ItemSize.y) / 2.0f) + (new Vector2(SpaceSize.x * 1.5f, SpaceSize.y * 0.5f)) + GetPosition(Idx);
    }

    private Vector2 GetActiveOffsetPosition(int Idx)
    {
    	Vector2 StartingPos = new Vector2(Screen.width / 2.0f, ActiveBorderSize.y / 1.75f);
    	StartingPos -= new Vector2(ActiveItemIds.Count * EdgeSize / 2.0f, 0.0f) * ActiveItemScale;
    	return StartingPos + (new Vector2(Idx * EdgeSize + (ItemSize.x / 2.0f) + (SpaceSize.x * 0.5f), 0.0f) * ActiveItemScale);
    }

    private Vector2 GetPosition(int Idx)
    {
    	int x = Idx % ItemsPerRow;
    	int y = Rows - Idx / ItemsPerRow;

    	return (new Vector2(x, y) * EdgeSize);
    }
}
