using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public static Player Instance { get; private set; }
    Rigidbody2D rigid;
    //public int speedPlayer;   // 플레이어 이동 속도 
    private Vector2 speedVec;   // 가속도

    private float currnetHeath, maxHealth, attackPlayer, defencePlayer, speedPlayer, speedAttackPlayer;
    public Health health;   // 피격을 위한 클래스

    private void Awake()
    {
        Instance = this;
        rigid = GetComponent<Rigidbody2D>();
        rigid.freezeRotation = true;
        PlayerStateUpdate();
    }

    private void Update()
    {
        speedVec = Vector2.zero;    // 가속도 초기화
        if (Input.GetKey(KeyCode.W))
        {
            speedVec.y += speedPlayer;
        }
        if (Input.GetKey(KeyCode.A))
        {
            speedVec.x -= speedPlayer;
        }
        if (Input.GetKey(KeyCode.S))
        {
            speedVec.y -= speedPlayer;
        }
        if (Input.GetKey(KeyCode.D))
        {
            speedVec.x += speedPlayer;
        }

        GetComponent<Rigidbody2D>().velocity = speedVec;    // 스피드 저장

        if (Input.GetKeyDown(KeyCode.U))
        {
            health.Reduce(2);
            PlayerStateUpdate();
        }
    }

    public void PlayerStateUpdate()  // 플레이어 상태 업데이트
    {
        maxHealth = health.maxHP;    // 최대 체력
        currnetHeath = health.currentHP; // 현재 체력
        attackPlayer = health.attack;   // 공격력
        defencePlayer = health.defence; // 방어력
        speedPlayer = health.speedMove;   // 이동 속도
        speedAttackPlayer = health.speedAttack; // 공격 속도
    }



}
