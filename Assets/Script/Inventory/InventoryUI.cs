using UnityEngine;

public class InventoryUI : MonoBehaviour
{
    public Transform itemsParents;
    InventorySlots[] slots;

    public GameObject inventoryUI;

    Inventory inventory;
    // Start is called before the first frame update
    void Start()
    {
        inventory = Inventory.instance;
        inventory.onIntemChangedCallback += UpdateUI;

        slots = itemsParents.GetComponentsInChildren<InventorySlots>();
    }

    // Update is called once per frame
    void Update()
    {
        UpdateUI();
        if (Input.GetButtonDown("Inventory"))
        {
            inventoryUI.SetActive(!inventoryUI.activeSelf);
        }
    }

    public void UpdateUI()
    {
        for(int i = 0;i < slots.Length; i++)
        {
            if (i < inventory.items.Count)
            {
                slots[i].AddItem(inventory.items[i]);
            }
            else
            {
                slots[i].ClearSlot();
            }
        }
    }
}
