using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    private Rigidbody2D rb;
    public float enemyHealth = 5f;
    public float healthSegment = 0.3f;
    public float pushForce = 300f;
    public Transform pushPos;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        transform.Find("HealthBar").localScale = new Vector3(enemyHealth * healthSegment * 30, 0.1f, 1);
    }

    public void DealDamageToEnemy(int damage)
    {
        GetPushed();
        enemyHealth -= damage;
        if (enemyHealth <= 0)
        {
            Destroy(gameObject);
            GameObject.Find("GameObject").GetComponent<EnemyGenerator>().enemyCount--;
        }
    }

    private void GetPushed()
    {
        transform.position = Vector2.MoveTowards(transform.position, pushPos.position, pushForce * Time.deltaTime);
    }
}