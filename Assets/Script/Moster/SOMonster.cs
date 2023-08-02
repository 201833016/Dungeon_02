using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "moster", menuName = "Not need/moster Stat")]
public class SOMonster : ScriptableObject
{
    public int STR;
    public int AGI; 
    public int CON;

    public SOItemDropTable itemDropTable;
}
