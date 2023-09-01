using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    Rigidbody2D rb;
    Transform target;
    //EnemyMoveZone zone;
    [Header("목표와의 간격")][SerializeField][Range(0f, 6f)] float contactDistance = 3f;   // 목표와 거리가 이정도 가까워 지면 멈춤
    private Movement2D move2D;
    private MovePoint check;
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        check = GameObject.FindGameObjectWithTag("MapFollwed").GetComponent<MovePoint>();
        move2D = GetComponent<Movement2D>();
    }

    private void Update()
    {
        EnemyFollowTarget();
    }

    private void EnemyFollowTarget()
    {
        if (!check.playerArriveCheck)
        {
            if (Vector2.Distance(transform.position, target.position) > contactDistance)    //&& playerIn
            {
                transform.position = Vector2.MoveTowards(transform.position, target.position, move2D.moveSpeed * Time.deltaTime);
            }
            else
            {
                rb.velocity = Vector2.zero;
            }
        }

    }

}
