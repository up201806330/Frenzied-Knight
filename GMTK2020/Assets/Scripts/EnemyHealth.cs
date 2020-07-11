using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    private Rigidbody2D rb;
    public int enemyHealth = 5;
    public float pushForce = 300f;
    public Transform pushPos;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    public void DealDamageToEnemy(int damage)
    {
        GetPushed();
        enemyHealth -= damage;
        if(enemyHealth <= 0) //if enemy health is <= 0 it has a change to drop the potion and gets destroyed 
        {
            if(Random.Range(1,100) <= 45) //45% chance
            {
                Instantiate(Resources.Load("Prefabs/Potion"), transform.position, transform.rotation);
            }
            Destroy(gameObject);
        }
    }

    private void GetPushed()
    {
        transform.position = Vector2.MoveTowards(transform.position, pushPos.position, pushForce * Time.deltaTime);
    }
}