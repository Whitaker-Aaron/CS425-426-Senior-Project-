using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public GameObject currentInHand;
    public Transform cellParent;
    public Vector3 offset;
    public bool open = false;
    public GameObject Menu;

    public Item itemToRemove;
    public int amountToRemove;
    public int amountToAdd;
    public GameObject itemToAdd;

    private void Start()
    {
        SetList();
    }

    private void Update()
    {
        OpenClose();
        MoveItemInHand();

        if (Input.GetKeyDown(KeyCode.B))
        {
            if ((Inventory.instance.GetItemCount(itemToRemove) - amountToRemove) >= 0)
            {
                Inventory.instance.RemoveItem(itemToRemove, amountToRemove);
            }
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            Inventory.instance.AddItem(itemToAdd, amountToAdd);
        }
    }

    public void SetList()
    {
        int index = 0;

        foreach (Transform cell in cellParent)
        {
            if (cell.childCount > 0)
            {
                foreach (Transform child in cell)
                {
                    Destroy(child.gameObject);
                }
            }

            if (Inventory.instance.inventoryItems[index] != null)
            {
                if (Inventory.instance.inventoryItems[index].GetComponent<Item_Script>().heldProperties != null)
                {
                    cell.GetComponent<CellScript>().CreateItemInCell(Inventory.instance.inventoryItems[index].GetComponent<Item_Script>().heldProperties);
                }
                else
                {
                    cell.GetComponent<CellScript>().CreateItemInCell(Inventory.instance.inventoryItems[index].GetComponent<Item_Script>().itemObject);
                }

                Inventory.instance.inventoryItems[index] = cell.GetComponent<CellScript>().currentHeldItem;
            }
            cell.GetComponent<CellScript>().cellIndex = index;
            index++;
        }
    }
    void OpenClose()
    {
        if (Input.GetKeyUp(KeyCode.E))
        {
            open = !open;
            Menu.SetActive(open);
        }
    }
    void MoveItemInHand()
    {
        if (currentInHand == null)
        {
            return;
        }
                
        currentInHand.transform.parent = transform;
        currentInHand.transform.localScale = new Vector3(0.6f, 0.6f, 0.6f);
        Vector3 pos = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0f) + offset;
        currentInHand.transform.position = pos;
    }
}
