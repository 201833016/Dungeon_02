using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slime : MonoBehaviour
{
    public SOMonster soMonster; // 몬스터 정보
    public int level;   // 스테이지 레벨
    [HideInInspector] public int  currentHP, maxHP;    // 몬스터 현재, 최대 체력
    [HideInInspector] public int DMG;   // 몬스터 공격력
    float attackDelay;  // 몬스터 공격 속도

    private void Start() 
    {
        maxHP = level * soMonster.CON;    // 몬스터 최대 체력 = 레벨 X 생명력 계수
        DMG = level * soMonster.STR;   // 몬스터 공격력 = 레벨 X 공격력 계수
        attackDelay = 1f / ((soMonster.AGI + 1) * 0.5f);    // 몬스터 공격 속도 = 1 / ((속도 계수 + 1) * 1/2);

        currentHP = maxHP;  // 시작시 현재 HP는 최대 HP롸 같게
    }

    public int GetHit(int damage)   // 몬스터 피격시
    {
        currentHP -= damage;
        if(currentHP <= 0)
        {
            soMonster.itemDropTable.ItemDrop(transform.position);   // 몬스터 죽은 위치에 아이템 드랍
        }

        return currentHP;
    }
}
