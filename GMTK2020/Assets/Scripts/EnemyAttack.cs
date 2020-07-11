using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    public int attack = 1;
    public float knockback = 5000;
    
    void OnTriggerEnter2D(Collider2D other)
    {
        // when enemy collides with the player we take damage
        if(other.gameObject.tag == "Player")
        {
            GameObject.FindGameObjectWithTag("MainPlayer").GetComponent<PlayerHealth>().TakeDamage(attack);
            Vector3 direction = transform.localScale.normalized; 
            GameObject.FindGameObjectWithTag("MainPlayer").GetComponent<Rigidbody2D>().AddForce( new Vector2(direction.x * knockback, 0f)); //knock back player
        }
    }
}