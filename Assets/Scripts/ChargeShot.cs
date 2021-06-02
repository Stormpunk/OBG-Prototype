using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChargeShot : MonoBehaviour
{
    public float speed;
    public float lifeTime;
    public Rigidbody2D rb;
    public GameObject explosion;
    public Transform chargeShot;

    private void Start()
    {
        lifeTime = 10f;
        speed = 100f;
    }
    private void FixedUpdate()
    {
        rb.AddForce(Vector2.right * speed);
        lifeTime -= Time.deltaTime;
        if (lifeTime <= 0)
        {
            Destroy(gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("enemy"))
        {
            Explode();
            //collision.gameObject.GetComponent<Enemy>().TakeDamage(5);
        }
    }
    void Explode()
    {
        Object.Instantiate(explosion, new Vector2(chargeShot.position.x, chargeShot.position.y), Quaternion.identity) ;
        Destroy(gameObject);
        Debug.Log("KABOOM");
    }

}
