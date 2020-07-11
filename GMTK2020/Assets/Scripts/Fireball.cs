using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireball : MonoBehaviour
{
    public int attack = 2;
    public int speed = 500;
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        transform.localScale = GameObject.FindGameObjectWithTag("Player").transform.localScale;
    }

    void FixedUpdate()
    {
        rb.velocity = new Vector2(transform.localScale.normalized.x * speed * Time.fixedDeltaTime, 0f);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Enemy")
        {
            other.gameObject.GetComponent<EnemyHealth>().DealDamageToEnemy(attack);
            Destroy(gameObject);
        }
    }
}