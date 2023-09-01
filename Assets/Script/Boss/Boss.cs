using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    [HideInInspector] public float BossCurrentHP, BossMaxHP, BossAttack, BossDefence;
    public BossStat bossStat;
    [SerializeField] private GameObject symbolPrefab; // 보스 처치시 등장하는 신상 프리팹
    TestRoomTemplates templates;
    [SerializeField] private BossHPBar bossHP;
    private void Awake()
    {
        templates = GameObject.FindGameObjectWithTag("Rooms").GetComponent<TestRoomTemplates>();
        BossMaxHP = bossStat.maxHP;    // 최대 체력
        BossCurrentHP = bossStat.currentHP; // 현재 체력
        BossAttack = bossStat.attack;   // 공격력
        BossDefence = bossStat.defence; // 방어력

        bossHP = GameObject.Find("Canvas").transform.Find("BossHPBar").GetComponent<BossHPBar>();
        bossHP.UpdateHPBar(BossCurrentHP, BossMaxHP);
    }
    public float Reduce(float damage)  // 체력 감소 시
    {
        float real_damage = damage - BossDefence;
        if (real_damage > 0)
        {
            BossCurrentHP -= real_damage;
            bossHP.UpdateHPBar(BossCurrentHP, BossMaxHP);
        }

        if (BossCurrentHP <= 0)
        {   
            BossDie();
        }
        return BossCurrentHP;
    }

    public void BossDie()
    {
        bossHP.gameObject.SetActive(false); // 보스 피 안보이게
        Instantiate(symbolPrefab, templates.instZero, Quaternion.identity); // Symbol을 맵 중앙에 소환    
        Destroy(gameObject);
    }
}
