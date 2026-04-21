using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    [SerializeField] int health = 100;
    [SerializeField] GameObject laser;
    [SerializeField] AudioClip shootSFX;

    [SerializeField] float shotInterval = 0.5f;


    float shotCoolDown;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Enemy Laser")
        {
            Destroy(collision.gameObject);
            health -= collision.gameObject.GetComponent<Laser>().GetDamage();
            if (health <= 0)
            {
                Destroy(gameObject);
                SceneManager.LoadScene("Game Over");
            }
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        shotCoolDown = shotInterval;
      
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
        Fire();
    }

    private void Movement()
    {
        if (Input.GetKey(KeyCode.D))
        {
            transform.position += new Vector3(0.02f, 0, 0);
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.position -= new Vector3(0.02f, 0, 0);
        }
        if (Input.GetKey(KeyCode.W))
        {
            transform.position += new Vector3(0, 0.02f, 0);
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.position -= new Vector3(0, 0.02f, 0);
        }

    }

    private void Fire()
    {
        shotCoolDown -= Time.deltaTime;

        if (Input.GetKey(KeyCode.Space) && shotCoolDown <= 0)
        {
            Instantiate(laser, transform.position, transform.rotation);
            AudioSource.PlayClipAtPoint(shootSFX, Camera.main.transform.position);
            shotCoolDown = shotInterval;
        }

    }

    public int GetHealth()
    {
        return health;
    }
    
   
}
