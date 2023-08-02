using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public static Player Instance { get; private set; }
    Rigidbody2D rigid;
    [SerializeField] private int speed = 10;   // 플레이어 이동 속도 
    private Vector2 speedVec;   // 가속도

    public float currnetHeath = 10;
    public float maxHealth = 10;

    private void Awake() {
        Instance = this;
        rigid = GetComponent<Rigidbody2D>();
        rigid.freezeRotation = true;
    }

    private void Update() 
    {
        speedVec = Vector2.zero;    // 가속도 초기화
        if(Input.GetKey(KeyCode.W))
        {
            speedVec.y += speed;
        }
        if(Input.GetKey(KeyCode.A))
        {
            speedVec.x -= speed;
        }
        if(Input.GetKey(KeyCode.S))
        {
            speedVec.y -= speed;
        }
        if(Input.GetKey(KeyCode.D))
        {
            speedVec.x += speed;
        }

        GetComponent<Rigidbody2D>().velocity = speedVec;    // 스피드 저장
    }

}
