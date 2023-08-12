using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "moster", menuName = "Not need/moster Stat")]
public class SOMonster : ScriptableObject
{
    public int STR; // 공격력 계수
    public int AGI; // 속도 계수
    public int CON; // 생명력 계수

    public SOItemDropTable itemDropTable;   // 아이템 드랍 테이블 연결
}
