using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Item_Script : MonoBehaviour
{
    public Item itemObject;
    public Item heldProperties;

    public TMP_Text itemName;
    public RawImage itemTexture;
    public TMP_Text item_amount;
    public void SetCurrentItem(Item item)
    {
        if (heldProperties == null)
        {
            SetHeldProperties(item);
        }

        itemName.text = heldProperties.name;
        itemTexture.texture = heldProperties.itemTexture;
        item_amount.text = heldProperties.currentAmount.ToString(); ;
    }

    public void SetHeldProperties(Item item)
    {
        heldProperties = ScriptableObject.CreateInstance<Item>();
        heldProperties.itemName = item.itemName;
        heldProperties.itemTexture = item.itemTexture;
        heldProperties.currentAmount = item.currentAmount;
        heldProperties.maxStackAmount = item.maxStackAmount;
    }

}
