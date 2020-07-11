using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    public int attack = 2;
    
    void OnCollisionEnter2D(Collision2D other)
    {
        // when enemy collides with the player we take damage
        if(other.gameObject.tag == "Player")
        {
            GameObject.FindGameObjectWithTag("MainPlayer").GetComponent<PlayerHealth>().TakeDamage(attack);
        }
    }
}