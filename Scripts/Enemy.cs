using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] int health = 100;
    [SerializeField] int scoreValue = 10;
    [SerializeField] GameObject explosionVFX;

    [SerializeField] GameObject enemyLaser;
    [SerializeField] float shotIntervalMin = 0.5f;
    [SerializeField] float shotIntervalMax = 1.5f;


    float shotCountDown; 
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player Laser")
        {
            Destroy(collision.gameObject);
            health -= collision.gameObject.GetComponent<Laser>().GetDamage();
            if (health <= 0)
            {
                FindObjectOfType<ScoreManager>().AddToScore(scoreValue);
                Instantiate(explosionVFX, transform.position, transform.rotation);
                Destroy(gameObject);

            }
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        shotCountDown = Random.Range(shotIntervalMin, shotIntervalMax);
    }

    // Update is called once per frame
    void Update()
    {
        shotCountDown -= Time.deltaTime;
        if(shotCountDown <= 0)
        {
            Instantiate(enemyLaser, transform.position, transform.rotation);
            shotCountDown = Random.Range(shotIntervalMin, shotIntervalMax);

        }
    }
}
