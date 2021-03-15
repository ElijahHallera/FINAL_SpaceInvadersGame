using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
  public GameObject bullet;
    float amplify = 5;
    public float fireDelay = 2f;
    public Transform shottingOffset;
    private Animator playerAnimator;

    public AudioClip shootSound;
    public AudioSource speaker;

    void Start()
    {
        playerAnimator = GetComponent<Animator>();
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Translate(Vector3.up * Time.deltaTime * amplify);
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.Translate(-Vector3.up * Time.deltaTime * amplify);
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
        speaker.PlayOneShot(shootSound);
        playerAnimator.SetTrigger("Shoot");
        GameObject shot = Instantiate(bullet, shottingOffset.position, Quaternion.identity);
        Destroy(shot, 3f);
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "enemyBullet")
        {
            Destroy(gameObject);
        }
    }
}
