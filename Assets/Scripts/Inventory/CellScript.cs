using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CellScript : MonoBehaviour
{
    public int cellIndex;
    public InventoryManager inventoryManager;
    public GameObject BasicItemPrefab;
    public GameObject currentHeldItem;

    public void CreateItemInCell(Item item)
    {
        if (transform.childCount > 0)
        {
            Destroy(transform.GetChild(0).gameObject);
        }
        currentHeldItem = Instantiate(BasicItemPrefab, transform.position, transform.rotation, transform);
        currentHeldItem.GetComponent<Item_Script>().SetCurrentItem(item);
    }

   
    public void OnClick()
    {
        bool addedItem = false;

        if (currentHeldItem != null && inventoryManager.currentInHand != null)
        {
            Item inventoryManagerItem = inventoryManager.currentInHand.GetComponent<Item_Script>().heldProperties;
            Item cellItem = currentHeldItem.GetComponent<Item_Script>().heldProperties;

            if (cellItem.currentAmount < cellItem.maxStackAmount && cellItem.itemName == inventoryManagerItem.itemName)
            {
                int difference = cellItem.maxStackAmount - cellItem.currentAmount;
                if (difference >= inventoryManagerItem.currentAmount)
                {
                    cellItem.currentAmount += inventoryManagerItem.currentAmount;
                    Destroy(inventoryManager.currentInHand);
                    inventoryManager.currentInHand = null;
                }
                else
                {
                    cellItem.currentAmount += difference;
                    inventoryManagerItem.currentAmount -= difference;
                }

                if (inventoryManager.currentInHand != null)
                {
                    inventoryManager.currentInHand.GetComponent<Item_Script>().SetCurrentItem(null);
                }
                currentHeldItem.GetComponent<Item_Script>().SetCurrentItem(null);
                addedItem = true;
            }
        }

        if (!addedItem)
        {
            GameObject provisionalCellItemHolder = currentHeldItem;
            if (inventoryManager.currentInHand != null)
            {
                currentHeldItem = inventoryManager.currentInHand.gameObject;
            }
            else
            {
                currentHeldItem = null;
            }
            inventoryManager.currentInHand = provisionalCellItemHolder;
        }

        if (currentHeldItem != null)
        {
            currentHeldItem.transform.parent = transform;
            currentHeldItem.transform.position = transform.position;
            currentHeldItem.transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);

            Inventory.instance.inventoryItems[cellIndex] = currentHeldItem;
        }
        else
        {
            Inventory.instance.inventoryItems[cellIndex] = null;
        }
    }

}