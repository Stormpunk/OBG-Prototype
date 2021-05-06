using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    private float speed;
    public float lifeTime = 10;
    public float damage;
    public Rigidbody2D rb;


    private void Start()
    { 
        speed = 400;
     
    }
    private void FixedUpdate()
    {
        rb.AddForce(Vector3.right * speed);
        lifeTime -= Time.deltaTime;
        if (lifeTime <= 0)
        {
            Destroy(gameObject,lifeTime);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "enemy")
        {
            Enemy currentHealth = collision.gameObject.GetComponent<Enemy>();
            if (currentHealth != null)
            {
                currentHealth.TakeDamage(1);
                Destroy(gameObject);
            }

        }
    }
}

  
