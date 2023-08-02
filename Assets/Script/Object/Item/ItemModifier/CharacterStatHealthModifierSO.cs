using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "HP Heal", menuName = "item Effect/HP Heal")]
public class CharacterStatHealthModifierSO : ChracterStatModifierSO
{
    public override void AffectCharacter(GameObject character, float val)   // 캐릭터 상태 추상 클래스 오버라이드
    {
        Health health = character.GetComponent<Health>();
        if(health != null)
        {
            health.AddHealth((int)val); // 체력 회복 효과
        }
        
    }
}
