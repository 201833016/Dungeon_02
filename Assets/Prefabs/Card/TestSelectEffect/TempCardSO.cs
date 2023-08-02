using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Card Data", menuName = "Bless Card/Card Data")]
public class TempCardSO : CardSO, ICardAction
{
    [SerializeField] private List<CardModifierData> cardModiData = new List<CardModifierData>();

    public string ActionName => "Consume";

    public bool PerformAction(Player player)
    {
        foreach (CardModifierData data in cardModiData)
        {
            data.cardModifier.AffectCharater(player, data.value);   // 해당 SO내의 효과 발동
        }
        return true;
    }
}

public interface ICardAction    // 효과 발동시 
{
    public string ActionName { get;}
    bool PerformAction(Player player);
}

[Serializable]
public class CardModifierData
{
    public CardStatModifierSO cardModifier; // 효과 대상
    public float value;     // 효과 수치
}