using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barricades : MonoBehaviour
{
    public AudioClip owSound;
    public AudioSource speaker;
    float healthPoints = 3;

    void OnCollisionEnter2D(Collision2D collision)
    {
        speaker.PlayOneShot(owSound);
        healthPoints--;
        Debug.Log("HEALTH POINTS LEFT: " + healthPoints);
        if (healthPoints <= 0)
        {
            Destroy(gameObject);
        }
    }
}
