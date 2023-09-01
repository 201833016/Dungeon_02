using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MapPlayerIn : MonoBehaviour
{
    public bool PlayerIn = false;   // 플레이어가 해당 Room에 있는지
    public bool BossIn = false;
    [SerializeField] private GameObject blessBoxPrefab;
    [SerializeField] private GameObject teleportPrefab;
    [SerializeField] private GameObject monsterPrefab;
    [SerializeField] private MonsterCount monsterCount;
    private void Start()
    {
        if (monsterPrefab != null)
        {
            monsterPrefab.SetActive(false);
        }
    }
    private void Update()
    {
        if (PlayerIn)
        {
            MonsterAppear();
        }
        else
        {
            if(blessBoxPrefab != null)
            {
                blessBoxPrefab.SetActive(false);
            }
            
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerIn = true;
        }

        if (other.CompareTag("Boss"))
        {
            BossIn = true;
            Destroy(blessBoxPrefab);
            Destroy(monsterPrefab);
        }
    }
    private void OnTriggerStay2D(Collider2D other) {
        if(other.CompareTag("Player"))
        {
            // 플레이어가 해당 Room에 들어 왔을경우, 몬스터 가시화
            MonsterAppear();
        }

        if(other.CompareTag("Boss"))
        {
            BossIn = true;
            //itemBoxPrefab.SetActive(false);
            teleportPrefab.SetActive(false);
            //Monster.SetActive(false);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerIn = false;
        }

        if (other.CompareTag("Boss"))
        {
            teleportPrefab.SetActive(true);
            BossIn = false;
        }
    }
    private void MonsterAppear()
    {
        // 몬스터 가시화
        if (monsterPrefab != null)
        {
            monsterPrefab.SetActive(true);   // 몬스터 가시화
        }
        PlayerIn = true;
    }
    /*
    public void InCheck()
    {
        if (PlayerIn)   // 플레이어 있음
        {
            if (BossIn) // 보스 있음
            {
                if (monsterPrefab != null)  // 몬스터가 데이터상존재
                {
                    //monsterPrefab.SetActive(false);
                    Destroy(monsterPrefab); // 보스 방에는 몬스터 오브젝트 삭제
                    if (blessBoxPrefab != null)
                    {
                        Destroy(blessBoxPrefab);
                    }
                    teleportPrefab.SetActive(false);
                }
                else
                {
                    teleportPrefab.SetActive(false);
                }
            }
            else if (!BossIn)
            {
                if (monsterPrefab != null)  // 몬스터가 있으면
                {
                    monsterPrefab.SetActive(true);
                    teleportPrefab.SetActive(false);
                    if (blessBoxPrefab != null)
                    {
                        blessBoxPrefab.SetActive(false);
                    }

                    if (monsterCount.monsterCount <= 0) // 몬스터가 다 사라지면
                    {
                        if (blessBoxPrefab != null)
                        {
                            blessBoxPrefab.SetActive(true);
                        }
                        teleportPrefab.SetActive(true);
                    }
                }
                else
                {
                    if (blessBoxPrefab != null)
                    {
                        blessBoxPrefab.SetActive(true);
                    }
                    teleportPrefab.SetActive(true);
                }

            }
        }
        else    // 방에 플레이어가 없으면
        {
            if (monsterPrefab != null)
            {
                monsterPrefab.SetActive(false);
            }

            if (blessBoxPrefab != null)
            {
                blessBoxPrefab.SetActive(false);
            }
            teleportPrefab.SetActive(false);
        }
    }
    */
}
