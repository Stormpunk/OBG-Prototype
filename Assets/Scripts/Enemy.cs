using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float currentHealth;
    bool isDead;
    public Rigidbody2D rb;
    public float speed;
    public float damage;
    private void Start()
    {
        currentHealth = 5;
        speed = 5;

    }
    private void Update()
    {
        if(currentHealth <= 0)
        {
            isDead = true;
        }
        if(isDead == true)
        {
            Destroy(gameObject);
        }
        rb.AddForce(Vector3.left * speed);
    }
    public void TakeDamage(int damageAmount)
    {
        currentHealth -= damageAmount;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {

        }
    }
}
