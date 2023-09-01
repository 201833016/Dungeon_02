using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    Player player;
    public GameObject bullet;   // 발사체
    public Transform AttackPosition;    // 발사위치
    public float cooltime;  // 발사간격
    private float curtime;  // 현재 시간
    private MovePoint check;
    private float z;    // 마우스 좌표 회전
    private string playerView;  // 플레이어 보는 방향

    private void Awake()
    {
        player = GetComponentInParent<Player>();
        check = GameObject.FindGameObjectWithTag("MapFollwed").GetComponent<MovePoint>();
    }
    void Update()
    {
        Vector2 len = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;    // 마우스 좌표값을 월드 좌표로 변경 , 그후 플레이어 좌표 감산
        z = Mathf.Atan2(len.y, len.x) * Mathf.Rad2Deg;    // 파티고라스 공식, 대각선 각도 구하기
        transform.rotation = Quaternion.Euler(0, 0, z);   // 계산한 각도 가져와서, 초기화
        PlayerViewPoint();

        if (Input.GetMouseButtonDown(0))
        {
            player.movement2D.moveSpeed = player.speedPlayer / 2f;  // 사격시 이동속도 절반 감소
        }

        if (curtime <= 0)    // 총알 발사 쿨타임이 아니면
        {
            if (!check.playerArriveCheck)
            {
                if (Input.GetMouseButton(0))
                {
                    
                    switch (playerView)
                    {
                        case "left_Shoot": // 왼쪽
                            player.animator.SetBool("isShoot", true);
                            player.animator.SetBool("isShooting", true);    // 총 사용중 달리기 모션 안뜨기
                            player.animator.SetInteger("ShootNum", 1);
                            //player.movement2D.moveSpeed = 5f;  // 총 쏘는중 속도 줄이기
                            transform.localPosition = new Vector3(-1f, 0.5f, 1f);   // 총알 나오는 위치
                            break;
                        case "right_Shoot": // 오른쪽
                            player.animator.SetBool("isShoot", true);
                            player.animator.SetBool("isShooting", true);    // 총 사용중 달리기 모션 안뜨기
                            player.animator.SetInteger("ShootNum", 2);
                            //player.movement2D.moveSpeed = 5f;  // 총 쏘는중 속도 줄이기
                            transform.localPosition = new Vector3(1f, 0.5f, 1f);   // 총알 나오는 위치
                            break;
                        case "up_Shoot": // 위
                            player.animator.SetBool("isShoot", true);
                            player.animator.SetBool("isShooting", true);    // 총 사용중 달리기 모션 안뜨기
                            player.animator.SetInteger("ShootNum", 3);
                            //player.movement2D.moveSpeed = 5f;  // 총 쏘는중 속도 줄이기
                            transform.localPosition = new Vector3(0f, 1.5f, 1f);   // 총알 나오는 위치
                            break;
                        case "down_Shoot": // 아래
                            player.animator.SetBool("isShoot", true);
                            player.animator.SetBool("isShooting", true);    // 총 사용중 달리기 모션 안뜨기
                            player.animator.SetInteger("ShootNum", 4);
                            //player.movement2D.moveSpeed = 5f;  // 총 쏘는중 속도 줄이기
                            transform.localPosition = new Vector3(0f, 0f, 1f);   // 총알 나오는 위치
                            break;

                        default:
                            break;
                    }
                    Instantiate(bullet, AttackPosition.position, transform.rotation);   // 마우스 좌표로 공격
                }
                curtime = cooltime;
            }

        }
        curtime -= Time.deltaTime;
        if (Input.GetMouseButtonUp(0))  // 마우스 뗏을때
        {
            player.animator.SetBool("isShoot", false);
            player.animator.SetBool("isShooting", false);
            player.animator.SetInteger("ShootNum", 0);

            player.movement2D.moveSpeed = player.speedPlayer;

            transform.localPosition = new Vector3(0f, 0f, 1f);  // 총알 나오는 위치
        }
    }

    private void PlayerViewPoint()
    {
        if (z > 45 && z < 135)
        {
            //Debug.Log("위");
            playerView = "up_Shoot";
        }

        if (z <= 45 && z > -45)
        {
            //Debug.Log("오른쪽");
            playerView = "right_Shoot";
        }

        if (z <= -45 && z > -135)
        {
            //Debug.Log("아래");
            playerView = "down_Shoot";
        }

        if ((z <= -135 && z >= -180) || (z >= 135 && z < 180))
        {
            //Debug.Log("왼쪽");
            playerView = "left_Shoot";
        }
    }


}
