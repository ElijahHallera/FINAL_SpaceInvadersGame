using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{

    private Transform enemyBullet;
    public float speed;

    void Start()
    {
        enemyBullet = GetComponent<Transform>();
    }

    private void FixedUpdate()
    {
        enemyBullet.position += Vector3.up * -speed;

        if (enemyBullet.position.y <= -10)
        {
            Destroy(enemyBullet.gameObject);
            Destroy(enemyBullet);
        }
    }
}
