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
    private void Update()
    {
        lifeTime -= Time.deltaTime;
        if (lifeTime <= 0)
        {
            Destroy(gameObject);
        }
    }
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
}

