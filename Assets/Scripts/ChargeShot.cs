using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChargeShot : MonoBehaviour
{
    public float speed;
    public float damage;
    public float splashDamage;
    public float lifeTime;
    public Rigidbody2D rb;

    private void Start()
    {
        lifeTime = 5f;
        speed = 100f;
    }
    private void FixedUpdate()
    {
        rb.AddForce(Vector2.right * speed);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "enemy")
        {
            DestroyProjectile();
            collision.gameObject.GetComponent<Enemy>().TakeDamage(5);
        }
    }

    void DestroyProjectile()
    {
        Destroy(gameObject);
    }

}
