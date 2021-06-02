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
    public Animator anim;
    public bool isDamaged;
    private void Start()
    {
        currentHealth = 3;
        speed = 3;
        isDamaged = true;

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
        if (isDamaged == true)
        {
            StartCoroutine(ResetDamageBool());
            isDamaged = false;
        }
    }
    public void TakeDamage(int damageAmount)
    {
        currentHealth -= damageAmount;
        anim.SetBool("isDamaged", true);
        isDamaged = true;
    }
    
    IEnumerator ResetDamageBool()
    {
        Debug.Log("Playing damage animation");
        yield return new WaitForSeconds(0.2f);
        anim.SetBool("isDamaged", false);
        Debug.Log("Return to running animation");
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            Destroy(gameObject);
        }
    }
}
