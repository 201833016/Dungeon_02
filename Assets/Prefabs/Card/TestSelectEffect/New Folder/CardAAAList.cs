using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class CardAAAList
{
    public CardAAA card;
    public string name;
    public int stacks;

    public CardAAAList(CardAAA newCard, string newName, int newStacks)
    {
        card = newCard;
        name = newName;
        stacks = newStacks;
    }
}
