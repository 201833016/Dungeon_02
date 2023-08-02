using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "MaxHP Increase", menuName = "Bless Card/Player Stat/Max HP")]
public class CardStatMaxIncreaseSO : CardStatModifierSO
{
    public override void AffectCharater(Player player, float val)   // 효과 추상 클래스 오버라이드
    {
        if(player != null)
        {
            player.maxHealth += val;
            Debug.Log($"[{val}] 만큼 최대 체력 증가");
        }
    }
}
