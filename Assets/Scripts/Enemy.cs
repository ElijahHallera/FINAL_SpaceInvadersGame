using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    private Transform AlienGroup;
    public GameObject enemyBullet;
    public GameObject Hit;
    public scoreKeeper score;
    public float speed;
    public float fire = 0.997f;
    Animator enemyAnimator;

    public AudioClip enemyShootSound;
    public AudioClip enemyDieSound;
    public AudioClip congrats;
    public AudioSource speaker;

    private void Start()
    {
        enemyAnimator = GetComponent<Animator>();
        InvokeRepeating("enemyMovement", 0.1f, 0.3f);
        AlienGroup = GetComponent<Transform>();
    }

    void enemyMovement()
    {
        AlienGroup.position += Vector3.right * speed;

        foreach (Transform enemy in AlienGroup)
        {
            if (enemy.position.x < -4 || enemy.position.x > 4)
            {
                speed = -speed;
                AlienGroup.position += Vector3.down * 1f;
                return;
            }

            if(Random.value > fire){
               Instantiate(enemyBullet, enemy.transform.position, enemy.transform.rotation);
               speaker.PlayOneShot(enemyShootSound);
            }
            
            if (enemy.position.y <= -3)
            {
                Time.timeScale = 0;
                SceneManager.LoadScene(sceneName: "Credits");
            }

            if (score.getAlienCount() == 1)
            {
                CancelInvoke();
                InvokeRepeating("enemyMovement", 0.1f, .31f);
            }
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "userBullet")
        {
            GetComponent<Animator>().SetTrigger("Death");
            speaker.PlayOneShot(enemyDieSound);
            Destroy(this.gameObject, 1);
            Destroy(collision.gameObject);

                if (gameObject.name == "Alien1")
                {
                    GameObject.Find("AlienGroup").GetComponent<Enemy>().alien1Increase();
                }

                if (gameObject.name == "Alien2")
                {
                    GameObject.Find("AlienGroup").GetComponent<Enemy>().alien2Increase();
                }

                if (gameObject.name == "Alien3")
                {
                    GameObject.Find("AlienGroup").GetComponent<Enemy>().alien3Increase();
                }

                if (gameObject.name == "MysteryAlien")
                {
                    GameObject.Find("AlienGroup").GetComponent<Enemy>().mysteryAlienIncrease();
                }
        }
    }

    void alien1Increase()
    {
        score.alien1Increase();
        score.decreaseAlienCount();
        if (score.getAlienCount() == 0)
        {
            SceneManager.LoadScene(sceneName: "Credits");
        }
    }

    void alien2Increase()
    {
        score.alien2Increase();
        score.decreaseAlienCount();
        if (score.getAlienCount() == 0)
        {
            SceneManager.LoadScene(sceneName: "Credits");
        }
    }

    void alien3Increase()
    {
        score.alien3Increase();
        score.decreaseAlienCount();
        if (score.getAlienCount() == 0)
        {
            SceneManager.LoadScene(sceneName: "Credits");
        }
    }

    void mysteryAlienIncrease()
    {
        score.mysteryAlienIncrease();
        score.decreaseAlienCount();
        if (score.getAlienCount() == 0)
        {
            SceneManager.LoadScene(sceneName: "Credits");
        }
    }
 
}
