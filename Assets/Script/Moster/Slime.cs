using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slime : MonoBehaviour
{
    public SOMonster soMonster;
    public int level;
    [HideInInspector] public int HP;
    [HideInInspector] public int DMG;
    float attackDelay;

    private void Start() 
    {
        HP = level * soMonster.CON;
        DMG = level * soMonster.STR;    
        attackDelay = 1f / ((soMonster.AGI + 1) * 0.5f);
    }

    public int GetHit(int damage)
    {
        HP -= damage;
        if(HP <= 0)
        {
            soMonster.itemDropTable.ItemDrop(transform.position);
        }

        return HP;
    }
}
