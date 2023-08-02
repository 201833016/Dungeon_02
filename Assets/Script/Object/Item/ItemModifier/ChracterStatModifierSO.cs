using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ChracterStatModifierSO : ScriptableObject
{
    public abstract void AffectCharacter(GameObject character, float val);  // 캐릭터 상태 추상 클래스 
}
