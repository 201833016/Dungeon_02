using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Inventory.Model;

public class PickUp : MonoBehaviour
{
    [SerializeField] private InventorySO invenSO;   // 인벤토리 

    private void OnTriggerEnter2D(Collider2D other) // 아이템과 접촉시
    {
        Item item = other.GetComponent<Item>(); 
        if(item != null)
        {
            Debug.Log($"1. 종류 : {item.invenItem.item_type}");
            int reminder = invenSO.AddItem(item.invenItem, item.Quantity);  // 인벤토리에 접촉한 아이템 갯수만큼 넣기
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
