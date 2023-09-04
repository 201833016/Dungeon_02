using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossIdleBullet : MonoBehaviour
{
    public float speed = 10;

    void Update()
    {
        Vector3 dir = transform.up;
        transform.position += dir * speed * Time.deltaTime;
    }
}
