using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    [SerializeField] float laserSpeed = 10f;
    [SerializeField] int damage = 20;

    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Rigidbody2D>().velocity = new Vector2(0, laserSpeed);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public int GetDamage()
    {
        return damage;
    }
}
