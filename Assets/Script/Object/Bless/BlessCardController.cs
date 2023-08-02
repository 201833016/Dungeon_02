using System.Collections;
using System.Collections.Generic;
using Inventory;
using UnityEngine;

public class BlessCardController : MonoBehaviour
{
    public BlessCardPage bCardUI;   // 축복 카드 메뉴

    [SerializeField] private BlessCardInven cardData;   // 축복 카드 인벤토리 정보
    [SerializeField] private InventoryController inventoryController;   // 메누에서 아이템 인벤을 닫기 위한 

    private void Start()
    {
        PrepareCardUI();
        //cardData.InitializeCard();
    }

    private void PrepareCardUI()    // 시작시 카드 인벤 칸 생성
    {
        bCardUI.InitializeBlessCardUI(cardData.invenCards.Count);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            OnOffCardMenu();
        }
    }

    public void OnOffCardMenu() // 축복 카드 인벤토리 열기, 닫기
    {
        if (bCardUI.isActiveAndEnabled == false)
        {
            bCardUI.Show();
            inventoryController.invenUI.Hide(); // 아이템 인벤토리 안보이게
            foreach (var card in cardData.GetCurrentBlessCardState())
            {
                bCardUI.UpdateCardData(card.Key, card.Value.card.cardImage, card.Value.card.cardName, card.Value.card.cardDescription);
                
            }
        }
        else
        {
            bCardUI.Hide();
        }
    }
}
