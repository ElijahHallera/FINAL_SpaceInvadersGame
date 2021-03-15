using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerBarricades : MonoBehaviour
{
    float healthPoints = 3;

    void OnCollisionEnter2D(Collision2D collision)
    {
        healthPoints--;
        Debug.Log("HEALTH POINTS LEFT: " + healthPoints);
        if (healthPoints <= 0)
        {
            Destroy(gameObject);
            Destroy(collision.gameObject);
        }
    }
}
