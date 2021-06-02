using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionScript : MonoBehaviour
{
    public float lifeTime;
    private void Start()
    {
        lifeTime = 1f;   
    }
    //explosion will only last for one second
    private void Update()
    {
        lifeTime -= Time.deltaTime;
        if (lifeTime <= 0)
        {
            Destroy(gameObject);
        }
    }
    //destroys explosion after 1 second
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("enemy"))
        {
            Enemy currentHealth = collision.gameObject.GetComponent<Enemy>();
            if (currentHealth != null)
            {
                currentHealth.TakeDamage(5);
                
            }
        }
    }
    //damages the enemy
}

