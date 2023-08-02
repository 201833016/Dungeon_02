using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Inventory.Model;

public class PickUp : MonoBehaviour
{
    [SerializeField] private InventorySO invenSO;

    private void OnTriggerEnter2D(Collider2D other) 
    {
        Item item = other.GetComponent<Item>();
        if(item != null)
        {
            int reminder = invenSO.AddItem(item.invenItem, item.Quantity);
            if(reminder == 0)
            {
                item.DestroyItem();
            }
            else
            {
                item.Quantity = reminder;
            }
        }    
    }
}
