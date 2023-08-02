using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public abstract class CardAAA
{
    public abstract string GiveName();
    public virtual void maxHPPlus(Player player, int stacks)
    {

    }
    /*
    public virtual void OnHit(Player player, Enemy enemy, int stacks)
    {

    }*/
}

public class MaxHealthIncrease : CardAAA
{
    public override string GiveName()
    {
        return "HP 증가 카드";
    }
        public override void maxHPPlus(Player player, int stacks)
    {
        player.maxHealth += 3 + (2 * stacks);   // 그냥 공식이 아닌 숫자로 해도 됨
    }
}

public class FireDamageCard : CardAAA
{
    public override string GiveName()
    {
        return "화상 피해 카드";
    }
    /*
    public override void OnHit(Player player, Enemy enemy, int stacks)
    {
        player.currnetHeath -= 1 * (stacks);   // 그냥 공식이 아닌 숫자로 해도 됨
    }*/
}

public class Dammit : CardAAA
{
    public override string GiveName()
    {
        return "젠장";
    }


}