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
        Debug.Log(enemyHealth);
        if(enemyHealth <= 0) Destroy(gameObject);
    }

    private void GetPushed()
    {
        transform.position = Vector2.MoveTowards(transform.position, pushPos.position, pushForce * Time.deltaTime);
    }
}