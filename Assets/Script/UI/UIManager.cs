using System.Collections;
using System.Collections.Generic;
using Inventory.UI;
using Inventory.Model;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] public GameObject[] subMenuBtn;
    [SerializeField] private InventorySO inventorySO;
    [SerializeField] public GameObject UIInventoryPage;

    private int AcceptItemNum;  // 아이템UI의 순번 받아오는 변수
    private UIInventoryPage ItemSlotNum;  // 인벤토리에서 클릭한 아이템 순번 변수

    private void Start()
    {
        ItemSlotNum = UIInventoryPage.GetComponent<UIInventoryPage>();
    }

    private void Update()
    {
        AcceptItem();
    }
    public void OnInvenBtn()
    {
        Debug.Log("인벤토리 열기");
        subMenuBtn[0].SetActive(true);

        subMenuBtn[1].SetActive(false);
        //subMenuBtn[2].SetActive(false);

    }

    public void OnBlessBtn()
    {
        Debug.Log("축복 열기");
        subMenuBtn[1].SetActive(true);
        subMenuBtn[0].SetActive(false);
        //subMenuBtn[2].SetActive(false);
    }


    private void AcceptItem()
    {
        if (ItemSlotNum != null)
        {
            AcceptItemNum = ItemSlotNum.selectItemSlotNum;  // 클릭한 아이템 순번 가져옴
        }

    }

    public void Dropitem(int index)     // 인벤토리에서 아이템 버리기 요청
    {
        index = AcceptItemNum;
        InventoryItem inventoryItem = inventorySO.GetItemAt(index); // index부분을 아이템 번호가 올수 있도록
        if (inventoryItem.IsEmpty)
        {
            return;
        }

        IDestroyableItem destroyableItem = inventoryItem.item as IDestroyableItem;  // 음식 아이템 사용시
        if (destroyableItem != null)
        {
            inventorySO.DumpItem(index, 1);   // 해당 번호 아이템갯수 1개 감소
            Debug.Log("임시 버리기");
        }
    }

    public void UseItem(int index)  // 인벤토리에서 아이템 사용 요청
    {
        index = AcceptItemNum;
        InventoryItem inventoryItem = inventorySO.GetItemAt(index);
        if (inventoryItem.IsEmpty)
        {
            return;
        }

        IDestroyableItem destroyableItem = inventoryItem.item as IDestroyableItem;  // 아이템 사용시
        if (destroyableItem != null)
        {
            inventorySO.RemoveItem(index, 1);   // 해당 번호 아이템갯수 1개 감소
            Debug.Log("01: 아이템사용");
        }

        IItemAction itemAction = inventoryItem.item as IItemAction;
        if (itemAction != null)
        {
            itemAction.PerformAction(gameObject, inventoryItem.itemState);  // 해당 값만큼 사용


            Debug.Log($"{inventoryItem.itemState} 만큼 사용");
        }
    }
}
