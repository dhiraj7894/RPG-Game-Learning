using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    #region Singleton
    public static Inventory instance;

    private void Awake()
    {
        if(instance != null)
        {
            Debug.Log("More than one instance of inventory found!");
            return;
        }
            instance = this;
    }
    #endregion

    public delegate void onIntemChanged();
    public onIntemChanged onIntemChangedCallback;

    public int space = 20;
    public List<Item> items = new List<Item>();
    public bool Add(Item item)
    {
        if (!item.isDefaultItem)
        {
            if(items.Count >= space)
            {
                Debug.Log("Not enough space");
                return false;
            }
            items.Add(item);

            if(onIntemChangedCallback !=null)
                onIntemChangedCallback.Invoke();
        }
        return true;
    }

    public void onRemove(Item item)
    {
        items.Remove(item);
    }
}
