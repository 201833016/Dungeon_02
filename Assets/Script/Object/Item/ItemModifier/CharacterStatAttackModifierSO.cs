using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Attack Plus", menuName = "item Effect/Attack Plus")]
public class CharacterStatAttackModifierSO : ChracterStatModifierSO
{
    public string type;
    public float per;
    public float duration;
    public Sprite icon;

    public override void AffectCharacter(Health health, float val)   // 캐릭터 상태 추상 클래스 오버라이드
    {
        //Health health = character.GetComponent<Health>();
        if(health != null)
        {
            //health.AddAttack(val); // 공격력 증가 효과
            BuffManager.instance.CreateBuff(type, per, duration, icon);
            //TestTimeCheck.instance.TextTime(type, per, duration);
        }
    }
}
